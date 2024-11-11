-- Tạo bảng Users
CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL
);

-- Tạo bảng Teachers
CREATE TABLE Teachers (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(ID)
);

-- Tạo bảng Classes
CREATE TABLE Classes (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    TeacherID INT NOT NULL,
    FOREIGN KEY (TeacherID) REFERENCES Teachers(ID)
);

-- Tạo bảng Students
CREATE TABLE Students (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    ClassID INT NOT NULL,
    FOREIGN KEY (ClassID) REFERENCES Classes(ID)
);

-- Tạo bảng Attendances
CREATE TABLE Attendances (
    ID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    ClassID INT NOT NULL,
    Date DATE NOT NULL,
    Status VARCHAR(20) NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Students(ID),
    FOREIGN KEY (ClassID) REFERENCES Classes(ID)
);
