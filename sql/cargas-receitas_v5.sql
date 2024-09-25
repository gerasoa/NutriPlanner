USE [MyMeals]

-- ======================================
-- Limpa as tabelas e reinicia os indices
-- ======================================

DBCC CHECKIDENT ('Feedbacks', RESEED, 0);
DBCC CHECKIDENT ('IngredientDirections', RESEED, 0);
DBCC CHECKIDENT ('IngredientMeasures', RESEED, 0);
DBCC CHECKIDENT ('RecipeDirections', RESEED, 0);
DBCC CHECKIDENT ('Recipes', RESEED, 0);
DBCC CHECKIDENT ('Ingredients', RESEED, 0);
DBCC CHECKIDENT ('Measures', RESEED, 0);
DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('Difficulties', RESEED, 0);

DELETE FROM Feedbacks;
DELETE FROM IngredientDirections;
DELETE FROM IngredientMeasures;
DELETE FROM Directions;
DELETE FROM RecipeDirections;
DELETE FROM Recipes;
DELETE FROM Ingredients;
DELETE FROM Measures;
DELETE FROM Categories;
DELETE FROM Difficulties;




-- ========================================
-- Inser��o de dados nas tabelas de dominio
-- ========================================

-- 1. Inserir dificuldades
INSERT INTO Difficulties (Name, Description, CreatedAt) VALUES
('Muito F�cil', 'Prepara��es muito simples', GETDATE()),
('F�cil', 'Requer pouca habilidade', GETDATE()),
('M�dio', 'N�vel intermedi�rio de dificuldade', GETDATE()),
('Dif�cil', 'Requer habilidade avan�ada', GETDATE()),
('Muito Dif�cil', 'Prepara��es complexas e desafiadoras', GETDATE());

-- 2. Inserir categorias
INSERT INTO Categories (Name, Image, CreatedAt) VALUES
('P�es e Salgados', 'pao_salgado.jpg', GETDATE()),
('Bolos e Tortas', 'bolo_torta.jpg', GETDATE()),
('Doces', 'doces.jpg', GETDATE()),
('Bebidas', 'bebidas.jpg', GETDATE()),
('Lanches', 'lanches.jpg', GETDATE());

-- 3. Inserir medidas (apenas as necess�rias)
INSERT INTO Measures (UnitShort, UnitLong, CreatedAt) VALUES
('g', 'grama', GETDATE()),
('kg', 'quilograma', GETDATE()),
('ml', 'mililitro', GETDATE()),
('L', 'litro', GETDATE()),
('un', 'unidade', GETDATE()),
('x�cara', 'x�cara de ch�', GETDATE());

DECLARE @PaoDeQueijoId INT, @BoloDeLaranjaId INT, @PudimId INT;
DECLARE @MassaPaoDeQueijoId INT, @MassaBoloLaranjaId INT, @CarameloPudimId INT, @MassaPudimId INT;

-- ====================
-- Inser��o de Receitas
-- ====================
INSERT INTO Recipes (Name, ReadyInMinutes, Servings, Image, Summary, PublishedBy, CreatedAt, Active, Verified, CategoryId, DifficultyId) VALUES
('P�o de Queijo', 60, 10, 'pao_de_queijo.jpg', 'Tradicional receita brasileira de p�o de queijo.', 1, GETDATE(), 1, 1, 1, 2),
('Bolo de Laranja', 90, 12, 'bolo_de_laranja.jpg', 'Um bolo de laranja fofinho e delicioso.', 1, GETDATE(), 1, 1, 2, 3),
('Pudim de Leite Condensado', 120, 8, 'pudim.jpg', 'Um pudim cremoso de leite condensado com calda de caramelo.', 1, GETDATE(), 1, 1, 3, 3);

-- Obtenha os IDs das receitas
SELECT @PaoDeQueijoId = Id FROM Recipes WHERE Name = 'P�o de Queijo';
SELECT @BoloDeLaranjaId = Id FROM Recipes WHERE Name = 'Bolo de Laranja';
SELECT @PudimId = Id FROM Recipes WHERE Name = 'Pudim de Leite Condensado';



