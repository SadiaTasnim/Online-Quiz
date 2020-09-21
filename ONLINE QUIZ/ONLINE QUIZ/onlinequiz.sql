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

insert into Teacher values 
('Rima sultana','Rima','rima@gmail.com','1234','Ahsanullah University Of Technology','Professor',01814567890),
('Nusrat Jahan','Nusrat','nusrat@gmail.com','5678','Ahsanullah University Of Technology','Lecturer',01638641567),
('Ishrat Shipra','Shipra','shipra@gmail.com','2222','Ahsanullah University Of Technology','Professor',01814483930),
('Md.Haris Talukdar','Haris','haris999@gmail.com','2423','Ahsanullah University Of Technology','Associate Professor',01715757303),
('Mohammad Ali','Mohammad','mohammadali07@gmail.com','7890','Ahsanullah University Of Technology','Lecturer',01819186543)

insert into Student  values 
('Sadia Tasnim','1234','sadiatasnim019@gmail.com','Ahsanullah University Of Technology','cse','3.2',01953728922,'170104037'),
('Tasmiya Tisha','4200','tisha07@gmail.com','Ahsanullah University Of Technology','CSE','3.2',01554306785,'170104033'),
('Rishad Ul Islam','3456','rishad012@gmail.com','Ahsanullah University Of Technology','CSE','3.2',01920846357,'170104047'),
('Farhana Tumpa','5678','tumpa@gmail.com','Ahsanullah University Of Technology','CSE','3.2',01842440053,'170104042'),
('Nishat Sharmin Audry','9678','audry@gmail.com','Ahsanullah University Of Technology','CSE','3.2',0183835967,'170104043')

insert into Category values 
('OS Lab Final',1,0),
('Physics Quiz-1',2,0),
('Physics Quiz-2',2,0),
('Physics Final Quiz',2,0),
('Chemistry Quiz-1',3,0),
('Chemistry Quiz-2',3,0),
('Chemistry Final Quiz',3,0),
('English Quiz-1',4,0),
('English Quiz-2',4,0),
('Industrial Law Final quiz', 4,0),
('Math Quiz-1', 5,0),
('OS Lab Quiz',1,0)


insert into Question values 
--physics 1
(2,'The transport phenomenon in gases is related to which of the following?'),
(2,'The working principle of a washing machine is'),
(2,'Nuclear sizes are expressed in a unit named?'),
(2,'Which of the following is not a vector quantity?'),
(2,'The most suitable unit for expressing nuclear radius is:'),
--physics 2
(3,'An air bubble in water will act like a :'),
(3,'Temperature can be expressed as derived quantity in terms :'),
(3,'An air bubble in water will act like a :'),
(3,'It is more difficult to walk on ice than on a concrete road because :'),
--chemistry1
(5,'The purest form of iron is'),
(5,'Hydrogen bomb is based on the principle of'),
(5,'SI unit of equivalent conductance'),
(5,'Which one of the following is not a mixture'),
(5,'Brass gets discoloured in air because of the presence of which of the following gases in air?'),
--chem 2
(6,'Among the given nutrients, milk is a poor source of'),
(6,'What is the structure of IF7 ?'),
(6,'Name the Scientist who stated that matter can be converted into energy'),
(6,'When formaldehyde and potassium hydroxide are heated , we get'),
(6,'The enzyme that converts glucose to ethyl alcohol is '),
--chem final
(7,'A mixture of sand and naphthalene can be separated by'),
(7,' Yellow cake an item of smuggling across border s'),
(7,'Is C2 Paramagnetic or Diamagnetic?'),
(7,'What is the third most common gas found in the air we breathe ?'),
(7,'Which one of the following substances does not have a melting point'),
--eng1
(8,'egbindinatl correct spelling'),
(8,'One who possesses many talents-One word substitute for the given word is? '),
(8,'Generic is most similar in meaning to:'),
(8,'which part of the given sentence has an error?She dont speak of either German or French.'),
(8,'Choose the correct verb form from those in brackets.The earth _ round the sun.'),
--eng2
(9,'Tether is most similar in meaning to'),
(9,'Lover of nature is called'),
(9,'Correction of sentences:'),
(9,'Camouflage is one way animals protect themselves.Is this pronoun reflexive or intensive?'),
(9,'pompous he was an entertaining person.'),
--industrial Law
(10,'Basic tool in work study is:'),
(10,'PERT has following time estimate'),
(10,'An event is indicated on the network by'),
(10,'ABC analysis deals with'),
(10,'The product layout:')


