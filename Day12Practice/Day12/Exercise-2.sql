-----EXERCISE-2------
-- 1. Total Present basic > 30000 grouped by department
SELECT * FROM dbo.tblEmployees
select emp.DepartmentCode,SUM(emp.PresentBasic) as BasicTotal
from dbo.tblEmployees emp
group by emp.DepartmentCode
having SUM(emp.PresentBasic)>30000
order by emp.DepartmentCode;

-- 2. Max, Min, Avg age by ServiceType, ServiceStatus, Centre
select emp.CentreCode,emp.ServiceType,emp.ServiceStatus,
CONVERT(varchar(10),MAX(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+'years '+
CONVERT(varchar(10),MAX(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+'months' as MAX_AGE,
CONVERT(varchar(10),MIN(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+'years '+
CONVERT(varchar(10),MIN(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+'months' as MIN_AGE,            
CONVERT(varchar(10),AVG(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+'years '+
CONVERT(varchar(10),AVG(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+'months' as AVG_AGE
from dbo.tblEmployees emp
group by emp.CentreCode,emp.ServiceType,emp.ServiceStatus
order by emp.CentreCode,emp.ServiceType,emp.ServiceStatus;

-- 3. Max, Min, Avg Service by ServiceType, Status, Centre
SELECT CentreCode, ServiceType, ServiceStatus,
       MAX(DATEDIFF(MONTH, DOJ, GETDATE())/12) AS MaxService_Yrs,
       MIN(DATEDIFF(MONTH, DOJ, GETDATE())/12) AS MinService_Yrs,
       AVG(DATEDIFF(MONTH, DOJ, GETDATE())/12.0) AS AvgService_Yrs
FROM dbo.tblEmployees
GROUP BY CentreCode, ServiceType, ServiceStatus
order by CentreCode,ServiceType,ServiceStatus;;

-- 4. Departments where total salary > 3 * avg salary
SELECT DepartmentCode
FROM dbo.tblEmployees
GROUP BY DepartmentCode
HAVING SUM(presentBasic) > 3 * AVG(PresentBasic);

-- 5. Departments with total salary > 2 * avg and max basic >= 3 * min basic
SELECT DepartmentCode
FROM dbo.tblEmployees
GROUP BY DepartmentCode
HAVING SUM(PresentBasic) > 2 * AVG(PresentBasic)
   AND MAX(PresentBasic) >= 3 * MIN(PresentBasic);

-- 6. Centers where max name length = 2 * min name length
SELECT CentreCode
FROM dbo.tblEmployees
GROUP BY CentreCode
HAVING MAX(LEN(Name)) >= 2 * MIN(LEN(Name));

-- 7. Max, Min, Avg Service in milliseconds
SELECT CentreCode, ServiceType, ServiceStatus,
       MAX(DATEDIFF(MILLISECOND, DOJ, GETDATE())) AS MaxService_ms,
       MIN(DATEDIFF(MILLISECOND, DOJ, GETDATE())) AS MinService_ms,
       AVG(DATEDIFF(MILLISECOND, DOJ, GETDATE())*1.0) AS AvgService_ms
FROM dbo.tblEmployees
GROUP BY CentreCode, ServiceType, ServiceStatus;

-- 8. Employees with leading/trailing spaces in name
SELECT *
FROM dbo.tblEmployees
WHERE Name <> LTRIM(RTRIM(Name));

-- 9. Employees with multiple spaces between name parts
SELECT *
FROM dbo.tblEmployees
WHERE Name LIKE '%  %';

-- 10. Trim spaces and fix spacing between words
SELECT EmployeeNumber,
       TRIM(REPLACE(REPLACE(REPLACE(Name, CHAR(9), ' '), CHAR(10), ' '), CHAR(13), ' ')) AS CleanedName
FROM dbo.tblEmployees;

-- 11. Max number of words in name
SELECT MAX(LEN(Name) - LEN(REPLACE(Name, ' ', '')) + 1) AS MaxWords
FROM dbo.tblEmployees;

-- 12. Name starts and ends with same char
SELECT *
FROM dbo.tblEmployees
WHERE LEFT(Name, 1) = RIGHT(Name, 1);

-- 13. First and second name starts with same char
SELECT *
FROM dbo.tblEmployees
WHERE LEFT(Name, 1) = SUBSTRING(Name, CHARINDEX(' ', Name) + 1, 1);

-- 14. All words in name start with same character
SELECT *
FROM dbo.tblEmployees
WHERE Name NOT LIKE '% %' -- one word
   OR PATINDEX('%[^ ]%', Name) = PATINDEX('%[^ ]%', REPLACE(Name, ' ', ''));

-- 15. Any word (not initials) starts and ends with same char
SELECT *
FROM dbo.tblEmployees
WHERE Name LIKE '% A%' OR Name LIKE '% E%' OR Name LIKE '% I%' OR Name LIKE '% O%' OR Name LIKE '% U%'; -- Sample logic

-- 16. Basic perfectly rounded to 100
	-- 1. Using ROUND
SELECT * FROM dbo.tblEmployees
WHERE PresentBasic = ROUND(PresentBasic, -2);
	-- 2. Using FLOOR
SELECT * FROM dbo.tblEmployees
WHERE PresentBasic = FLOOR(PresentBasic / 100.0) * 100;
	-- 3. Using MOD
SELECT * FROM dbo.tblEmployees
WHERE PresentBasic % 100 = 0;
	-- 4. Using CEILING
SELECT * FROM dbo.tblEmployees
WHERE PresentBasic = CEILING(PresentBasic / 100.0) * 100
  AND PresentBasic % 100 = 0;

-- 17. Departments where all employees have basic rounded to 100
SELECT DepartmentCode
FROM dbo.tblEmployees
GROUP BY DepartmentCode
HAVING COUNT(*) = SUM(CASE WHEN PresentBasic % 100 = 0 THEN 1 ELSE 0 END);

-- 18. Departments where no employee has basic rounded to 100
SELECT DepartmentCode
FROM dbo.tblEmployees
GROUP BY DepartmentCode
HAVING SUM(CASE WHEN PresentBasic % 100 = 0 THEN 1 ELSE 0 END) = 0;

-- 19. Eligibility date, bonus date, age at that time, weekday etc.
SELECT EmployeeNumber, Name,
       DATEADD(DAY, 15, DATEADD(MONTH, 3, DATEADD(YEAR, 1, DOJ))) AS EligibilityDate,
       EOMONTH(DATEADD(DAY, 15, DATEADD(MONTH, 3, DATEADD(YEAR, 1, DOJ)))) + 1 AS BonusDate,
       DATEDIFF(YEAR, DOB, EOMONTH(DATEADD(DAY, 15, DATEADD(MONTH, 3, DATEADD(YEAR, 1, DOJ)))) + 1) AS AgeYears,
       DATENAME(WEEKDAY, EOMONTH(DATEADD(DAY, 15, DATEADD(MONTH, 3, DATEADD(YEAR, 1, DOJ)))) + 1) AS WeekdayName,
       DATEPART(WEEK, EOMONTH(DATEADD(DAY, 15, DATEADD(MONTH, 3, DATEADD(YEAR, 1, DOJ)))) + 1) AS WeekOfYear,
       DATEPART(DAYOFYEAR, EOMONTH(DATEADD(DAY, 15, DATEADD(MONTH, 3, DATEADD(YEAR, 1, DOJ)))) + 1) AS DayOfYear
FROM dbo.tblEmployees;

-- 20. Bonus eligibility based on service and retirement rules (simplified logic)
SELECT *
FROM dbo.tblEmployees
WHERE (
    (ServiceType = 1 AND EmployeeType = 1 AND DATEDIFF(YEAR, DOJ, GETDATE()) >= 10 AND DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 60, DOB)) >= 15)
 OR (ServiceType = 1 AND EmployeeType = 2 AND DATEDIFF(YEAR, DOJ, GETDATE()) >= 12 AND DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 55, DOB)) >= 14)
 OR (ServiceType = 1 AND EmployeeType = 3 AND DATEDIFF(YEAR, DOJ, GETDATE()) >= 12 AND DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 55, DOB)) >= 12)
 OR (ServiceType IN (2,3,4) AND DATEDIFF(YEAR, DOJ, GETDATE()) >= 15 AND DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 65, DOB)) >= 20)
);

-- 21. Current date in all formats
SELECT 
    CONVERT(VARCHAR, GETDATE(), 1) AS Format1,
    CONVERT(VARCHAR, GETDATE(), 101) AS Format101,
    CONVERT(VARCHAR, GETDATE(), 3) AS Format3,
    CONVERT(VARCHAR, GETDATE(), 103) AS Format103,
    CONVERT(VARCHAR, GETDATE(), 120) AS ISOFormat;

-- 22. Employees with net pay < actual basic in any payment
SELECT emp.EmployeeNumber,
SUM
(CASE WHEN emp.TransValue=1 THEN emp.ActualAmount else -emp.ActualAmount END)
As ActualSalary,
SUM
(CASE WHEN emp.TransValue=1 THEN emp.Amount else -emp.Amount 
END)
As NetSalary
FROM dbo.tblPayEmployeeparamDetails emp
GROUP BY emp.EmployeeNumber,emp.NoteNumber
having SUM(CASE WHEN emp.TransValue=1 THEN emp.ActualAmount else -emp.ActualAmount END) > SUM(CASE WHEN emp.TransValue=1 THEN emp.Amount else -emp.Amount END)
order by emp.EmployeeNumber

