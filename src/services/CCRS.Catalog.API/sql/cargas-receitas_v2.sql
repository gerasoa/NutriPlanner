
USE [MyMeals_9]
GO
BEGIN TRAN -- commit rollback

-- Inserir as Categorias
INSERT INTO [dbo].[Category] ( [Name], [Image])
VALUES
	('Bolos','bolos.jpg'),
	('Sobremesas','sobremesas.jpg'),
	('Sopas','sopas.jpg'),
	('Paes','paes.jpg');
GO

-- Inserir Níveis de Dificuldade
INSERT INTO [dbo].[Dificulty] ([Name], [Description])
VALUES
    ('Muito Fácil', 'Requer pouca ou nenhuma experiência.'),
    ('Fácil', 'Pode ser feito por iniciantes.'),
    ('Médio', 'Requer alguma experiência.'),
    ('Difícil', 'Para cozinheiros experientes.'),
    ('Muito Difícil', 'Requer habilidades avançadas.');
GO

-- Inserir as medidas
INSERT INTO [dbo].[Measure] ([UnitShort], [UnitLong], [CreatedDate])
VALUES 
    ('g', 'Grams', GETDATE()), -- Gramas
    ('ml', 'Millilitres', GETDATE()), -- Mililitros
    ('un', 'Units', GETDATE()), -- Unidades
    ('tbsp', 'Tablespoon', GETDATE()), -- Colher de sopa
    ('tsp', 'Teaspoon', GETDATE()); -- Colher de chá
GO

/**************************
***** Receita
**************************/
DECLARE @BoloId UNIQUEIDENTIFIER;
DECLARE @PaoDeQueijoId UNIQUEIDENTIFIER;
DECLARE @PudimId UNIQUEIDENTIFIER;

SET @BoloId = NEWID();
SET @PaoDeQueijoId= NEWID();
SET @PudimId = NEWID();


--DECLARE @BoloVerifiedById UNIQUEIDENTIFIER;
--DECLARE @PaoDeQueijoVerifiedById UNIQUEIDENTIFIER;
--DECLARE @PudimVerifiedById UNIQUEIDENTIFIER;

--SET @BoloVerifiedById = NEWID();
--SET @PaoDeQueijoVerifiedById= NEWID();
--SET @PudimVerifiedById = NEWID();
--SELECT @BoloId AS Guid1, @PaoDeQueijoId AS Guid2, @PudimId AS Guid3;

--BEGIN TRAN


INSERT INTO [dbo].[Recipes] ([Id],[CategoryId],[Name],[ReadyInMinutes],[Servings],[Image],[DifficultyId],[Summary],[PublishedBy],[CreatedDate],[Active],[Verified])
     VALUES
			(@BoloId,(SELECT [ID] FROM [dbo].[Category] WHERE [Name] = 'Bolos'),'Bolo de laranja',50,10,'bolo.jpg',(SELECT [ID] FROM [dbo].[Dificulty] WHERE [Name] = 'Fácil'),'Um bolo de laranja fofinho e delicioso, com sabor cítrico marcante e cobertura de calda de laranja.',0,GETDATE(),1,1),
			(@PaoDeQueijoId,(SELECT [ID] FROM [dbo].[Category] WHERE [Name] = 'Paes'),'Pão de Queijo',30,20,'pao-de-queijo.jpg',(SELECT [ID] FROM [dbo].[Dificulty] WHERE [Name] = 'Médio'),'A tradicional receita mineira de pão de queijo, crocante por fora e macio por dentro. Perfeito para qualquer ocasião.',0,GETDATE(),1,1),
			(@PudimId,(SELECT [ID] FROM [dbo].[Category] WHERE [Name] = 'Sobremesas'),'Pudim de leite',30,8,'pudim.jpg',(SELECT [ID] FROM [dbo].[Dificulty] WHERE [Name] = 'Fácil'),'O clássico pudim de leite condensado, com textura cremosa e calda caramelizada. Uma sobremesa que agrada a todos.',0,GETDATE(),1,1);


/**************************
***** Feedback
**************************/
INSERT INTO [dbo].[Feedback] (Id, UserId, RecipeId, Stars, Comment, Image, CreatedDate)
	VALUES
			(NEWID(), NEWID(), @BoloId, 5, 'Gostei muito, mas muito demorado', 'image-from-user-bolo.jpg', GETDATE()),
			(NEWID(), NEWID(), @PaoDeQueijoId, 3, 'Adorei, a familia toda amou!', 'image-from-user-pao.jpg', GETDATE()),
			(NEWID(), NEWID(), @PudimId, 4, 'Poderia ser melhor', 'image-from-user-pudim.jpg', GETDATE()),
			(NEWID(), NEWID(), @PudimId, 5, 'Maravilhoso, farei outras vezes', 'image-from-user-pudim.jpg', GETDATE()),
			(NEWID(), NEWID(), @PudimId, 5, 'A familia amou!', 'image-from-user-pudim.jpg', GETDATE());


