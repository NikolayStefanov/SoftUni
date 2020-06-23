--EXERCISE 14

CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY NOT NULL,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
OldSum DECIMAL(18,4) NOT NULL,
NewSum DECIMAL(18,4) 
)

CREATE TRIGGER tr_InsertAccInfo ON Accounts FOR UPDATE
AS
DECLARE @OldSum DECIMAL(18,4) = (SELECT Balance FROM deleted)
DECLARE @NewSum DECIMAL(18,4) = (SELECT Balance FROM inserted)
DECLARE @AccountId INT = (SELECT Id FROM inserted)

INSERT INTO Logs(AccountId, OldSum, NewSum)
VALUES(@AccountId, @OldSum, @NewSum)

 UPDATE Accounts
 SET Balance += 15
 WHERE Id= 1

SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs

--EXERCISE 15
CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
[Subject] NVARCHAR(MAX) NOT NULL,
Body NVARCHAR(MAX) NOT NULL
)

CREATE TRIGGER tr_InsertNewEmails on Logs FOR INSERT
AS
	DECLARE @AccountId INT = (SELECT TOP(1) AccountId FROM inserted)
	DECLARE @Subject NVARCHAR(MAX) =  'Balance change for account: '+ CAST(@AccountId AS VARCHAR(10)) 
	DECLARE @OldSum DECIMAL (18,2)= (SELECT TOP(1) OldSum FROM inserted)
	DECLARE @NewSum DECIMAL (18,2)= (SELECT TOP(1) NewSum FROM inserted)
	DECLARE @Body NVARCHAR(MAX) = 'On ' + FORMAT(GETDATE(), 'MMM dd yyyy hh:mm tt') + ' your balance was changed from '+ CAST(@OldSum AS VARCHAR(20))+ ' to '+ CAST(@NewSum AS VARCHAR(20)) + '.'

	INSERT INTO NotificationEmails(Recipient, Subject, Body)
	VALUES(@AccountId, @Subject, @Body)

SELECT * FROM NotificationEmails

--EXERCISE 16
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
	DECLARE @money DECIMAL(18,4) = ABS(@MoneyAmount)
	IF(@MoneyAmount < 0)
	BEGIN
	ROLLBACK;
	THROW 50003, 'Money amount cannot be zero or less!', 1;
	RETURN
	END

	IF (EXISTS(SELECT Id FROM Accounts WHERE @AccountId NOT IN (SELECT Id FROM Accounts)))
	BEGIN
	ROLLBACK;
	THROW 50004, 'Invalid Account ID!', 1;
	RETURN
	END

	UPDATE Accounts
	SET Balance+= @money
	WHERE @AccountId = Id

--EXERCISE 17
CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	IF(@MoneyAmount < 0)
	BEGIN
	ROLLBACK;
	THROW 50003, 'Money amount cannot be zero or less!', 1;
	RETURN
	END

	IF (EXISTS(SELECT Id FROM Accounts WHERE @AccountId NOT IN (SELECT Id FROM Accounts)))
	BEGIN
	ROLLBACK;
	THROW 50004, 'Invalid Account ID!', 1;
	RETURN
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

COMMIT
GO

SELECT * FROM Accounts
EXEC usp_WithdrawMoney 3, 1000000
GO
--EXERCISE 18
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @SenderId,  @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
COMMIT
GO

EXEC usp_TransferMoney 3, 15 ,1000000