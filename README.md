# MarshfieldTimeClockV1.2

// Selects all necessary dates and sums time worked for a given day
SELECT DateIn, SUM(HoursWorked) AS Total_Time
FROM Log_Table 
WHERE EmployeeID = 'paul.rottmund' AND Month(DateIn) = Month(getdate()) AND Month(DateOut) = Month(getdate())
GROUP BY Log_Table.DateIn

//Returns WorkID and Role for given user
SELECT [Role], WorkID
FROM Employee_Role
JOIN Employee ON Employee_Role.EmployeeNumID = Employee.EmployeeNumID
WHERE Employee.EmployeeID = 'rogina.totten'

// Query for knowing if user can clock in or out
SELECT DateIn, DateOut, Log_Table.PunchID, Log_Table.WorkID
FROM Log_Table
INNER JOIN (
	SELECT MAX(PunchID) AS PunchID
	FROM Log_Table)
[user] ON Log_Table.PunchID = [user].PunchID
WHERE EmployeeID = 'paul.rottmund'