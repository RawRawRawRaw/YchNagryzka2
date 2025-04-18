USE [master]
GO
/****** Object:  Database [УчебнаяНагрузка]    Script Date: 06.04.2025 21:14:53 ******/
CREATE DATABASE [УчебнаяНагрузка]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'УчебнаяНагрузка', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\УчебнаяНагрузка.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'УчебнаяНагрузка_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\УчебнаяНагрузка_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [УчебнаяНагрузка] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [УчебнаяНагрузка].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [УчебнаяНагрузка] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET ARITHABORT OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [УчебнаяНагрузка] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [УчебнаяНагрузка] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET  DISABLE_BROKER 
GO
ALTER DATABASE [УчебнаяНагрузка] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [УчебнаяНагрузка] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [УчебнаяНагрузка] SET  MULTI_USER 
GO
ALTER DATABASE [УчебнаяНагрузка] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [УчебнаяНагрузка] SET DB_CHAINING OFF 
GO
ALTER DATABASE [УчебнаяНагрузка] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [УчебнаяНагрузка] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [УчебнаяНагрузка] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [УчебнаяНагрузка] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [УчебнаяНагрузка] SET QUERY_STORE = OFF
GO
USE [УчебнаяНагрузка]
GO
/****** Object:  Table [dbo].[Дисциплины]    Script Date: 06.04.2025 21:14:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Дисциплины](
	[Код] [int] NOT NULL,
	[Название] [nvarchar](50) NULL,
	[Направление] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Код] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Преподаватели]    Script Date: 06.04.2025 21:14:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Преподаватели](
	[ТабельныйНомер] [int] NOT NULL,
	[Фамилия] [nvarchar](50) NULL,
	[Имя] [nvarchar](50) NULL,
	[Отчество] [nvarchar](50) NULL,
	[Должность] [nvarchar](50) NULL,
	[Кафедра] [int] NULL,
	[Стаж] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ТабельныйНомер] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[РаспределениеНагрузки]    Script Date: 06.04.2025 21:14:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[РаспределениеНагрузки](
	[Ключ] [int] NOT NULL,
	[ТабельныйНомерПрепода] [int] NULL,
	[НомерГруппы] [int] NULL,
	[Семестр] [int] NULL,
	[КоличествоЧасов] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ключ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Дисциплины] ([Код], [Название], [Направление]) VALUES (1, N'Математика', N'Техническое')
INSERT [dbo].[Дисциплины] ([Код], [Название], [Направление]) VALUES (2, N'Физика', N'Техническое')
INSERT [dbo].[Дисциплины] ([Код], [Название], [Направление]) VALUES (3, N'История', N'Гуманитарное')
INSERT [dbo].[Дисциплины] ([Код], [Название], [Направление]) VALUES (4, N'Информатика', N'Техническое')
INSERT [dbo].[Дисциплины] ([Код], [Название], [Направление]) VALUES (5, N'Психология', N'Гуманитарное')
GO
INSERT [dbo].[Преподаватели] ([ТабельныйНомер], [Фамилия], [Имя], [Отчество], [Должность], [Кафедра], [Стаж]) VALUES (1, N'Иванов', N'Иван', N'Иванович', N'Доцент', 1, 10)
INSERT [dbo].[Преподаватели] ([ТабельныйНомер], [Фамилия], [Имя], [Отчество], [Должность], [Кафедра], [Стаж]) VALUES (2, N'Петрова', N'Анна', N'Сергеевна', N'Старший преподаватель', 2, 8)
INSERT [dbo].[Преподаватели] ([ТабельныйНомер], [Фамилия], [Имя], [Отчество], [Должность], [Кафедра], [Стаж]) VALUES (3, N'Сидоров', N'Алексей', N'Николаевич', N'Профессор', 4, 15)
INSERT [dbo].[Преподаватели] ([ТабельныйНомер], [Фамилия], [Имя], [Отчество], [Должность], [Кафедра], [Стаж]) VALUES (4, N'Кузнецова', N'Ольга', N'Владимировна', N'Преподаватель', 3, 5)
INSERT [dbo].[Преподаватели] ([ТабельныйНомер], [Фамилия], [Имя], [Отчество], [Должность], [Кафедра], [Стаж]) VALUES (5, N'Смирнов', N'Сергей', N'Михайлович', N'Ассистент', 5, 2)
GO
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (1, 1, 1, 1, 60)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (2, 1, 2, 1, 30)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (3, 2, 1, 1, 40)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (4, 3, 3, 1, 45)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (5, 3, 4, 1, 30)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (6, 4, 5, 1, 50)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (7, 5, 2, 1, 20)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (8, 1, 1, 2, 60)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (9, 2, 2, 2, 30)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (10, 3, 3, 2, 45)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (11, 4, 4, 2, 30)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (12, 5, 5, 2, 20)
INSERT [dbo].[РаспределениеНагрузки] ([Ключ], [ТабельныйНомерПрепода], [НомерГруппы], [Семестр], [КоличествоЧасов]) VALUES (13, 1, 1, 3, 60)
GO
ALTER TABLE [dbo].[Преподаватели]  WITH CHECK ADD  CONSTRAINT [FK_Преподаватели_Дисциплины] FOREIGN KEY([Кафедра])
REFERENCES [dbo].[Дисциплины] ([Код])
GO
ALTER TABLE [dbo].[Преподаватели] CHECK CONSTRAINT [FK_Преподаватели_Дисциплины]
GO
ALTER TABLE [dbo].[РаспределениеНагрузки]  WITH CHECK ADD  CONSTRAINT [FK_РаспределениеНагрузки_Преподаватели] FOREIGN KEY([ТабельныйНомерПрепода])
REFERENCES [dbo].[Преподаватели] ([ТабельныйНомер])
GO
ALTER TABLE [dbo].[РаспределениеНагрузки] CHECK CONSTRAINT [FK_РаспределениеНагрузки_Преподаватели]
GO
USE [master]
GO
ALTER DATABASE [УчебнаяНагрузка] SET  READ_WRITE 
GO