/**************************
***** DirectionsGroup
**************************/
DECLARE @DGBoloId UNIQUEIDENTIFIER;
DECLARE @DGPaoDeQueijoId UNIQUEIDENTIFIER;
DECLARE @DGPudimId UNIQUEIDENTIFIER;

SET @DGBoloId = NEWID();
SET @DGPaoDeQueijoId= NEWID();
SET @DGPudimId = NEWID();

INSERT INTO [dbo].[DirectionsGroup] (Id, Name, OrderNumber, CreatedDate, RecipeId)
	VALUES
			(@DGBoloId, 'Massa do bolo', 1, GETDATE(), @BoloId),
			(@DGPaoDeQueijoId, 'Massa do pao de queijo', 1, GETDATE(), @PaoDeQueijoId),
			(@DGPudimId, 'Massa do pudim', 1, GETDATE(), @PudimId);


/**************************
***** Ingredients
**************************/
INSERT INTO [dbo].[Ingredient] ([Id], [Name], [Quantity], [MeasureId], [CreatedDate], [DirectionsGroupId])
VALUES (NEWID(), 'Polvilho doce', 500, NULL, GETDATE(), @DGPaoDeQueijoId),
       (NEWID(), 'Queijo Minas', 300, NULL, GETDATE(), @DGPaoDeQueijoId),
       (NEWID(), 'Ovos', 3, NULL, GETDATE(), @DGPaoDeQueijoId),
       (NEWID(), 'Óleo', 100, NULL, GETDATE(), @DGPaoDeQueijoId),
       (NEWID(), 'Leite', 250, NULL, GETDATE(), @DGPaoDeQueijoId),
       (NEWID(), 'Sal', 1, NULL, GETDATE(), @DGPaoDeQueijoId);

INSERT INTO [dbo].[Ingredient] ([Id], [Name], [Quantity], [MeasureId], [CreatedDate], [DirectionsGroupId])
VALUES (NEWID(), 'Farinha de trigo', 300, NULL, GETDATE(), @DGBoloId),
       (NEWID(), 'Açúcar', 200, NULL, GETDATE(), @DGBoloId),
       (NEWID(), 'Ovos', 4, NULL, GETDATE(), @DGBoloId),
       (NEWID(), 'Suco de laranja', 200, NULL, GETDATE(), @DGBoloId),
       (NEWID(), 'Fermento em pó', 1, NULL, GETDATE(), @DGBoloId),
       (NEWID(), 'Manteiga', 100, NULL, GETDATE(), @DGBoloId);

INSERT INTO [dbo].[Ingredient] ([Id], [Name], [Quantity], [MeasureId], [CreatedDate], [DirectionsGroupId])
VALUES (NEWID(), 'Leite condensado', 395, NULL, GETDATE(), @DGPudimId),
       (NEWID(), 'Leite', 500, NULL, GETDATE(), @DGPudimId),
       (NEWID(), 'Ovos', 4, NULL, GETDATE(), @DGPudimId),
       (NEWID(), 'Açúcar', 150, NULL, GETDATE(), @DGPudimId),
       (NEWID(), 'Água', 50, NULL, GETDATE(), @DGPudimId);


/**************************
***** Atualiza as unidade de medida
**************************/
UPDATE [dbo].[Ingredient]
SET [MeasureId] = (SELECT [Id] FROM [dbo].[Measure] WHERE [UnitShort] = 'g')
WHERE [Name] IN ('Polvilho doce', 'Queijo Minas', 'Farinha de trigo', 'Açúcar', 'Manteiga', 'Leite condensado', 'Açúcar');

UPDATE [dbo].[Ingredient]
SET [MeasureId] = (SELECT [Id] FROM [dbo].[Measure] WHERE [UnitShort] = 'ml')
WHERE [Name] IN ('Óleo', 'Leite', 'Suco de laranja', 'Água');

UPDATE [dbo].[Ingredient]
SET [MeasureId] = (SELECT [Id] FROM [dbo].[Measure] WHERE [UnitShort] = 'un')
WHERE [Name] IN ('Ovos');

UPDATE [dbo].[Ingredient]
SET [MeasureId] = (SELECT [Id] FROM [dbo].[Measure] WHERE [UnitShort] = 'tbsp')
WHERE [Name] IN ('Fermento em pó', 'sal');