-- ====================
-- Inser��o na "tabela da juncao" RecipeDirections
-- ====================
INSERT INTO RecipeDirections (Name, OrderNumber, CreatedAt, RecipeId) VALUES
('Massa do pao de queijo', 1, GETDATE(), @PaoDeQueijoId),
('Massa do bolo de laranja', 1, GETDATE(), @BoloDeLaranjaId),
('Caramelo do pudim', 1, GETDATE(), @PudimId),
('Massa do pudim', 2, GETDATE(), @PudimId);

-- Obtenha os IDs das RecipeDirections
SELECT @MassaPaoDeQueijoId = Id FROM RecipeDirections WHERE Name = 'Massa do pao de queijo';
SELECT @MassaBoloLaranjaId = Id FROM RecipeDirections WHERE Name = 'Massa do bolo de laranja';
SELECT @CarameloPudimId = Id FROM RecipeDirections WHERE Name = 'Caramelo do pudim';
SELECT @MassaPudimId = Id FROM RecipeDirections WHERE Name = 'Massa do pudim';


-- ====================
-- Inser��o dos passos da receita
-- ====================
-- @MassaPaoDeQueijoId
INSERT INTO [dbo].[Directions](OrderNumber, Step, CreatedAt, RecipeDirectionId) VALUES
(1,  'Pr�-aque�a o forno a 180�C.', GETDATE(), @MassaPaoDeQueijoId),
(2,  'Misture os ingredientes secos: farinha de queijo, fermento em p� e sal.', GETDATE(), @MassaPaoDeQueijoId),
(3,  'Bata os ovos em uma tigela separada.', GETDATE(), @MassaPaoDeQueijoId),
(4,  'Misture os ingredientes l�quidos: adicione o leite e o �leo aos ovos batidos.', GETDATE(), @MassaPaoDeQueijoId),
(5,  'Combine os ingredientes secos e l�quidos: adicione a mistura de ovos � mistura de farinha e mexa at� ficar homog�neo.', GETDATE(), @MassaPaoDeQueijoId),
(6,  'Adicione o queijo ralado � massa e misture bem.', GETDATE(), @MassaPaoDeQueijoId),
(7,  'Coloque colheradas da massa em uma assadeira untada ou forrada com papel manteiga.', GETDATE(), @MassaPaoDeQueijoId),
(8,  'Asse no forno por aproximadamente 20-25 minutos ou at� que os p�es estejam dourados e crescidos.', GETDATE(), @MassaPaoDeQueijoId)

-- @MassaBoloLaranjaId
INSERT INTO [dbo].[Directions]( OrderNumber, Step, CreatedAt, RecipeDirectionId) VALUES
(1,'Preaque�a o forno: Preaque�a o forno a 180�C (350�F).', GETDATE(), @MassaBoloLaranjaId),
(2,'Prepare a forma: Unte e enfarinhe uma forma de bolo ou coloque papel manteiga no fundo.', GETDATE(), @MassaBoloLaranjaId),
(3,'Misture os ingredientes secos: Em uma tigela, peneire a farinha, o fermento em p� e o sal. Reserve.', GETDATE(), @MassaBoloLaranjaId),
(4,'Bata a manteiga e o a��car: Em uma tigela grande, bata a manteiga e o a��car at� obter um creme claro e fofo.', GETDATE(), @MassaBoloLaranjaId),
(5,'Adicione os ovos: Adicione os ovos um a um, batendo bem ap�s cada adi��o.', GETDATE(), @MassaBoloLaranjaId),
(6,'Incorpore o suco e as raspas de laranja: Adicione o suco de laranja e as raspas de laranja � mistura. Misture bem.', GETDATE(), @MassaBoloLaranjaId),
(7,'Combine os ingredientes secos: Gradualmente, adicione os ingredientes secos � mistura de manteiga e a��car, mexendo at� incorporar tudo.', GETDATE(), @MassaBoloLaranjaId),
(8,'Despeje na forma: Despeje a massa na forma preparada.', GETDATE(), @MassaBoloLaranjaId),
(9,'Asse o bolo: Leve ao forno e asse por cerca de 30-40 minutos, ou at� que um palito inserido no centro saia limpo.', GETDATE(), @MassaBoloLaranjaId),
(10, 'Esfrie e desenforme: Retire o bolo do forno e deixe esfriar na forma por 10 minutos. Em seguida, desenforme e deixe esfriar completamente sobre uma grade.', GETDATE(), @MassaBoloLaranjaId),
(11, 'Decore (opcional): Se desejar, decore com uma cobertura de glac� ou a��car de confeiteiro.', GETDATE(), @MassaBoloLaranjaId);

