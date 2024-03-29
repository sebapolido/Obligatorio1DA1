USE [ParkingDatabase]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 18/11/2019 14:04:21 ******/
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
/****** Object:  Table [dbo].[CountryHandlers]    Script Date: 18/11/2019 14:04:21 ******/
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
/****** Object:  Table [dbo].[Enrollments]    Script Date: 18/11/2019 14:04:21 ******/
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
/****** Object:  Table [dbo].[Purchases]    Script Date: 18/11/2019 14:04:21 ******/
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
/****** Object:  Table [dbo].[ValidatorOfMessages]    Script Date: 18/11/2019 14:04:21 ******/
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
/****** Object:  Table [dbo].[ValidatorOfPhones]    Script Date: 18/11/2019 14:04:21 ******/
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
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountId], [Balance], [Mobile], [Country_CountryHandlerId]) VALUES (1, 20, N'099366931', 1)
INSERT [dbo].[Accounts] ([AccountId], [Balance], [Mobile], [Country_CountryHandlerId]) VALUES (2, 0, N'099366932', 1)
INSERT [dbo].[Accounts] ([AccountId], [Balance], [Mobile], [Country_CountryHandlerId]) VALUES (3, 25, N'1234567', 10)
INSERT [dbo].[Accounts] ([AccountId], [Balance], [Mobile], [Country_CountryHandlerId]) VALUES (4, 100, N'223344', 10)
INSERT [dbo].[Accounts] ([AccountId], [Balance], [Mobile], [Country_CountryHandlerId]) VALUES (5, 0, N'098765432', 1)
INSERT [dbo].[Accounts] ([AccountId], [Balance], [Mobile], [Country_CountryHandlerId]) VALUES (6, 200, N'456321', 10)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[CountryHandlers] ON 

INSERT [dbo].[CountryHandlers] ([CountryHandlerId], [NameOfCountry], [CostForMinutes], [ValidatorOfMessage_ValidatorOfMessageId], [ValidatorOfPhone_ValidatorOfPhoneId]) VALUES (1, N'Uruguay', 2, 1, 1)
INSERT [dbo].[CountryHandlers] ([CountryHandlerId], [NameOfCountry], [CostForMinutes], [ValidatorOfMessage_ValidatorOfMessageId], [ValidatorOfPhone_ValidatorOfPhoneId]) VALUES (10, N'Argentina', 3, 2, 2)
SET IDENTITY_INSERT [dbo].[CountryHandlers] OFF
SET IDENTITY_INSERT [dbo].[Enrollments] ON 

INSERT [dbo].[Enrollments] ([EnrollmentId], [LettersOfEnrollment], [NumbersOfEnrollment]) VALUES (1, N'sbn', 4848)
INSERT [dbo].[Enrollments] ([EnrollmentId], [LettersOfEnrollment], [NumbersOfEnrollment]) VALUES (2, N'sbn', 3030)
INSERT [dbo].[Enrollments] ([EnrollmentId], [LettersOfEnrollment], [NumbersOfEnrollment]) VALUES (3, N'abc', 1234)
INSERT [dbo].[Enrollments] ([EnrollmentId], [LettersOfEnrollment], [NumbersOfEnrollment]) VALUES (4, N'eer', 2332)
INSERT [dbo].[Enrollments] ([EnrollmentId], [LettersOfEnrollment], [NumbersOfEnrollment]) VALUES (5, N'eer', 2331)
INSERT [dbo].[Enrollments] ([EnrollmentId], [LettersOfEnrollment], [NumbersOfEnrollment]) VALUES (6, N'dda', 1111)
SET IDENTITY_INSERT [dbo].[Enrollments] OFF
SET IDENTITY_INSERT [dbo].[Purchases] ON 

INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (1, 30, CAST(N'2019-11-08 12:38:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (2, 60, CAST(N'2019-11-08 13:00:00.000' AS DateTime), 3, 2)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (4, 30, CAST(N'2019-11-08 17:30:00.000' AS DateTime), 1, 3)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (6, 25, CAST(N'2019-11-08 13:10:00.000' AS DateTime), 3, 4)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (7, 50, CAST(N'2019-11-08 16:00:00.000' AS DateTime), 4, 5)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (10, 23, CAST(N'2019-11-08 13:30:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (12, 30, CAST(N'2019-11-08 13:16:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (13, 30, CAST(N'2019-11-08 13:17:00.000' AS DateTime), 1, 6)
INSERT [dbo].[Purchases] ([PurchaseId], [TimeOfPurchase], [DateOfPurchase], [AccountOfPurchase_AccountId], [EnrollmentOfPurchase_EnrollmentId]) VALUES (14, 30, CAST(N'2019-11-18 11:01:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Purchases] OFF
SET IDENTITY_INSERT [dbo].[ValidatorOfMessages] ON 

INSERT [dbo].[ValidatorOfMessages] ([ValidatorOfMessageId], [Discriminator]) VALUES (1, N'ValidatorOfMessageInUruguay')
INSERT [dbo].[ValidatorOfMessages] ([ValidatorOfMessageId], [Discriminator]) VALUES (2, N'ValidatorOfMessageInArgentina')
SET IDENTITY_INSERT [dbo].[ValidatorOfMessages] OFF
SET IDENTITY_INSERT [dbo].[ValidatorOfPhones] ON 

INSERT [dbo].[ValidatorOfPhones] ([ValidatorOfPhoneId], [Discriminator]) VALUES (1, N'ValidatorOfPhoneInUruguay')
INSERT [dbo].[ValidatorOfPhones] ([ValidatorOfPhoneId], [Discriminator]) VALUES (2, N'ValidatorOfPhoneInArgentina')
SET IDENTITY_INSERT [dbo].[ValidatorOfPhones] OFF
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
