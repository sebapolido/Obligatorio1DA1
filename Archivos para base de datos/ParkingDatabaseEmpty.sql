USE [ParkingDatabase]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 18/11/2019 14:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Balance] [int] NOT NULL,
	[Mobile] [nvarchar](max) NULL,
	[Country_CountryHandlerId] [int] NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CountryHandlers]    Script Date: 18/11/2019 14:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryHandlers](
	[CountryHandlerId] [int] IDENTITY(1,1) NOT NULL,
	[NameOfCountry] [nvarchar](max) NULL,
	[CostForMinutes] [int] NOT NULL,
	[ValidatorOfMessage_ValidatorOfMessageId] [int] NULL,
	[ValidatorOfPhone_ValidatorOfPhoneId] [int] NULL,
 CONSTRAINT [PK_dbo.CountryHandlers] PRIMARY KEY CLUSTERED 
(
	[CountryHandlerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 18/11/2019 14:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[EnrollmentId] [int] IDENTITY(1,1) NOT NULL,
	[LettersOfEnrollment] [nvarchar](max) NULL,
	[NumbersOfEnrollment] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Enrollments] PRIMARY KEY CLUSTERED 
(
	[EnrollmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 18/11/2019 14:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[TimeOfPurchase] [int] NOT NULL,
	[DateOfPurchase] [datetime] NOT NULL,
	[AccountOfPurchase_AccountId] [int] NULL,
	[EnrollmentOfPurchase_EnrollmentId] [int] NULL,
 CONSTRAINT [PK_dbo.Purchases] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ValidatorOfMessages]    Script Date: 18/11/2019 14:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValidatorOfMessages](
	[ValidatorOfMessageId] [int] IDENTITY(1,1) NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.ValidatorOfMessages] PRIMARY KEY CLUSTERED 
(
	[ValidatorOfMessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ValidatorOfPhones]    Script Date: 18/11/2019 14:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValidatorOfPhones](
	[ValidatorOfPhoneId] [int] IDENTITY(1,1) NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.ValidatorOfPhones] PRIMARY KEY CLUSTERED 
(
	[ValidatorOfPhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Accounts_dbo.CountryHandlers_Country_CountryHandlerId] FOREIGN KEY([Country_CountryHandlerId])
REFERENCES [dbo].[CountryHandlers] ([CountryHandlerId])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_dbo.Accounts_dbo.CountryHandlers_Country_CountryHandlerId]
GO
ALTER TABLE [dbo].[CountryHandlers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CountryHandlers_dbo.ValidatorOfMessages_ValidatorOfMessage_ValidatorOfMessageId] FOREIGN KEY([ValidatorOfMessage_ValidatorOfMessageId])
REFERENCES [dbo].[ValidatorOfMessages] ([ValidatorOfMessageId])
GO
ALTER TABLE [dbo].[CountryHandlers] CHECK CONSTRAINT [FK_dbo.CountryHandlers_dbo.ValidatorOfMessages_ValidatorOfMessage_ValidatorOfMessageId]
GO
ALTER TABLE [dbo].[CountryHandlers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CountryHandlers_dbo.ValidatorOfPhones_ValidatorOfPhone_ValidatorOfPhoneId] FOREIGN KEY([ValidatorOfPhone_ValidatorOfPhoneId])
REFERENCES [dbo].[ValidatorOfPhones] ([ValidatorOfPhoneId])
GO
ALTER TABLE [dbo].[CountryHandlers] CHECK CONSTRAINT [FK_dbo.CountryHandlers_dbo.ValidatorOfPhones_ValidatorOfPhone_ValidatorOfPhoneId]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Purchases_dbo.Accounts_AccountOfPurchase_AccountId] FOREIGN KEY([AccountOfPurchase_AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_dbo.Purchases_dbo.Accounts_AccountOfPurchase_AccountId]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Purchases_dbo.Enrollments_EnrollmentOfPurchase_EnrollmentId] FOREIGN KEY([EnrollmentOfPurchase_EnrollmentId])
REFERENCES [dbo].[Enrollments] ([EnrollmentId])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_dbo.Purchases_dbo.Enrollments_EnrollmentOfPurchase_EnrollmentId]
GO
