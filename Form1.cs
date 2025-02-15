using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net.Sockets;

namespace HTTPAMAM
{
    public partial class Form1 : Form
    {
        private HttpListener httpListener;
        private bool isRunning = false;
        private X509Certificate2 sslCertificate;
        
        public Form1()
        {
            InitializeComponent();
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
        }

        private async void StartListening()
        {
            while (isRunning)
            {
                try
                {
                    var context = await httpListener.GetContextAsync();
                    // Запускаем обработку запроса в отдельной задаче
                    _ = Task.Run(() => HandleRequest(context));
                }
                catch (Exception ex)
                {
                    if (isRunning) // Проверяем, не остановлен ли сервер намеренно
                    {
                        LogMessage($"Ошибка при получении запроса: {ex.Message}");
                    }
                }
            }
        }

        private async Task HandleRequest(HttpListenerContext context)
        {
            try
            {
                var request = context.Request;
                var response = context.Response;

                LogMessage($"Получен запрос: {request.HttpMethod} {request.Url}");

                // Простой ответ для тестового запроса
                string responseString = "<html><body><h1>Тестовый ответ прокси-сервера</h1></body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                response.ContentType = "text/html";
                
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.Close();
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка при обработке запроса: {ex.Message}");
                try
                {
                    context.Response.StatusCode = 500;
                    context.Response.Close();
                }
                catch { /* игнорируем ошибки при отправке ответа об ошибке */ }
            }
        }

        private async Task SendTestRequest()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage();
                    request.Method = new HttpMethod(cmbMethod.Text);
                    request.RequestUri = new Uri(txtUrl.Text);

                    if (!string.IsNullOrEmpty(txtRequestBody.Text) && 
                        (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put))
                    {
                        request.Content = new StringContent(txtRequestBody.Text, Encoding.UTF8, "application/json");
                    }

                    LogMessage($"Отправка {request.Method} запроса на {request.RequestUri}");
                    if (request.Content != null)
                    {
                        LogMessage($"Тело запроса: {txtRequestBody.Text}");
                    }

                    var response = await client.SendAsync(request);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    LogMessage($"Получен ответ: {(int)response.StatusCode} {response.StatusCode}");
                    LogMessage($"Тело ответа: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка при отправке запроса: {ex.Message}");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            _ = SendTestRequest();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                StartProxy();
            }
            else
            {
                StopProxy();
            }
        }

        private void StartProxy()
        {
            try
            {
                int port = (int)numPort.Value;
                if (!IsPortAvailable(port))
                {
                    int newPort = FindAvailablePort(port + 1);
                    if (MessageBox.Show(
                        $"Порт {port} занят. Использовать порт {newPort}?",
                        "Порт занят",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        port = newPort;
                        numPort.Value = port;
                    }
                    else
                    {
                        return;
                    }
                }

                httpListener = new HttpListener();
                
                if (chkEnableHttps.Checked)
                {
                    if (sslCertificate == null)
                    {
                        sslCertificate = GenerateAndInstallCertificate();
                        if (sslCertificate == null)
                        {
                            return;
                        }
                    }
                    string httpsPrefix = $"https://localhost:{port}/";
                    httpListener.Prefixes.Add(httpsPrefix);
                }
                else
                {
                    string httpPrefix = $"http://localhost:{port}/";
                    httpListener.Prefixes.Add(httpPrefix);
                }
                
                httpListener.Start();
                isRunning = true;
                btnStartStop.Text = "Стоп";
                LogMessage($"Прокси-сервер запущен на порту {port} ({(chkEnableHttps.Checked ? "HTTPS" : "HTTP")})");
                
                StartListening();
                
                numPort.Enabled = false;
                chkEnableHttps.Enabled = false;

                UpdateStatus("Прокси запущен", port.ToString());
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка запуска прокси: {ex.Message}");
                StopProxy();
            }
        }

        private void StopProxy()
        {
            try
            {
                if (httpListener != null && httpListener.IsListening)
                {
                    httpListener.Stop();
                    httpListener.Close();
                    isRunning = false;
                    btnStartStop.Text = "Старт";
                    LogMessage("Прокси-сервер остановлен");
                    
                    // Включаем элементы управления
                    numPort.Enabled = true;
                    chkEnableHttps.Enabled = true;

                    UpdateStatus("Готов", numPort.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка остановки прокси: {ex.Message}");
            }
        }

        private void LogMessage(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => LogMessage(message)));
                return;
            }

            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            txtLog.ScrollToCaret();
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, 
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true; // Принимаем все сертификаты для тестирования
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopProxy();
            base.OnFormClosing(e);
        }

        private X509Certificate2 GenerateAndInstallCertificate()
        {
            try
            {
                var certificateName = "HTTPAMAM Proxy CA";
                var sanBuilder = new SubjectAlternativeNameBuilder();
                sanBuilder.AddIpAddress(IPAddress.Loopback);
                sanBuilder.AddDnsName("localhost");

                using (var rsa = RSA.Create(2048))
                {
                    var request = new CertificateRequest(
                        $"CN={certificateName}",
                        rsa,
                        HashAlgorithmName.SHA256,
                        RSASignaturePadding.Pkcs1);

                    request.CertificateExtensions.Add(
                        new X509BasicConstraintsExtension(true, false, 0, true));

                    request.CertificateExtensions.Add(
                        new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

                    request.CertificateExtensions.Add(sanBuilder.Build());

                    var certificate = request.CreateSelfSigned(
                        DateTimeOffset.Now,
                        DateTimeOffset.Now.AddYears(5));

                    var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(certificate);
                    store.Close();

                    LogMessage("SSL сертификат успешно создан и установлен");
                    return certificate;
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка при создании сертификата: {ex.Message}");
                return null;
            }
        }

        private void btnInstallCert_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Это действие установит корневой сертификат в хранилище текущего пользователя. Продолжить?",
                "Установка сертификата",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var cert = GenerateAndInstallCertificate();
                if (cert != null)
                {
                    MessageBox.Show(
                        "Сертификат успешно установлен. Теперь вы можете включить HTTPS перехват.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private bool IsPortAvailable(int port)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    try
                    {
                        client.Connect("127.0.0.1", port);
                        return false; // Порт занят
                    }
                    catch (SocketException)
                    {
                        return true; // Порт свободен
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private int FindAvailablePort(int startPort)
        {
            int port = startPort;
            while (port < 65535)
            {
                if (IsPortAvailable(port))
                {
                    return port;
                }
                port++;
            }
            throw new Exception("Не удалось найти свободный порт");
        }

        private void UpdateStatus(string status, string port)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new Action(() => UpdateStatus(status, port)));
                return;
            }
            
            lblStatus.Text = status;
            lblPortStatus.Text = $"Порт: {port}";
        }
    }
}
