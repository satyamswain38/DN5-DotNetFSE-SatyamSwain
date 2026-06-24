-- Exercise 1: Create a Stored Procedure

DELIMITER //

CREATE PROCEDURE GetAllEmployees()
BEGIN
    SELECT * FROM Employees;
END //

DELIMITER ;

-- Exercise 5: Return Data from a Stored Procedure

CALL GetAllEmployees();