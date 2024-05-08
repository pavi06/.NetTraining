--create doctor table
create table Doctor(
id int identity(101,1) constraint pk_DocId primary key,
docName varchar(30),
age int,
phoneNumber varchar(20),
experience float,
specialization varchar(20),
qualification varchar(20),
)

--create patient table
create table Patient(
id int identity(1,1) constraint pk_PatientId primary key,
patientName varchar(30),
age int,
gender varchar(10),
contactAddress varchar(40),
phoneNumber varchar(20),
bloodGroup varchar(20),
)

--create appointment table
create table Appointment(
id int identity(1000,1) constraint  pk_AppointmentId primary key,
appointmentDateTime dateTime,
appointmentDescription varchar(50),
appointmentStatus varchar(30),
patientId int constraint fk_patientId references Patient(id),
doctorId int constraint fk_doctorId references Doctor(id),
)

select * from Doctor
select * from Patient
select * from Appointment

Insert  into Doctor Values('Shiva',35,'9756454653',8,'Cardiologist','MBBS PHD')

Insert  into Patient Values('Pavi',25,'Female','Gandhi Nagar, Chennai','8756553539','AB+ve')

Insert  into Appointment Values('2024-05-12','General Checkup','Not Completed',1,101)