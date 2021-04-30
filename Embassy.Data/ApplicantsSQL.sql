IF object_id('applicant', 'U') is not null DROP TABLE applicant;
IF object_id('agency', 'U') is not null DROP TABLE agency;
IF object_id('payment', 'U') is not null DROP TABLE payment;
IF object_id('visa', 'U') is not null DROP TABLE visa;
GO
CREATE TABLE applicant (
	appl_id int primary key,
	appl_name varchar(200),
	appl_gender varchar(200),
	appl_email varchar(200),
	appl_income int,
	appl_birth date,
	appl_job nvarchar(200)
);
CREATE TABLE agency (
	agen_id int primary key,
	agen_name nvarchar(200) not null,
	agen_address nvarchar(200) not null,
	agen_email nvarchar(200) not null
	
);
CREATE TABLE payment (
	pay_id int primary key,
	 pay_appl_id int,
	  foreign key (pay_appl_id) references applicant(appl_id)  on delete cascade,
     pay_agen_id int,
	   foreign key (pay_agen_id) references agency(agen_id)  on delete cascade,
	pay_amount int,
	pay_ispayed varchar(200)	
);
CREATE TABLE visa (
	visa_id int primary key,
	visa_appl_id int,
	 foreign key (visa_appl_id) references applicant(appl_id)  on delete cascade,
	visa_type varchar(200),
	visa_duration int,
	visa_enddate date,
	visa_isapproved varchar(200)	
);
GO

INSERT INTO applicant VALUES (1, 'Arkagij Petrov','male','prostnov@gmail.com',5000,'1991-09-21','security manager');
INSERT INTO applicant VALUES (2, 'Anastasiya Konovalova','female','pegastu@rambler.ru',3500,'1990-01-30','creditor');
INSERT INTO applicant VALUES (3, 'Darina Kadurova','female','vseknyazh@gmail.com',4100,'1983-08-04','photografer');
INSERT INTO applicant VALUES (4, 'Alina Komarova','female','pop6790@yandex.ru',3900,'1995-09-11','pilot');
INSERT INTO applicant VALUES (5, 'Vyacheslav Petrushin','male','prest22@gmail.com',2800,'1987-04-24','editor');
INSERT INTO applicant VALUES (6, 'Tomas Lu','male','Lu1990@outlook.com',2950,'1990-11-10','barista');
INSERT INTO applicant VALUES (7, 'Kesha Bolbo','male','corrib21@gmail.com',9000,'1989-02-21','judge');
INSERT INTO applicant VALUES (8, 'Terence Orbe','male','Orbe33@outlook.com',1950,'1993-10-25','doctor');
INSERT INTO applicant VALUES (9, 'Lexi Grey','female','grey24@gmail.com',6000,'1990-12-21','surgeon');
INSERT INTO applicant VALUES (10, 'Stecy Lolins','female','stlol11@outlook.com',2300,'1986-05-08','actress');


INSERT INTO agency VALUES (1, 'PegasTouristic', 'Novosibirsk, Popov st., 22','pegastour@gmail.com');
INSERT INTO agency VALUES (2, 'AmediaTour', 'Afines, Hercules st., 29','amedtourist@gmail.com');
INSERT INTO agency VALUES (3, 'StarTravel', 'Stalingrad, Piterskaya st., 09','startravel@gmail.com');
INSERT INTO agency VALUES (4, 'CCUnated', 'Lesosibirsk, Karbusheva st., 33','CCUna@gmail.com');
INSERT INTO agency VALUES (5, 'TravelAround', 'Toronto, Brendon st., 20', 'Around22@gmail.com');
INSERT INTO agency VALUES (6, 'AhmadTravel', 'Kair, Khabibi st., 308','AhTravl@gmail.com');
INSERT INTO agency VALUES (7, 'PortalAsia', 'Almati, Tushmanbekov st., 210', 'AsiaTravel@outlook.com');


INSERT INTO payment VALUES (1,2,1, 50,'payed');
INSERT INTO payment VALUES (2,3,2, 100,'not payed');
INSERT INTO payment VALUES (3,1,3, 100,'payed');
INSERT INTO payment VALUES (4,4,7, 60,'not payed');
INSERT INTO payment VALUES (5,5,5, 130,'payed');
INSERT INTO payment VALUES (6,8,7, 67,'payed');
INSERT INTO payment VALUES (7,10,6, 60,'payed');
INSERT INTO payment VALUES (8,6,4, 40,'not payed');
INSERT INTO payment VALUES (9,7,5, 10,'payed');
INSERT INTO payment VALUES (10,9,5, 41,'payed');


INSERT INTO visa VALUES (1,2, 'X1',30,'2021-01-30','approved');
INSERT INTO visa VALUES (2,1, 'B2',90,'2021-02-28','approved') ;
INSERT INTO visa VALUES (3,4, 'B1',70,'2021-02-20',NULL) ;
INSERT INTO visa VALUES(4,5, 'D1',120,'2021-03-18','approved');
INSERT INTO visa VALUES (5,9, 'X2',80,'2021-02-10','approved');
INSERT INTO visa VALUES (6,10, 'B1',80,'2021-01-18',null) ;
INSERT INTO visa VALUES (7,7, 'B1',61,'2020-12-20','approved') ;
INSERT INTO visa VALUES(8,6, 'D1',190,'2021-05-10',null);
INSERT INTO visa VALUES(9,8, 'J2',78,'2021-02-15','approved');