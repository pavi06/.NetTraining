-- create database
create database dbEmployeeTrackerAsgn

--to use db
use dbEmployeeTrackerAsgn

--create Employee table
create Table Employee
(Emp_id int identity(1,1) constraint pk_EmpId primary key,
Emp_name varchar(35) not null, Salary float, 
Department_Name varchar(40) null, 
Boss_No int constraint fk_BossNo references Employee(Emp_id) null
)

sp_help Employee


--create Department Table
create table Department
(Department_Name varchar(40) constraint pk_DepartName primary key,
FloorNo int ,PhoneNumber varchar(15), Employee_Id int constraint fk_EmpId references Employee(Emp_id) not null
)

sp_help Department

--create Item Table
create table Item(
Item_Name varchar(40) constraint pk_ItemName primary key,
ItemType char(1), ItemColor varchar(20)
)

sp_help Item

--create Sales Table
create table Sales(
Sales_id int identity(101,1) constraint pk_SalesId primary key,
SalesQuantity int , ItemName varchar(40) constraint fk_ItemName references Item(Item_Name) not null, 
Department_Name varchar(40) constraint fk_DepartName references Department(Department_Name) not null
)

sp_help Sales

--Alter employee table for foreign key
Alter table Employee
add constraint fk_DeptName foreign key (Department_Name) references Department(Department_Name) ;

sp_help Employee

--Insert values to Employee table
Insert into Employee(Emp_name,Salary,Department_Name,Boss_No)
Values('Alice',75000,null,null)

select * from Employee

Insert into Employee(Emp_name,Salary,Department_Name,Boss_No)
Values('Ned',45000,null,1),('Andrew',25000,null,2),('Clare',22000,null,2),('Todd',38000,null,1),
('Nancy',22000,null,5),('Brier',43000,null,1),('Sarah',56000,null,7)

Insert into Employee(Emp_name,Salary,Department_Name,Boss_No)
Values('Sophile',35000,null,1),('Sanjay',15000,null,3),('Rita',15000,null,4),('Gigi',16000,null,4),
('Maggie',11000,null,4),('Paul',15000,null,3),('James',15000,null,3),
('Pat',15000,null,3),('Mark',15000,null,3)

select * from Employee

--Insert values to Department table
Insert into Department(Department_Name,FloorNo,PhoneNumber,Employee_Id)
Values('Management',5,'34',1),('Books',1,'81',4),('Clothes',2,'24',4),('Equipment',3,'57',3),
('Furniture',4,'14',3),('Navigation',1,'41',3),('Recreation',2,'29',4),('Accounting',5,'35',5),
('Purchasing',5,'36',7),('Personnel',5,'37',9),('Marketing',5,'38',2)

select * from Department

--altering employeeId column name to manager id in department 
EXEC sp_rename 'Department.EmployeeId', 'ManagerId' , 'COLUMN'

select * from Employee

update Employee 
set Department_Name = 'Management' where Emp_id = 1

update Employee 
set Department_Name = 'Marketing' where Emp_id in (2,3,4)

update Employee 
set Department_Name = 'Accounting' where Emp_id = 5 or Emp_id = 6

update Employee 
set Department_Name = 'Purchasing' where Emp_id in (7,8)

update Employee 
set Department_Name = 'Personnel' where Emp_id = 9

update Employee 
set Department_Name = 'Navigation' where Emp_id = 10

update Employee 
set Department_Name = 'Books' where Emp_id = 11

update Employee 
set Department_Name = 'Clothes' where Emp_id in (12,13)

update Employee 
set Department_Name = 'Equipment' where Emp_id in (14,15)

update Employee 
set Department_Name = 'Furniture' where Emp_id = 16

update Employee 
set Department_Name = 'Recreation' where Emp_id = 17

select * from Employee

--inserting values to Sales table
Insert into Sales(SalesQuantity,ItemName,Department_Name)
Values(2,'Boots-snake proof','Clothes'),(1,'Pith Helmet','Clothes'),(1,'Sextant','Navigation'),
(3,'Hat-polar Explorer','Clothes'),(5,'Pith Helmet','Equipment'),(2,'Pocket Knife-Nile','Clothes'),
(3,'Pocket Knife-Nile','Recreation'),(1,'Compass','Navigation'),(2,'Geo positioning system','Navigation'),
(5,'Map Measure','Navigation')

Insert into Sales values(1,'Geo positioning system','Books'),(1,'Sextant','Books'),(3,'Pocket Knife-Nile','Books'),
(1,'Pocket Knife-Nile','Navigation'),(1,'Pocket Knife-Nile','Equipment'),(1,'Sextant','Clothes'),(1,'Sextant','Equipment'),
(1,'Sextant','Recreation'),(1,'Sextant','Furniture'),(1,'Pocket Knife-Nile','Furniture'),(1,'Exploring in 10 easy lessons','Books'),
(1,'How to win foreign friends','Books'),(1,'Compass','Books'),(1,'Pith Helmet','Books'),(1,'Elephant Polo stick','Recreation'),
(1,'Camel Saddle','Recreation')

select * from Sales

--Inserting values to item table
Insert into Item(Item_Name,ItemType,ItemColor)
Values('Pocket Knife-Nile','E','Brown')

--display each record of the table
select * from Item

Insert into Item Values('Pocket Knife-Avon','E','Brown')
Insert into Item Values('Compass','N',null),('Geo positioning system','N',null),
('Elephant Polo stick','R','Bamboo'),('Camel Saddle','R','Brown'), ('Sextant','N',null)

select * from Item

Insert into Item Values('Map Measure','N',null),('Boots-snake proof','C','Green'),
('Pith Helmet','C','Khaki'),('Hat-polar Explorer','C','White'), ('Exploring in 10 Easy Lessons','B',null),
('Hammock','F','Khaki'),('How to win Foreign Friends','B',null),('Map case','E','Brown'),('Safari Chair','F','Khaki'),
('Safari cooking kit','F','Khaki'),('Stetson','C','Black'),('Tent - 2 person','F','Khaki'),('Tent - 8 person','F','Khaki')

select * from Item
