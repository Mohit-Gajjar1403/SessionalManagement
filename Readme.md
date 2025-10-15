# **Sessional-Management**

## **Project Overview**

Sessional Management is a web-based system designed to simplify academic evaluation and management. It allows teachers to upload and analyze students’ sessional marks, view class performance through graphical comparisons for students, and enables administrators to manage teachers, students, and subjects efficiently. The platform ensures transparency, easy accessibility, and insightful academic data visualization for institutes.

---

## **Features Implemented**

### Teacher Module

- Upload and update sessional marks for students.
- View the number of students under his/her subject.

### Student Module

- View personal sessional marks for all subjects.
- Compare performance across different tests visually.

### Admin Module

- View total teacher and student counts.
- Add new subjects and assign them to teachers.
- Manage teacher and student details (view, edit, and delete).

---

## **Additional Features**

- Secure authentication and role-based access control.
- Responsive and user-friendly dashboard interface.
- Data-driven graphical visualizations (charts and analytics).

---

## **Setup Instructions (How to Run)**

### Prerequisites

- ASP.NET SDK
- Visual Studio / VS Code
- Git installed for version control

### Steps
1. **Clone the Repository**
git clone ```https://github.com/Mohit-Gajjar1403/SessionalManagement.git```
cd sessional-management

2. **Install Dependencies**
dotnet restore


3. **Update the connection string** in `appsettings.json` (ASP.NET)

4. **Run Migrations**
dotnet ef database update

5. **Start the Application**
dotnet run


---

## **Team Members and Individual Contributions**

- **CE025**: Implemented Admin Controller, AccountController; handled logic for adding teachers and subjects, viewing teacher and student counts and their details, and built corresponding razor views. Also created various ViewModels and core models.

- **CE027**: Implemented TeacherController and StudentController; handled logic for uploading student marks sessional-wise and created charts for students to view their marks graphically. Teacher can edit student marks sessional-wise. Created various many-to-many models and the repositories including unitOfWork.
