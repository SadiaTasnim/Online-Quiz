USE ONLINEQUIZ
CREATE Table Teacher
(
TeacherID int IDENTITY Primary key,
FullName varchar(100),
TeacherName varchar(50) not null,
Email varchar(100),
Passwords varchar(20) not null,
Institute varchar(100),
Designation varchar(50),
Contact int ,
)

CREATE Table Student
(
StudentID int IDENTITY Primary key,
StudentName varchar(50) not null,
Passwords varchar(20)  not null,
Email varchar(100),
Institute varchar(100),
Department varchar(50),
Semester varchar(50),
Contact int,
ID varchar(50),
)


CREATE Table FriendListForStudnet
(
FID int IDENTITY Primary key,
studentid int Foreign Key references Student(StudentID),
teacherid int Foreign Key references Teacher(TeacherID) ,
timedate datetime,
friendlist int not null default 0
)

CREATE Table Category
(
CategoryId int IDENTITY primary key,
CategoryName varchar(50) not null,
CategoryTeacher int Foreign Key references Teacher(TeacherID),
available int NOT NULL DEFAULT(0)
)

CREATE Table ExamStudent
(
 ExamineeID int IDENTITY Primary key,
 ID varchar(20) not null, 
 StuCategoryId int Foreign Key references Category(CategoryId),
)

CREATE Table Question
(
QuestionID int IDENTITY Primary key,
QuesCategoryId int Foreign Key references Category(CategoryId),
Question_Text varchar(MAX) not null,
)
CREATE Table Options
(
OptionID int IDENTITY Primary key,
OptQuesId int Foreign Key references Question(QuestionId),
OptionName varchar(max),

)

CREATE Table Answers
(
AnswerID int IDENTITY Primary key,
AnsQuesId int Foreign Key references Question(QuestionId),
AnswerText varchar(max),

)

Create Table Results
(
ResultID int IDENTITY Primary key,
ResStudent int Foreign Key references Student(StudentID),
ResQuesId int Foreign Key references Question(QuestionId),
AnswerText varchar(max),
)

create table Resultshow
(
   resultshowID int IDENTITY Primary key,
   studentID int Foreign Key references Student(StudentID),
   QuesCategoryId int Foreign Key references Category(CategoryId),
   totalmarks int 
)


SELECT * from Teacher
SELECT * from Student
SELECT * from FriendListForStudnet
SELECT * from Category
SELECT * from ExamStudent
SELECT * from Options
SELECT * from Answers
SELECT * from Results
SELECT * from Resultshow
SELECT * from Question


delete from Teacher
delete from Student
delete from FriendListForStudnet
delete from Category
delete from ExamStudent
delete from Question
delete from Options
delete from Answers
delete from Results
delete from Resultshow

delete from Category where CategoryId=8