-- @CarameloPudimId
INSERT INTO [dbo].[Directions]( OrderNumber, Step, CreatedAt, RecipeDirectionId) VALUES
(1,  'Coloque o acucar na panela', GETDATE(), @CarameloPudimId),
(2,  'Derreta o acucar e coloque a agua', GETDATE(), @CarameloPudimId),
(3,  'Espere esfriar', GETDATE(), @CarameloPudimId);

-- @MassaPudimId
INSERT INTO [dbo].[Directions]( OrderNumber, Step, CreatedAt, RecipeDirectionId) VALUES
(1,  'Coloque os ovos e o leite condencado no liquidificador.', GETDATE(), @MassaPudimId),
(2,  'Bata ate cansar', GETDATE(), @MassaPudimId),
(3,  'Despeje na froma e cubra com papel aluminio', GETDATE(), @MassaPudimId);


-- ==================================
-- Inser��o dos passos da Ingredients
-- ==================================
INSERT INTO [dbo].[Ingredients](Name, CreatedAt) VALUES
('Polvilho doce', GETDATE()),
('Queijo parmes�o ralado', GETDATE()),
('Leite', GETDATE()),
('�leo', GETDATE()),
('Ovos', GETDATE()),
('Sal', GETDATE()),
('Leite condensado', GETDATE()),
('A��car', GETDATE()),
('Raspas de laranja', GETDATE()),
('�gua', GETDATE()),
('Manteiga', GETDATE()),
('Suco de laranja', GETDATE()),
('Farinha de trigo', GETDATE()),
('Fermento em p�', GETDATE());



-- ==============================================
-- Inser��o dos INGREDIENTES E UNIDADES DE MEDIDA
-- ==============================================
INSERT INTO [dbo].[IngredientMeasures] (IngredientId, MeasureId) VALUES
((SELECT ID FROM Ingredients WHERE Name='Polvilho doce'), (SELECT ID FROM Measures WHERE UnitShort='g')),
((SELECT ID FROM Ingredients WHERE Name='Queijo parmes�o ralado'), (SELECT ID FROM Measures WHERE UnitShort='g')),
((SELECT ID FROM Ingredients WHERE Name='Leite'), (SELECT ID FROM Measures WHERE UnitShort='ml')),
((SELECT ID FROM Ingredients WHERE Name='�leo'), (SELECT ID FROM Measures WHERE UnitShort='ml')),
((SELECT ID FROM Ingredients WHERE Name='Ovos'), (SELECT ID FROM Measures WHERE UnitShort='un')),
((SELECT ID FROM Ingredients WHERE Name='Sal'), (SELECT ID FROM Measures WHERE UnitShort='g')),
((SELECT ID FROM Ingredients WHERE Name='Leite condensado'), (SELECT ID FROM Measures WHERE UnitShort='ml')),
((SELECT ID FROM Ingredients WHERE Name='Leite'), (SELECT ID FROM Measures WHERE UnitShort='ml')),
((SELECT ID FROM Ingredients WHERE Name='Ovos'), (SELECT ID FROM Measures WHERE UnitShort='un')),
( (SELECT ID FROM Ingredients WHERE Name='A��car'), (SELECT ID FROM Measures WHERE UnitShort='g')),
( (SELECT ID FROM Ingredients WHERE Name='�gua'), (SELECT ID FROM Measures WHERE UnitShort='ml')),
( (SELECT ID FROM Ingredients WHERE Name='Manteiga'), (SELECT ID FROM Measures WHERE UnitShort='g')),
( (SELECT ID FROM Ingredients WHERE Name='Sal'), (SELECT ID FROM Measures WHERE UnitShort='g')),
( (SELECT ID FROM Ingredients WHERE Name='Fermento em p�'), (SELECT ID FROM Measures WHERE UnitShort='g')),
( (SELECT ID FROM Ingredients WHERE Name='A��car'), (SELECT ID FROM Measures WHERE UnitShort='g')),
( (SELECT ID FROM Ingredients WHERE Name='Raspas de laranja'), (SELECT ID FROM Measures WHERE UnitShort='g')),
( (SELECT ID FROM Ingredients WHERE Name='�gua'), (SELECT ID FROM Measures WHERE UnitShort='ml')),
( (SELECT ID FROM Ingredients WHERE Name='Manteiga'), (SELECT ID FROM Measures WHERE UnitShort='g')),
( (SELECT ID FROM Ingredients WHERE Name='Suco de laranja'), (SELECT ID FROM Measures WHERE UnitShort='ml')),
( (SELECT ID FROM Ingredients WHERE Name='Farinha de trigo'), (SELECT ID FROM Measures WHERE UnitShort='g'));


