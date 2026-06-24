# 📊 Sessional Management System

> A web-based academic management system built using **ASP.NET Core MVC** that streamlines sessional marks management, performance analysis, and academic administration through secure role-based access and interactive data visualization.

<p align="center">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?logo=.net" />
  <img src="https://img.shields.io/badge/C%23-Language-239120?logo=c-sharp" />
  <img src="https://img.shields.io/badge/SQL%20Server-Database-CC2927?logo=microsoftsqlserver" />
  <img src="https://img.shields.io/badge/Entity%20Framework-Core-512BD4" />
</p>

---

# 📌 Overview

The **Sessional Management System** is a web application designed to simplify academic evaluation by allowing teachers to manage sessional marks, students to monitor their academic performance, and administrators to efficiently manage teachers, students, and subjects through dedicated dashboards.

---

# 🎥 Project Demonstration

📺 **Watch the complete project demonstration here**

> **Demo Video:** https://docs.google.com/videos/d/1jpxCd3qK-r4ZAy5iUg20XivTB0dnOrroW11pvI4U_78/edit?usp=drive_link

---

# ✨ Features

## 👨‍💼 Administrator

- View institute dashboard
- Manage teachers
- Manage students
- Add and assign subjects
- View teacher and student statistics

### 👨‍🏫 Teacher

- Upload sessional marks
- Update student marks
- View assigned students
- Manage marks session-wise

### 👨‍🎓 Student

- View sessional marks
- Compare performance across different tests
- Interactive graphical performance analysis
- Track academic progress

### 🔐 Security

- Secure Authentication
- Role-Based Authorization
- Protected Routes
- Session Management

---

# 🛠 Tech Stack

| Category | Technologies |
|-----------|--------------|
| Framework | ASP.NET Core MVC |
| Language | C# |
| Database | SQL Server |
| ORM | Entity Framework Core |
| Frontend | HTML, CSS, Bootstrap, Razor Views |
| Charts | Chart.js |
| Architecture | MVC, Repository Pattern, Unit of Work |

---

# 🏗 System Architecture

```
          Users
             │
             ▼
     ASP.NET MVC Application
             │
 ┌───────────┼───────────┐
 │           │           │
Admin     Teacher     Student
 │           │           │
 └───────────┼───────────┘
             │
 Repository & Unit of Work
             │
     Entity Framework Core
             │
        SQL Server Database
```

---

# 📂 Project Structure

```
Sessional-Management
│
├── Controllers/
├── Models/
├── ViewModels/
├── Views/
├── Repositories/
├── wwwroot/
├── appsettings.json
├── Program.cs
├── README.md
└── .gitignore
```

---

# ⚙ Installation

## Clone Repository

```bash
git clone https://github.com/Mohit-Gajjar1403/SessionalManagement.git

cd SessionalManagement
```

---

## Restore Dependencies

```bash
dotnet restore
```

---

## Configure Database

Update the SQL Server connection string inside:

```
appsettings.json
```

---

## Apply Database Migrations

```bash
dotnet ef database update
```

---

## Run the Project

```bash
dotnet run
```

The application will start on the configured local server.

---

# 📊 Core Modules

- Authentication
- Student Management
- Teacher Management
- Subject Management
- Sessional Marks Management
- Performance Analytics
- Admin Dashboard

---

# 🚀 Future Enhancements

- [ ] Attendance Management
- [ ] PDF Report Generation
- [ ] Email Notifications
- [ ] Student Performance Prediction
- [ ] Mobile Responsive UI
- [ ] Advanced Analytics Dashboard

---

# 📚 Learning Outcomes

Through this project, I gained practical experience in:

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- MVC Architecture
- Repository Pattern
- Unit of Work Pattern
- Authentication & Authorization
- CRUD Operations
- Data Visualization
- Role-Based Access Control

---

# 👥 Team Contributions

## **Kavan Dave**

- Developed the **Teacher Module**
- Developed the **Student Module**
- Implemented sessional marks upload and update functionality
- Developed graphical performance analysis using Chart.js
- Designed many-to-many database relationships
- Implemented Repository Pattern and Unit of Work

---

## **Mohit Gajjar**

- Developed the **Admin Module**
- Implemented Authentication & Account Management
- Developed teacher and subject management
- Created admin dashboards and Razor Views
- Designed core models and ViewModels

---

# 📄 License

This project was developed for educational and learning purposes.

---

⭐ If you found this project helpful, consider giving it a star!
