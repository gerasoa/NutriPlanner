USE [MyMeals3]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Image] [varchar](200) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dificulty]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dificulty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_Dificulty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DirectionsRecipe]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectionsRecipe](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NULL,
	[OrderNumber] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[RecipeId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_DirectionsRecipe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RecipeId] [uniqueidentifier] NOT NULL,
	[Stars] [int] NOT NULL,
	[Comment] [varchar](200) NULL,
	[Image] [varchar](200) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientMeasure]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientMeasure](
	[Id] [uniqueidentifier] NOT NULL,
	[IngredientId] [uniqueidentifier] NULL,
	[MeasureId] [int] NULL,
	[Quantity] [real] NOT NULL,
 CONSTRAINT [PK_IngredientMeasure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientMeasureDirection]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientMeasureDirection](
	[Id] [uniqueidentifier] NOT NULL,
	[DirectionRecipeId] [uniqueidentifier] NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[IngredientMeasureId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_IngredientMeasureDirection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measure]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitShort] [varchar](200) NULL,
	[UnitLong] [varchar](200) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Measure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 05/09/2024 20:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ReadyInMinutes] [int] NOT NULL,
	[Servings] [int] NOT NULL,
	[Image] [varchar](100) NOT NULL,
	[DifficultyId] [int] NULL,
	[Summary] [varchar](1000) NOT NULL,
	[PublishedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Verified] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DirectionsRecipe]  WITH CHECK ADD  CONSTRAINT [FK_DirectionsRecipe_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[DirectionsRecipe] CHECK CONSTRAINT [FK_DirectionsRecipe_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[IngredientMeasure]  WITH CHECK ADD  CONSTRAINT [FK_IngredientMeasure_Ingredient_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredient] ([Id])
GO
ALTER TABLE [dbo].[IngredientMeasure] CHECK CONSTRAINT [FK_IngredientMeasure_Ingredient_IngredientId]
GO
ALTER TABLE [dbo].[IngredientMeasure]  WITH CHECK ADD  CONSTRAINT [FK_IngredientMeasure_Measure_MeasureId] FOREIGN KEY([MeasureId])
REFERENCES [dbo].[Measure] ([Id])
GO
ALTER TABLE [dbo].[IngredientMeasure] CHECK CONSTRAINT [FK_IngredientMeasure_Measure_MeasureId]
GO
ALTER TABLE [dbo].[IngredientMeasureDirection]  WITH CHECK ADD  CONSTRAINT [FK_IngredientMeasureDirection_DirectionsRecipe_DirectionRecipeId] FOREIGN KEY([DirectionRecipeId])
REFERENCES [dbo].[DirectionsRecipe] ([Id])
GO
ALTER TABLE [dbo].[IngredientMeasureDirection] CHECK CONSTRAINT [FK_IngredientMeasureDirection_DirectionsRecipe_DirectionRecipeId]
GO
ALTER TABLE [dbo].[IngredientMeasureDirection]  WITH CHECK ADD  CONSTRAINT [FK_IngredientMeasureDirection_IngredientMeasure_IngredientMeasureId] FOREIGN KEY([IngredientMeasureId])
REFERENCES [dbo].[IngredientMeasure] ([Id])
GO
ALTER TABLE [dbo].[IngredientMeasureDirection] CHECK CONSTRAINT [FK_IngredientMeasureDirection_IngredientMeasure_IngredientMeasureId]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Category_CategoryId]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Dificulty_DifficultyId] FOREIGN KEY([DifficultyId])
REFERENCES [dbo].[Dificulty] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Dificulty_DifficultyId]
GO
