select Employ.Empno, Name, Dept, Basic, 
LeaveHistory.LeaveId, LeaveStartDate, LeaveEndDate
from Employ INNER JOIN LeaveHistory 
ON Employ.Empno = LeaveHistory.EmpNo
--------------------------------------------------------------------------
select E.Empno, Name, Dept, Basic, 
LH.LeaveId, LeaveStartDate, LeaveEndDate
from Employ E INNER JOIN LeaveHistory LH 
ON E.Empno = Lh.EmpNo
--------------------------------------------------------------------------------
SELECT A.AgentId, FirstName, LastName, City, State,
       P.PolicyID, AppNumber, ModalPremium, AnnualPremium, PaymentModelId
FROM sqlpractice.dbo.Agent A
INNER JOIN sqlpractice.dbo.AgentPolicy AP ON A.AgentId = AP.AgentID
INNER JOIN sqlpractice.dbo.Policy P ON P.PolicyId = AP.PolicyID;

-------------------------------------------------------------------------------
-- Example for Left-Outer Join 


select E.Empno, Name, Dept, Basic, 
LH.LeaveId, LeaveStartDate, LeaveEndDate
from Employ E LEFT JOIN LeaveHistory LH 
ON E.Empno = Lh.EmpNo
-------------------------------------------------------------------------------
select A.AgentId, FirstName, LastName, City, State,
P.PolicyId, AppNumber, ModalPremium, AnnualPremium, PayMentModelID
from sqlpractice.dbo.Agent A LEFT JOIN sqlpractice.dbo.AgentPolicy AP ON 
A.AgentId = AP.AgentID 
LEFT JOIN sqlpractice.dbo.Policy P ON P.PolicyId = AP.PolicyID
-------------------------------------------------------------------------------

-- Example for Right-Outer Join

select E.Empno, Name, Dept, Basic, 
LH.LeaveId, LeaveStartDate, LeaveEndDate
from Employ E RIGHT JOIN LeaveHistory LH 
ON E.Empno = Lh.EmpNo

select A.AgentId, FirstName, LastName, City, State,
P.PolicyId, AppNumber, ModalPremium, AnnualPremium, PaymentModelID
from sqlpractice.dbo.Agent A RIGHT JOIN sqlpractice.dbo.AgentPolicy AP ON 
A.AgentId = AP.AgentID 
RIGHT JOIN sqlpractice.dbo.Policy P ON P.PolicyId = AP.PolicyID
-------------------------------------------------------------------------------

-- Example for Full outer Join

select A.AgentId, FirstName, LastName, City, State,
P.PolicyId, AppNumber, ModalPremium, AnnualPremium, PaymentModelID
from sqlpractice.dbo.Agent A FULL JOIN sqlpractice.dbo.AgentPolicy AP ON 
A.AgentId = AP.AgentID 
FULL JOIN  sqlpractice.dbo.Policy P ON P.PolicyId = AP.PolicyID

-------------------------------------------------------------------------------

-- Cross Join 

select * from sqlpractice.dbo.Agent cross join sqlpractice.dbo.AgentPolicy

select * from sqlpractice.dbo.Policy Cross Join sqlpractice.dbo.AgentPolicy