/**************************
***** Passos para a receita - Directions
**************************/
INSERT INTO [dbo].[Directions] 
    (Id, OrderNumber, Step, CreatedDate, DirectionsGroupId)
VALUES
    (NEWID(), 1, 'Pré-aqueça o forno a 180°C (350°F).', GETDATE(), @DGBoloId),
    (NEWID(), 2, 'Em uma tigela grande, misture a farinha, o açúcar, o fermento e o sal.', GETDATE(), @DGBoloId),
    (NEWID(), 3, 'Em outra tigela, misture os ovos, o suco de laranja, o óleo e as raspas de laranja.', GETDATE(), @DGBoloId),
    (NEWID(), 4, 'Despeje a mistura líquida sobre os ingredientes secos e misture bem até obter uma massa homogênea.', GETDATE(), @DGBoloId),
    (NEWID(), 5, 'Unte e enfarinhe uma forma de bolo.', GETDATE(), @DGBoloId),
    (NEWID(), 6, 'Despeje a massa na forma preparada.', GETDATE(), @DGBoloId),
    (NEWID(), 7, 'Asse por cerca de 30-35 minutos ou até que um palito inserido no centro do bolo saia limpo.', GETDATE(), @DGBoloId),
    (NEWID(), 8, 'Enquanto o bolo assa, prepare a calda misturando o suco de laranja e o açúcar em uma panela, e leve ao fogo médio até o açúcar dissolver.', GETDATE(), @DGBoloId),
    (NEWID(), 9, 'Retire o bolo do forno, deixe esfriar por 10 minutos e desenforme. Regue o bolo ainda morno com a calda de laranja.', GETDATE(), @DGBoloId),
    (NEWID(), 10, 'Sirva o bolo de laranja em fatias, acompanhado de chá ou café.', GETDATE(), @DGBoloId);

INSERT INTO [dbo].[Directions] 
    (Id, OrderNumber, Step, CreatedDate, DirectionsGroupId)
VALUES
    (NEWID(), 1, 'Preaqueça o forno a 180°C.', GETDATE(), @DGPaoDeQueijoId),
    (NEWID(), 2, 'Em uma panela, ferva o leite, o óleo e o sal.', GETDATE(), @DGPaoDeQueijoId),
    (NEWID(), 3, 'Despeje a mistura quente sobre o polvilho em uma tigela grande e misture bem.', GETDATE(), @DGPaoDeQueijoId),
    (NEWID(), 4, 'Deixe esfriar um pouco e adicione os ovos, um de cada vez, misturando bem após cada adição.', GETDATE(), @DGPaoDeQueijoId),
    (NEWID(), 5, 'Acrescente o queijo ralado e misture até obter uma massa homogênea.', GETDATE(), @DGPaoDeQueijoId),
    (NEWID(), 6, 'Molde bolinhas com a massa e coloque em uma assadeira untada.', GETDATE(), @DGPaoDeQueijoId),
    (NEWID(), 7, 'Asse por 20-25 minutos ou até que fiquem douradas.', GETDATE(), @DGPaoDeQueijoId),
    (NEWID(), 8, 'Retire do forno e sirva quente.', GETDATE(), @DGPaoDeQueijoId);

INSERT INTO [dbo].[Directions] 
    (Id, OrderNumber, Step, CreatedDate, DirectionsGroupId)
VALUES
    (NEWID(), 1, 'Pré-aqueça o forno a 180°C.', GETDATE(), @DGPudimId),
    (NEWID(), 2, 'Derreta o açúcar em uma panela até formar um caramelo dourado. Despeje o caramelo em uma forma de pudim, cobrindo todo o fundo. Reserve.', GETDATE(), @DGPudimId),
    (NEWID(), 3, 'No liquidificador, bata os ovos, o leite condensado e o leite até obter uma mistura homogênea.', GETDATE(), @DGPudimId),
    (NEWID(), 4, 'Despeje a mistura na forma caramelizada.', GETDATE(), @DGPudimId),
    (NEWID(), 5, 'Cubra a forma com papel alumínio e coloque-a em banho-maria.', GETDATE(), @DGPudimId),
    (NEWID(), 6, 'Asse em forno pré-aquecido por aproximadamente 1 hora e 30 minutos, ou até que o pudim esteja firme.', GETDATE(), @DGPudimId),
    (NEWID(), 7, 'Retire o pudim do forno e deixe esfriar completamente. Leve à geladeira por no mínimo 4 horas.', GETDATE(), @DGPudimId),
    (NEWID(), 8, 'Desenforme o pudim em um prato e sirva.', GETDATE(), @DGPudimId);