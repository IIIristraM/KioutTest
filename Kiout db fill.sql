INSERT INTO [Kiout].[dbo].[Organizations] (Title, Inn) VALUES ('ЗАО Восход', '1254769132')
INSERT INTO [Kiout].[dbo].[Organizations] (Title, Inn) VALUES ('ОАО Петрович и компания', '7765845351')
INSERT INTO [Kiout].[dbo].[Organizations] (Title, Inn) VALUES ('ООО Окулист', '4512341784')
GO

INSERT INTO [Kiout].[dbo].[Сourse] (Title) VALUES ('Основы компьютерной безопасности')
INSERT INTO [Kiout].[dbo].[Сourse] (Title) VALUES ('Оптимизация налогооблагаемой базы')
GO

INSERT INTO [Kiout].[dbo].[Instructors] (FullName, Email) VALUES ('Петросян Е.В.', 'smeshnih@shutok.net')
INSERT INTO [Kiout].[dbo].[Instructors] (FullName, Email) VALUES ('Абрамович Р.А.', 'denegnet@nev.ru')
GO

INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Иванов И.И.', 1)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Петров П.П.', 1)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Сидоров С.С.', 1)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Малышев М.М.', 2)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Романов Р.Р.', 2)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Солдатов С.С.', 2)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Павлов И.А.', 3)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Козлов О.В.', 3)
INSERT INTO [Kiout].[dbo].[Employees] (FullName, OrganizationId) VALUES ('Скрепкин Л.М.', 3)
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