insert into Options values 
--physics 1
(1,'viscosity'),(1,'surface tension'),(1,'conduction'),(1,'radiation'),
(2,'reverse osmosis'),(2,'diffusion'),(2,'centrifugation'),(2,'dialysis'),
(3,'Fermi'),(3,'Angstrom'),(3,'Newton'),(3,'Tesla'),
(4,'speed'),(4,'velocity'),(4,'torque'),(4,'displacement'),
(5,'micro'),(5,'nanometre'),(5,'fermi'),(5,'angstrom'),
--phy 2
(6,'convex lens'),(6,'convex mirror'),(6,'concave lens'),(6,'concave mirror'),
(7,'length and mass'),(7,'mass and time'),(7,'length,mass and time'),(7,'in terms of none'),
(8,'convex lens'),(8,'convex mirror'),(8,'concave lens'),(8,'concave mirror'),
(9,' there is very little friction between the ice and feet pressing it'),(9,'ice is soft when compared to concrete'),
(9,'there is more friction between the ice and feer'),(9,' None of these'),
--chem 1
( 10,'wrought iron'),(10,' steel'),(10,'pig iron'),(10,'nickel steel'),
( 11,' nuclear fission'),(11,' nuclear fusion'),(11,'natural radioactivity'),(11,'artificial radioactivity'),
( 12,'ohm/cm'),(12,' Siemens'),(12,'Siemens/equivalent'),(12,'mho/cm'),
( 13,'air'),(13,'mercury'),(13,'milk'),(13,'cement'),
( 14,'Hydrogen sulphide'),(14,'Oxygen'),(14,'Nitrogen'),(14,'Carbon dioxide'),
--chem2,
(15,'Calcium'),(15,'Protein'),(15,'Vitamin C'),(15,'Carbohydrates'),
(16,'Triagonal bipyramid'),(16,'Pentagonal bipyramid'),(16,'Square pyramid'),(16,'tetrahedral'),
(17,' Boyle'),(17,'Lavoisier'),(17,'Avogadro'),(17,'Einstein'),
(18,'Acetylene'),(18,'Methyl alcohol'),(18,'Methane'),(18,'Ethyl formate'),
(19,'Maltase'),(19,' Zymase'),(19,'Diastase'),(19,'Invertase'),
--chem final
(20,'Fractional distillation'),(20,'Sublimation'),(20,'Chromatography'),(20,' Any of them'),
(21,'A crude form of heroin'),(21,'A crude form of cocaine'),(21,'Uranium oxide'),(21,'Unrefined gold'),
(22,'Paramagnetic'),(22,'Diamagnetic'),(22,'Ferromagnetic'),(22,'Cannot be determined'),
(23,'Argon'),(23,'Neon'),(23,'Carbondioxide'),(23,' Hydrogen'),
(24,'bromine'),(24,'sodium chloride'),(24,'mercury'),(24,' glass'),
--Eng1 
(25,'Television'),(25,'Dining table'),(25,' Door step'),(25,' Telephone'),
(26,'Exceptional'),(26,'Wisdom'),(26,'Versatile'),(26,'Nubile'),
(27,'Branded'),(27,'Basic'),(27,'rademarked'),(27,'Specific'),
(28,'dont'),(28,'of'),(28,' or'),(28,'speak'),
(29,' moves	'),(29,'moved'),(29,'move'),(29,'None of the above'),
--Eng2
(30,'Cord'),(30,'Unleash'),(30,'Remove'),(30,'None of the above'),
(31,'Autophile'),(31,'Green panther'),(31,'Dendrophile'),(31,'Petrichor'),
(32,'What your Sirname?'),(32,'What is your Sirname?'),(32,'Your Sirname is what?'),(32,'None of the above'),
(33,' reflexive'),(33,'intensive'),(33,'Both A & B'),(33,'None of the above'),
(34,'Though'),(34,'Never'),(34,'Despite'),(34,'Before'),
--Industrial Law
(35,'Graph paper'),(35,'Process chart'),(35,'Planning chart'),(35,'Stop watch'),
(36,' One time estimate'),(36,'Two time estimate'),(36,'Three time estimate'),(36,'Four time estimate'),
(37,'A straight line'),(37,'a circle or a square'),(37,'A straight line with circles'),(37, 'A dotted line'),
(38,'Analysis of process chart'),(38,'Flow of material'),(38,'Ordering schedule of job'),(38,'Controlling inventory costs money'),
(39,'Lowers overall manufacturing time'),(39,'Requires less space for placing machines'),(39,'Utilizes machine and labour better'),(39,'All of these')

insert into Answers values
(1,'surface tension'),(2,'reverse osmosis'),(3,'Angstrom'),(4,'displacement'),(5,'angstrom'),
(6,'convex lens'),(7,'in terms of none'),(8,'concave mirror'),(9,'None of these'),
(10,'steel'),(11,'  nuclear fusion'),(12,'ohm/cm'),(13,'mercury'),(14,'Carbon dioxide'),
(15,'Vitamin C'),(16,'Square pyramid'),(17,'Avogadro'),(18,'Methyl alcohol'),(19,'Diastase'),
(20,'Fractional distillation'),(21,'Uranium oxide'),(22,'Ferromagnetic'),(23,'Carbondioxide'),(24,' glass'),
(25,'Dining table'),(26,'Versatile'),(27,'Basic'),(28,'dont'),(29,'None of the above'),
(30,'Cord'),(31,'Autophile'),(32,'None of the above'),(33,' reflexive'),(34,'Though'),
(35,'Planning chart'),(36,'Four time estimate'),(37,'A dotted line'),(38,'Ordering schedule of job'),(39,'All of these')

SELECT * from Teacher
SELECT * from Student
SELECT * from FriendListForStudnet
SELECT * from Category
SELECT * from ExamStudent
SELECT * from Question
SELECT * from Options
SELECT * from Answers
SELECT * from Results
SELECT * from Resultshow



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
