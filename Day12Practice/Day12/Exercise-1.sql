---EXERCISE-!-----
select * from dbo.tblEmployees
--Q1-query to Get a List of Employees who have a one part name---
SELECT Name
FROM dbo.tblEmployees
WHERE name NOT LIKE '% %';

--Q2-query to Get a List of Employees who have a three part name
SELECT Name
FROM dbo.tblEmployees
WHERE name NOT LIKE '% % % % % %';

--Q3-write a query to get a list of Employees who have a First Middle Or last name as Ram, and not any thing else
SELECT Name
FROM dbo.tblEmployees
WHERE 
    Name = 'Ram'
    OR name LIKE 'Ram %' AND name NOT LIKE 'Ram Ram%'
    OR name LIKE '% Ram' AND name NOT LIKE '% Ram Ram'
    OR name LIKE '% Ram %' 
        AND name NOT LIKE 'Ram Ram%' 
        AND name NOT LIKE '% Ram Ram'
        AND name NOT LIKE 'Ram Ram Ram';

SELECT 
  65 | 11     AS "65 OR 11",
  65 ^ 11     AS "65 XOR 11",
  65 & 11     AS "65 AND 11",
  (12 & 4) | (13 & 1) AS "(12 AND 4) OR (13 AND 1)",
  127 | 64    AS "127 OR 64",
  127 ^ 64    AS "127 XOR 64",
  127 ^ 128   AS "127 XOR 128",
  127 & 64    AS "127 AND 64",
  127 & 128   AS "127 AND 128";


-- Question: Write a query which returns data in all columns from the table dbo.tblCentreMaster

SELECT *
FROM dbo.tblCentreMaster;

-- Question: Write a query which gives employee types in the organization

SELECT DISTINCT EmployeeType
FROM dbo.tblEmployees
ORDER BY EmployeeType;


-- Query a: Return Name, FatherName, DOB where PresentBasic > 3000
SELECT * FROM dbo.tblEmployees
SELECT Name, FatherName, DOB
FROM dbo.tblEmployees
WHERE PresentBasic > 3000;
-- Query b: Return Name, FatherName, DOB where PresentBasic < 3000
SELECT Name, FatherName, DOB
FROM dbo.tblEmployees
WHERE PresentBasic < 3000;
-- Query c: Return Name, FatherName, DOB where PresentBasic is between 3000 and 5000
SELECT Name, FatherName, DOB
FROM dbo.tblEmployees
WHERE PresentBasic BETWEEN 3000 AND 5000;

-- 8.a Employees whose name ends with 'KHAN'
SELECT * FROM dbo.tblEmployees WHERE Name LIKE '%KHAN';

-- 8.b Employees whose name starts with 'CHANDRA'
SELECT * FROM dbo.tblEmployees WHERE Name LIKE 'CHANDRA%';

-- 8.c Employees with name 'RAMESH' and initial in range A-T
SELECT * FROM dbo.tblEmployees WHERE Name LIKE '[A-T].RAMESH';




