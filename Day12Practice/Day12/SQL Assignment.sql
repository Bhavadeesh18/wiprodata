CREATE DATABASE SQLAssignment
GO

CREATE TABLE DOCTOR_MASTER (
    doctor_id VARCHAR(15) PRIMARY KEY,       
    doctor_name VARCHAR(15) NOT NULL,        
    Department VARCHAR(15) NOT NULL               
);

INSERT INTO DOCTOR_MASTER (doctor_id, doctor_name, Department)
VALUES	('D0001', 'Raj', 'ENT'),
		('D0002', 'Vignan', 'ENT'),
		('D0003', 'Smrita', 'Eye'),
		('D0004', 'Alekhya', 'Surgery'),
		('D0005', 'Dhanu', 'Surgery'),
		('D0006', 'Ishika', 'Surgery');

SELECT * FROM DOCTOR_MASTER;


DROP TABLE IF EXISTS ROOM;

CREATE TABLE ROOM (
    room_no VARCHAR(15) PRIMARY KEY,       
    room_type VARCHAR(15) NOT NULL,        
    Status VARCHAR(15) NOT NULL
);

INSERT INTO ROOM (room_no, room_type, Status)
VALUES
('R101', 'General', 'Available'),
('R102', 'General', 'Available'),
('R103', 'General', 'Available'),
('R104', 'ICU', 'Occupied'),
('R105', 'Private', 'Available'),
('R106', 'ICU', 'Available'),
('R107', 'General', 'Available'),
('R108', 'Private', 'Available');


SELECT * FROM ROOM;




CREATE TABLE PATIENT_MASTER (
    pid VARCHAR(15) PRIMARY KEY,             
    name VARCHAR(15) NOT NULL,
    age INT NOT NULL,
    weight INT NOT NULL,
    gender VARCHAR(10) NOT NULL,
    address VARCHAR(50) NOT NULL,
    phoneno VARCHAR(10) NOT NULL,
    disease VARCHAR(50) NOT NULL,
    doctor_id VARCHAR(15) NOT NULL,
    FOREIGN KEY (doctor_id) REFERENCES DOCTOR_MASTER(doctor_id)
);

INSERT INTO PATIENT_MASTER
(pid, name, age, weight, gender, address, phoneno, disease, doctor_id)
VALUES
('P001', 'Anil', 45, 70, 'Male', 'Hyderabad', '9876543210', 'Fever', 'D0001'),
('P002', 'Sneha', 30, 60, 'Female', 'Delhi', '9876509876', 'Cough', 'D0002'),
('P003', 'Ravi', 50, 75, 'Male', 'Chennai', '9876512345', 'Diabetes', 'D0003'),
('P004', 'Lakshmi', 28, 55, 'Female', 'Bangalore', '9876523456', 'Asthma', 'D0001'),
('P005', 'Rahul', 35, 68, 'Male', 'Mumbai', '9876534567', 'COVID-19', 'D0004'),
('P006', 'Priya', 40, 58, 'Female', 'Pune', '9876545678', 'Typhoid', 'D0002'),
('P007', 'Kiran', 33, 72, 'Male', 'Kolkata', '9876556789', 'Migraine', 'D0003'),
('P008', 'Meena', 22, 52, 'Female', 'Jaipur', '9876567890', 'Allergy', 'D0001');

SELECT * FROM PATIENT_MASTER;



DROP TABLE IF EXISTS ROOM_ALLOCATION;

CREATE TABLE ROOM_ALLOCATION (
    room_no VARCHAR(15) NOT NULL,
    pid VARCHAR(15) NOT NULL,
    admission_date DATE NOT NULL,
    release_date DATE,
    CONSTRAINT FK_ROOM FOREIGN KEY (room_no) REFERENCES ROOM(room_no),
    CONSTRAINT FK_PATIENT FOREIGN KEY (pid) REFERENCES PATIENT_MASTER(pid)
);


INSERT INTO ROOM_ALLOCATION (room_no, pid, admission_date, release_date) VALUES
('R101', 'P001', '2025-01-15', '2025-01-20'),
('R102', 'P002', '2025-07-02', '2025-07-06'),
('R103', 'P003', '2025-07-03', '2025-07-08'),
('R104', 'P004', '2025-07-04', NULL),
('R105', 'P005', '2025-07-05', '2025-07-10'),
('R106', 'P006', '2025-07-06', '2025-07-09'),
('R107', 'P007', '2025-07-07', NULL),
('R108', 'P008', '2025-07-08', '2025-07-12');


SELECT * FROM ROOM_ALLOCATION;



-----Query1-Display the patients who were admitted in the month of january.----
SELECT *
FROM PATIENT_MASTER
WHERE pid IN (
    SELECT pid
    FROM ROOM_ALLOCATION
    WHERE MONTH(admission_date) = 1
);


--Query2--Display the female patient who is not suffering from ashma

SELECT *
FROM PATIENT_MASTER
WHERE gender = 'Female'
  AND disease !='Asthma';


--Query3--Count the number of male and female patients.

SELECT gender, COUNT(*) AS count
FROM PATIENT_MASTER
GROUP BY gender;

--Query5--Display the room_no which was never allocated to any patient.

SELECT room_no
FROM ROOM
WHERE room_no NOT IN (
    SELECT room_no
    FROM ROOM_ALLOCATION
);
---OR---
SELECT r.room_no
FROM ROOM r
LEFT JOIN ROOM_ALLOCATION ra
ON r.room_no=ra.room_no
WHERE ra.room_no IS NULL;

--Query-6---Display the room_no, room_type which are allocated more than once.

SELECT * FROM ROOM;
SELECT * FROM ROOM_ALLOCATION;

SELECT room_no,
       (SELECT room_type FROM ROOM WHERE ROOM.room_no = RA.room_no) AS room_type,
       COUNT(*) AS allocation_count
FROM ROOM_ALLOCATION RA
GROUP BY room_no
HAVING COUNT(*) > 1;
