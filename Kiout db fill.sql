INSERT INTO [Kiout].[dbo].[Organizations] (Title, Inn) VALUES ('��� ������', '1254769132')
INSERT INTO [Kiout].[dbo].[Organizations] (Title, Inn) VALUES ('��� �������� � ��������', '7765845351')
INSERT INTO [Kiout].[dbo].[Organizations] (Title, Inn) VALUES ('��� �������', '4512341784')
GO

INSERT INTO [Kiout].[dbo].[�ourse] (Title) VALUES ('������ ������������ ������������')
INSERT INTO [Kiout].[dbo].[�ourse] (Title) VALUES ('����������� ���������������� ����')
GO

INSERT INTO [Kiout].[dbo].[Instructors] (FullName, Email) VALUES ('�������� �.�.', 'smeshnih@shutok.net')
INSERT INTO [Kiout].[dbo].[Instructors] (FullName, Email) VALUES ('��������� �.�.', 'denegnet@nev.ru')
GO

INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('������ �.�.', 1)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('������ �.�.', 1)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('������� �.�.', 1)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('������� �.�.', 2)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('������� �.�.', 2)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('�������� �.�.', 2)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('������ �.�.', 3)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('������ �.�.', 3)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('�������� �.�.', 3)
GO

UPDATE [Kiout].[dbo].[Organizations]
SET [InstructorId] = 1 
FROM [Kiout].[dbo].[Organizations]
WHERE [Id] = 1 or 
      [Id] = 3

UPDATE [Kiout].[dbo].[Organizations]
SET [InstructorId] = 2 
FROM [Kiout].[dbo].[Organizations]
WHERE [Id] = 2
GO