USE [kvalikware]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](200) NULL,
	[plate] [nvarchar](9) NULL,
	[lastTO] [date] NULL,
	[nextTO] [date] NULL,
	[driverId] [int] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarService]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarService](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[carId] [int] NULL,
	[type] [nvarchar](200) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_CarService] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[startPoint] [nvarchar](max) NULL,
	[endPoint] [nvarchar](max) NULL,
	[dateStart] [date] NULL,
	[dateEnd] [date] NULL,
	[prioritet] [nvarchar](max) NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryProduct]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NULL,
	[deliveryId] [int] NULL,
	[count] [int] NULL,
 CONSTRAINT [PK_DeliveryProduct] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[expirationDate] [date] NULL,
	[conditions] [nvarchar](max) NULL,
	[count] [int] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NULL,
	[count] [int] NULL,
	[date] [date] NULL,
	[batchNumber] [int] NULL,
	[conditions] [nvarchar](max) NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnProduct]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NULL,
	[returnType] [nvarchar](200) NULL,
	[reason] [nvarchar](max) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_ReturnProduct] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fname] [nvarchar](max) NULL,
	[lname] [nvarchar](max) NULL,
	[login] [nvarchar](200) NULL,
	[password] [nvarchar](200) NULL,
	[roleId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserChat]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserChat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstUserId] [int] NULL,
	[secondUserId] [int] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_UserChat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserChatMessage]    Script Date: 04.07.2025 0:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserChatMessage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[chatId] [int] NULL,
	[userId] [int] NULL,
	[message] [nvarchar](999) NULL,
	[sent_at] [datetime] NULL,
	[photoUrl] [nvarchar](300) NULL,
 CONSTRAINT [PK_UserChatMessage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserChat] ADD  CONSTRAINT [DF_UserChat_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_User] FOREIGN KEY([driverId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_User]
GO
ALTER TABLE [dbo].[CarService]  WITH CHECK ADD  CONSTRAINT [FK_CarService_Car] FOREIGN KEY([carId])
REFERENCES [dbo].[Car] ([id])
GO
ALTER TABLE [dbo].[CarService] CHECK CONSTRAINT [FK_CarService_Car]
GO
ALTER TABLE [dbo].[DeliveryProduct]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryProduct_Delivery] FOREIGN KEY([deliveryId])
REFERENCES [dbo].[Delivery] ([id])
GO
ALTER TABLE [dbo].[DeliveryProduct] CHECK CONSTRAINT [FK_DeliveryProduct_Delivery]
GO
ALTER TABLE [dbo].[DeliveryProduct]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryProduct_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[DeliveryProduct] CHECK CONSTRAINT [FK_DeliveryProduct_Product]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Product]
GO
ALTER TABLE [dbo].[ReturnProduct]  WITH CHECK ADD  CONSTRAINT [FK_ReturnProduct_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ReturnProduct] CHECK CONSTRAINT [FK_ReturnProduct_Product]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserChat]  WITH CHECK ADD  CONSTRAINT [FK_UserChat_User] FOREIGN KEY([firstUserId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[UserChat] CHECK CONSTRAINT [FK_UserChat_User]
GO
ALTER TABLE [dbo].[UserChat]  WITH CHECK ADD  CONSTRAINT [FK_UserChat_User1] FOREIGN KEY([secondUserId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[UserChat] CHECK CONSTRAINT [FK_UserChat_User1]
GO
ALTER TABLE [dbo].[UserChatMessage]  WITH CHECK ADD  CONSTRAINT [FK_UserChatMessage_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[UserChatMessage] CHECK CONSTRAINT [FK_UserChatMessage_User]
GO
ALTER TABLE [dbo].[UserChatMessage]  WITH CHECK ADD  CONSTRAINT [FK_UserChatMessage_UserChat] FOREIGN KEY([chatId])
REFERENCES [dbo].[UserChat] ([id])
GO
ALTER TABLE [dbo].[UserChatMessage] CHECK CONSTRAINT [FK_UserChatMessage_UserChat]
GO