-- ==============================================
-- Inser��o dos INGREDIENTES E UNIDADES DE MEDIDA
-- ==============================================
INSERT INTO [dbo].[IngredientDirections] (Quantity, RecipeDirectionId, IngredientMeasureId) VALUES
(500, @MassaPaoDeQueijoId, 1), 
(100, @MassaPaoDeQueijoId, 2),
(50, @MassaPaoDeQueijoId, 3),
(75, @MassaPaoDeQueijoId, 4),
(2, @MassaPaoDeQueijoId, 5),
(10, @CarameloPudimId, 6),
(375, @MassaPudimId, 7),
(1000, @MassaPudimId, 8),
(4, @MassaPudimId, 9),
(200, @CarameloPudimId, 10),
(100, @CarameloPudimId, 11),
(60, @MassaBoloLaranjaId, 12),
(10, @MassaBoloLaranjaId, 13),
(7, @MassaBoloLaranjaId, 12),
(300, @MassaBoloLaranjaId, 13),
(20, @MassaBoloLaranjaId, 14),
(60, @MassaBoloLaranjaId, 15),
(40, @MassaBoloLaranjaId, 16),
(20, @MassaBoloLaranjaId, 17),
(500, @MassaBoloLaranjaId, 18);

/**************************
***** Feedback
**************************/
INSERT INTO [dbo].[Feedbacks] (UserId, Stars, Comment, Image, CreatedAt, RecipeId)
	VALUES
			(1, 4.5, 'Gostei muito, mas muito demorado', 'image-from-user-bolo.jpg', GETDATE(), 2),
			(1, 5, 'Adorei, a familia toda amou!', 'image-from-user-pao.jpg', GETDATE(), 2),
			(1, 4, 'Poderia ser melhor', 'image-from-user-pudim.jpg', GETDATE(), 2),
			(1, 2.5, 'Maravilhoso, farei outras vezes', 'image-from-user-pudim.jpg', GETDATE(), 3),
			(1, 1.5, 'A familia amou!', 'image-from-user-pudim.jpg', GETDATE(), 3);




INSERT INTO [dbo].[Feedbacks] (UserId, Stars, Comment, Image, CreatedAt, RecipeId)
	VALUES
			(1, 0, '0 star feedback', '', GETDATE(), 1),
			(1, 0.5, '0.5 star feedback', '', GETDATE(), 1),
			(1, 1, '1 star feedback', '', GETDATE(), 1),
			(1, 1.5, '1.5 star feedback', '', GETDATE(), 1),
			(1, 2, '2 star feedback', '', GETDATE(), 1),
			(1, 2.5, '2.5 star feedback', '', GETDATE(), 1),
			(1, 3, '3 star feedback', '', GETDATE(), 1),
			(1, 3.5, '3.5 star feedback', '', GETDATE(), 1),
			(1, 4, '4 star feedback', '', GETDATE(), 1),
			(1, 4.5, '4.5 star feedback', '', GETDATE(), 1),
			(1, 5, '5 star feedback', '', GETDATE(), 1);