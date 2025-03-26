# Östgöta Event

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=.net)](https://dotnet.microsoft.com/download)
[![Blazor](https://img.shields.io/badge/Blazor-WASM-512BD4?logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![EF Core](https://img.shields.io/badge/EF%20Core-Latest-brightgreen?logo=.net)](https://docs.microsoft.com/ef/core/)
[![SQLite](https://img.shields.io/badge/SQLite-3-003B57?logo=sqlite)](https://www.sqlite.org/)
[![xUnit](https://img.shields.io/badge/Testing-xUnit-aa0000?logo=dotnet)](https://xunit.net/)
[![BCrypt](https://img.shields.io/badge/Security-BCrypt-blue)](https://github.com/BcryptNet/bcrypt.net)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A modern event ticketing platform for Östergötland County, built with Blazor WebAssembly and .NET 9. This application enables users to discover, search, and purchase tickets for local events while providing administrators with powerful management tools.

![Östgöta Event Logo](Misc/kalv.png)

## 🌟 Features

### For Users
- **Event Discovery**: Browse, search, and sort events by various criteria
- **Secure Authentication**: BCrypt-powered user registration and login
- **Ticket Management**: View and manage purchased tickets
- **Profile Management**: Update contact information and password
- **Responsive Design**: Seamless experience across all devices

### For Administrators
- **Comprehensive Dashboard**: Manage events, users, and tickets
- **CRUD Operations**: Full control over system entities
- **Search Functionality**: Quick access to specific records by ID
- **Secure Access**: Role-based authorization system

## 🏗️ Architecture

The solution follows a hybrid approach combining Vertical Slice and Onion Architecture principles, organized into four main projects:

- **BlazorStandAlone**: Frontend WASM application with reusable components
- **Api**: Backend REST API with controller endpoints
- **Core**: Central business logic and data models
- **Test**: Backend service testing using Reqnroll

### Key Technical Aspects
- **Frontend**: Blazor WebAssembly with component-based architecture
- **Backend**: .NET 9 API with controller endpoints
- **Database**: SQLite with Entity Framework Core
- **Authentication**: Custom authentication with BCrypt password hashing
- **Authorization**: Session-based with role verification
- **Validation**: 
  - Frontend: DataAnnotations
  - Backend: FluentValidation

## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- A modern web browser
- IDE (recommended: Visual Studio 2022 or later)

### Installation
1. Clone the repository
```bash
git clone https://github.com/your-username/ostgota-event.git
```

2. Navigate to the solution directory
```bash
cd ostgota-event
```

3. Run the application
```bash
dotnet run --project BlazorStandAlone
```

## 🏗️ Project Structure

## 🧪 Testing

The project includes comprehensive backend testing using Reqnroll with xUnit. Tests focus on validating service functionality and business logic.

## 🛠️ Development

The project includes development-friendly features:
- Database reset capabilities
- Quick admin access toggles
- Session storage for authentication state

## 🤝 Contributing

This project is maintained by:
- TungViktor
- JeppaJogg
- FlutterJocke

[View our KanBan Board](https://github.com/orgs/Ett-bra-team-som-samarbetar-bra/projects/1/views/1)

## 🔒 Security

- Secure password hashing with BCrypt
- Role-based access control
- Session-based authentication
- Input validation on both frontend and backend

## 📝 License

[Your chosen license]

---

Built with ❤️ in Östergötland, Sweden