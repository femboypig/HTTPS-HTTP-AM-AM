# HTTP/HTTPS Interceptor

A lightweight HTTP/HTTPS proxy interceptor built with C# Windows Forms that allows you to monitor and test HTTP/HTTPS requests.

## Features

- HTTP/HTTPS proxy server
- Request interception and logging
- SSL certificate generation and installation
- Custom port configuration
- Support for GET, POST, PUT, DELETE methods
- Request body support for POST/PUT methods
- Real-time status monitoring

## Prerequisites

- Windows OS
- .NET Framework 4.7.2 or higher
- Visual Studio 2019 or higher (for development)

## Installation

1. Clone the repository
2. Open the solution in Visual Studio
3. Build and run the project

## Usage

1. Start the proxy server by clicking the "Start" button
2. Configure the port number (default: 8080)
3. For HTTPS interception:
   - Click "Install SSL" to generate and install the certificate
   - Enable HTTPS checkbox
4. Use the test request feature to verify the proxy:
   - Select HTTP method
   - Enter URL
   - Add request body (for POST/PUT)
   - Click "Test Request"

## Creating Git Repository

1. Initialize a new Git repository:
```bash
git init
```

2. Create .gitignore file:
```bash
# .gitignore
bin/
obj/
.vs/
*.user
*.suo
```

3. Add and commit files:
```bash
git add .
git commit -m "Initial commit"
```

4. Create a new repository on GitHub/GitLab

5. Link and push to remote:
```bash
git remote add origin <repository-url>
git branch -M main
git push -u origin main
```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Built with C# Windows Forms
- Uses System.Net.HttpListener for proxy functionality
- Implements custom SSL certificate generation


