USE [MyMeals]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Image] [varchar](200) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Difficulties]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Difficulties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_Difficulties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Stars] [int] NOT NULL,
	[Comment] [varchar](200) NULL,
	[Image] [varchar](200) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientDirections]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientDirections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[RecipeDirectionId] [int] NOT NULL,
	[IngredientMeasureId] [int] NOT NULL,
 CONSTRAINT [PK_IngredientDirections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientMeasures]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientMeasures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [real] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[MeasureId] [int] NOT NULL,
 CONSTRAINT [PK_IngredientMeasures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitShort] [varchar](200) NULL,
	[UnitLong] [varchar](200) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeDirections]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeDirections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[OrderNumber] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_RecipeDirections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 06/09/2024 00:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ReadyInMinutes] [int] NOT NULL,
	[Servings] [int] NOT NULL,
	[Image] [varchar](100) NOT NULL,
	[Summary] [varchar](1000) NOT NULL,
	[PublishedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Verified] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[DifficultyId] [int] NOT NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_Feedbacks_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[Feedbacks] CHECK CONSTRAINT [FK_Feedbacks_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[IngredientDirections]  WITH CHECK ADD  CONSTRAINT [FK_IngredientDirections_IngredientMeasures_IngredientMeasureId] FOREIGN KEY([IngredientMeasureId])
REFERENCES [dbo].[IngredientMeasures] ([Id])
GO
ALTER TABLE [dbo].[IngredientDirections] CHECK CONSTRAINT [FK_IngredientDirections_IngredientMeasures_IngredientMeasureId]
GO
ALTER TABLE [dbo].[IngredientDirections]  WITH CHECK ADD  CONSTRAINT [FK_IngredientDirections_RecipeDirections_RecipeDirectionId] FOREIGN KEY([RecipeDirectionId])
REFERENCES [dbo].[RecipeDirections] ([Id])
GO
ALTER TABLE [dbo].[IngredientDirections] CHECK CONSTRAINT [FK_IngredientDirections_RecipeDirections_RecipeDirectionId]
GO
ALTER TABLE [dbo].[IngredientMeasures]  WITH CHECK ADD  CONSTRAINT [FK_IngredientMeasures_Ingredients_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
GO
ALTER TABLE [dbo].[IngredientMeasures] CHECK CONSTRAINT [FK_IngredientMeasures_Ingredients_IngredientId]
GO
ALTER TABLE [dbo].[IngredientMeasures]  WITH CHECK ADD  CONSTRAINT [FK_IngredientMeasures_Measures_MeasureId] FOREIGN KEY([MeasureId])
REFERENCES [dbo].[Measures] ([Id])
GO
ALTER TABLE [dbo].[IngredientMeasures] CHECK CONSTRAINT [FK_IngredientMeasures_Measures_MeasureId]
GO
ALTER TABLE [dbo].[RecipeDirections]  WITH CHECK ADD  CONSTRAINT [FK_RecipeDirections_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[RecipeDirections] CHECK CONSTRAINT [FK_RecipeDirections_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Difficulties_DifficultyId] FOREIGN KEY([DifficultyId])
REFERENCES [dbo].[Difficulties] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Difficulties_DifficultyId]
GO
