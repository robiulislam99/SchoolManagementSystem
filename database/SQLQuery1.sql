Create Database SchoolSysDB

Use SchoolSysDB

Create table Class (
    ClassId int primary key identity(1,1) not null,
    ClassName varchar(50) null
)

Create table Subject (
    SubjectId int primary key identity(1,1) not null,
    ClassId int foreign key references Class (ClassId),
    SubjectName varchar(50) null
)

Create table Student (
    StudentId int primary key identity(1,1) not null,
    Name varchar(50) null,
    DOB date null,
    Gender varchar(50) null,
    Mobile bigint null,
    RollNo varchar(50) null,
    Address varchar(max) null,
    ClassId int foreign key references Class (ClassId) null
)

create table Teacher(
    TeacherId int primary key identity(1,1) not null,
    Name varchar(50) null,
    DOB date null,
    Gender varchar(50) null,
    Mobile bigint null,
    Email varchar(50) null,
    Address varchar(max) null,
    Password varchar(20) null
)

Create table TeacherSubject(
    Id int primary key identity(1,1) not null,
    ClassId int foreign key references Class (ClassId) null,
    SubjectId int foreign key references Subject(SubjectId) null,
    TeacherId int foreign key references Teacher(TeacherId) null
)

Create table TeacherAttendance(
    Id int primary key identity(1,1) not null,
    TeacherId int foreign key references Teacher(TeacherId) null,
    Status bit null,
    Date date null
)

Create table StudentAttendance(
    Id int primary key identity(1,1) not null,
    ClassId int foreign key references Class (ClassId) null,
    SubjectId int foreign key references Subject(SubjectId) null,
    RollNo varchar(20) null,
    Status bit null,
    Date date null
)

Create Table Fees(
    FeesId int primary key identity(1,1) not null,
    ClassId int foreign key references Class (ClassId) null,
    FeesAmount int null
)

Create table Exam (
    ExamId int primary key identity(1,1) not null,
    ClassId int foreign key references Class (ClassId) null,
    SubjectId int foreign key references Subject(SubjectId) null,
    RollNo varchar(20) null,
    TotalMarks int null,
    OutOfMarks int null
)

Create table Expense (
    Expensed int primary key identity(1,1) not null,
    ClassId int foreign key references Class (ClassId) null,
    SubjectId int foreign key references Subject(SubjectId) null,
    ChangeAmount int null
)

SELECT * FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_CATALOG = 'SchoolSysDB';
