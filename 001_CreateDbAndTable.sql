USE master

IF (EXISTS (SELECT name 
FROM master.sys.databases 
WHERE ('[' + name + ']' = N'Tree'
OR name = N'Tree')))
BEGIN
	DROP DATABASE Tree
END

CREATE DATABASE Tree
GO

USE Tree
GO


CREATE TABLE Nodes(
	Id BIGINT NOT NULL IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	ParentId BIGINT,
	CONSTRAINT PK_Nodes_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Nodes_ParentId FOREIGN KEY (ParentId) REFERENCES Nodes(Id)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)

IF EXISTS (SELECT name FROM sys.objects  
      WHERE name = 'TR_NodesId_Update' AND type = 'TR')  
   DROP TRIGGER TR_NodesId_Update;  
GO  

-- create a trigger to update ParentId for children if parent node ID was updated
CREATE TRIGGER TR_NodeId_Update  
ON Nodes 
AFTER UPDATE   
AS   
IF (UPDATE (Id))  
BEGIN  
	SET NOCOUNT ON;
    UPDATE Nodes
		SET ParentId = inserted.Id
		FROM Nodes
		LEFT JOIN inserted ON Nodes.ParentId = inserted.Id 
END  
GO  

-- create a trigger to update ParentId for children if parent node was deleted
CREATE TRIGGER TR_Node_Delete  
ON Nodes 
AFTER DELETE   
AS    
BEGIN  
	SET NOCOUNT ON;
    UPDATE Nodes
    SET ParentId = NULL
    FROM Nodes
    INNER JOIN deleted ON Nodes.ParentId = deleted.Id
END  
GO  