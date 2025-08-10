create view vwEmploy
AS
	select * from wiprojuly.dbo.Employ 
GO

select * from vwEmploy 
GO

create view vwEmployReport
AS
	select Empno, Name, Gender, Dept, Basic, dbo.Fncommission(Basic) 'Commission',
			Basic - dbo.Fncommission(Basic) 'Take Home' from wiprojuly.dbo.Employ 
GO

select * from vwEmployReport 
GO

create view vwAgentPolicy 
AS
select 
	A.AgentId, FirstName, LastName, City, State,
		P.PolicyId, AppNumber, AppDate, ModalPremium, AnnualPremium
from sqlpractice.dbo.Agent A INNER JOIN sqlpractice.dbo.AgentPolicy AP
ON A.AgentId = AP.AgentID 
INNER JOIN sqlpractice.dbo.Policy P 
ON P.PolicyId = AP.PolicyID
GO

select * from vwAgentPolicy 
GO