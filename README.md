# Library Management System

A simple, local Library Management System built with C# and Windows Forms (.NET 8).

## Features

- **User Authentication**: Secure Login and Sign-Up functionality.
- **Dashboard**: Central hub for library operations.
- **Book Management**: Add new books with details like Title, Author, Price, and Quantity.
- **Data Persistence**: Automatically saves user and book data to local JSON files (`users.json` and `books.json`), so no external database setup is required.
- **Modern UI**: Clean, responsive interface with validation and user feedback.

## Getting Started

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or later) with .NET Desktop Development workload installed.
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

### Installation

1.  Clone the repository:
    ```bash
    https://github.com/waqasmohmand23/LibraryManagementSystem.git
    ```
2.  Open the solution file `Library management system.sln` in Visual Studio.
3.  Build the solution (Ctrl+Shift+B).

### Running the Application

1.  Press **Start** (or F5) in Visual Studio.
2.  **Sign Up**: Create a new account on the first screen.
3.  **Login**: Use your new credentials to access the dashboard.
4.  **Add Books**: Navigate to *Books -> Add New Book* to populate your library.

## Project Structure

- **Form1.cs**: Login Form.
- **SignUpForm.cs**: User Registration Form.
- **DashboardForm.cs**: Main Application Dashboard.
- **AddNewBook.cs**: Form to add new books inventory.
- **DataManager.cs**: Handles loading and saving data to JSON files.

## Contributing

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.
