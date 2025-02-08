# Calendar Project (.NET)

A modern calendar application built with C# and .NET, providing robust calendar management features.

## Features

- Calendar event management
- Date and time handling
- Event scheduling and reminders

## Prerequisites

- .NET SDK 7.0 or later
- PostgreSQL 14.0 or later (if using PostgreSQL as database)

## System Requirements

- Any Unix-based OS (Linux, macOS) or Windows
- At least 2GB RAM
- 1GB free disk space

## Installation

1. First, install the .NET SDK if you haven't already:
```bash
# For Ubuntu/Debian
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-7.0

# For macOS (using Homebrew)
brew install --cask dotnet-sdk
```

2. Clone the repository:
```bash
git clone https://github.com/vim-web/Calender.git
cd Calender
```

3. Install project dependencies:
```powershell
  Install-Package Npgsql
```
```powershell
  dotnet add package Npgsql
```

4. Set up the database:
```bash
# If using PostgreSQL
sudo -u postgres createdb todo_list_db
create a table named TodoTasks
```

5. Configure application settings:
```bash
cp appsettings.Example.json appsettings.json
# Edit appsettings.json with your database connection string and other settings
```

## Running the Application

1. Start the application:
```bash
git clone https://github.com/vim-web/Calender.git
cd Calender

open this folder in vs code
Go to File > New > Project > ASP.NET  Web Application (under web)  and name the application and select MVC 

go to solution explorer in side bar
create model, controller and from the controller , create view according to the source code 
```
2.run the application 
```
go to the file named RouteConfig.cs and change the controller name and action according to this
 defaults: new { controller = "TodoTask", action = "Index", id = UrlParameter.Optional }
```

3. The API will be available at `/http://localhost:57899/` by default


## Acknowledgments

- Thanks to all contributors who have helped with the project
- Built with .NET and love
