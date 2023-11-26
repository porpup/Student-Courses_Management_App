# Student-Courses Management Application
## Project Overview

This repository contains the implementation of a multi-tier College Database Management System developed as part of the Winter 2023 curriculum for group 07160. The system is designed to manage and maintain a college's database with functionalities for administrators and students to interact with the data through a C# Windows Form ADO.NET application.

## Features

- **SQL Server Database**: Includes a script for setting up a `College1en` database with tables for Programs, Courses, Students, and Enrollments.
- **Data Integrity**: Enforces relational integrity with primary and foreign keys, and cascading update/delete rules.
- **CRUD Operations**: Windows Form application with DataGridView enabling CRUD operations for each table.
- **Business Logic**: Implements business rules, such as program-course-student relationships and grade entry validations.

## Tools and Technologies

- **Visual Studio Community**: 2017, 2019, or 2022 for full project compatibility.
- **SQL Server**: For backend database management.
- **C# and ADO.NET**: For application logic and database interaction.
- **Windows Forms**: For the graphical user interface.

## Getting Started

To get a local copy up and running follow these simple steps:

1. Clone the repository.
2. Open the solution in Visual Studio Community (version 2017, 2019, or 2022).
3. Build the solution to restore NuGet packages and compile the code.
4. Run the SQL script `Project.sql` to set up the initial database state.
5. Start the application to begin interacting with the system.

## Usage

The system is designed to be intuitive and mirrors real-world college database management systems. After logging in, users can:

- **Administer Programs and Courses**: Add, modify, and remove program offerings and associated courses.
- **Manage Student Information**: Enroll students in programs, update their details, and manage their course enrollments.
- **Handle Grades**: Assign and manage final grades for student enrollments.


<p float="left">
  <img src="https://github.com/porpup/Student_Courses_Management_App/assets/3512401/49a0c33b-9b56-4511-b403-549069006dfc" width="350" />
  <img src="https://github.com/porpup/Student_Courses_Management_App/assets/3512401/015cd969-3595-494d-882d-5eee963962a9" width="350" /> 
</p>
