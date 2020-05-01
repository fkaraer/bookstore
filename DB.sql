USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 1.05.2020 23:23:33 ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Users\Faruk\BookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Users\Faruk\BookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookStore] SET QUERY_STORE = OFF
GO
USE [BookStore]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BookStore]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1.05.2020 23:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 1.05.2020 23:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 1.05.2020 23:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Isbn] [int] NOT NULL,
	[ValidIsbn] [bit] NOT NULL,
	[Format] [tinyint] NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[Version] [nvarchar](max) NULL,
	[Preface] [nvarchar](max) NULL,
	[QuantityLeft] [int] NOT NULL,
	[WarehouseLocation] [nvarchar](max) NULL,
	[NextStockDate] [datetime] NOT NULL,
	[Author_Id] [int] NULL,
	[Publisher_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 1.05.2020 23:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Publishers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202005011526070_InitialMigration', N'DataAccess.Migrations.Configuration', 0x1F8B0800000000000400ED5ACD6EE33610BE17E83B083AB545D64AB2976D60EF229B4D0AA39B9FC6D96D6F012D8D6D6225CA15A9C046D127EBA18FD457E8503F34454AB2E438D9A028725148CEC7F92787E37FFEFA7BF86E1585CE03249CC66CE41E0D0E5D07981F0794CD476E2A66AFDEB8EFDE7EFBCDF03C8856CEE772DD6BB90E29191FB90B2196279EC7FD0544840F22EA27318F6762E0C7914782D83B3E3CFCD13B3AF200215CC4729CE16DCA048D20FB07FF3D8B990F4B9192F0320E20E4C538CE4C3254E78A44C097C48791FB810872EAFBC0F940922520407E085809EE3AA72125C8D304C299EB10C6624104727CF289C34424319B4F963840C2BBF51270DD8C841C0A494E36CBBB0A75782C85F2368425949F7211473D018F5E175AF24CF29D74ED2A2DA21ECF51DF622DA5CE7439724F53B18813D731B73A390B13B96CE46624143435E734074E3973A01C02FD46FE1D38676928D204460C529190F0C0B949A721F57F86F55DFC05D888A561A83386ACE15C6500876E9278098958DFC2AC60771CB88E57A5F34C4245A6D1E4A28C99787DEC3A57B8399986A0ECAE893D1171023F01838408086E88109030890199E6ACDD8DBD72D5C8EF724F74378C21D7B924AB8FC0E6623172F1D3752EE80A8272A4E0E313A3187248249214ACADAEC8039D675C1A9BBE8FE32FE8F3B71066B37C4197B9EB0FE4CC7D69E28B248E6EE3B0202886EFEF48320781DCC6F6DC244E13DF6064E86D7CA8D5B324503FBF92145FC5ABE4C6BB785649F75CDE35E653B66DB77684CF24A4810E83228440586FA08B38898850286B01BD21D05F8170C044AE82457EDFD1A83F56E12AFB0F3A639F9B0466C47F82E036F6F9252599477C8499789CC57F25092CE294C3C7D82F0E9127E6FD0A8F607474FFCB6E966D4C73651EDB2DCF95B9AC2ECF9539B02B2759DAE10BA86746CDDE178979C3903165255F73FE510958E3B24F165664FF1FF07509A0D4CE8B39E37BB89B19034DEED8C5DD4E398F7D9A31A3B158066155AA7316382D1199EBB08C635423FA165DA237E1B623F7074B49F5702A9636706546A8021E0E0647A68C9A34ED429ADA6EE2AC51F51BEEB4F8DCC6602B748DE01DF4D828736E6E594A118A51A219B728AF6AD20996554546E185639BCC4BCC09884A2A475FDDF89661324BFA2A40E1EA16792EF81662A5C03A04CD2A068CA6AF2A23EAE4D156D41C4C66F26B8F0AC5B412D6EB0650BA8306A0D46D66D6AA481DC4B5928D2D726B84748A118D73DD542DF23785C43625B668A0CC7B2A10368F115EFE1A51BE5A780DCF16C34BB25CE2B9A03D631423CE247FC3387B35E95FD2473986E7F39ACA5E71AB76C2E38ECCC198C5AD91D30B9A7021DF51A6449E4C6741642DD3C3BE21A8CA9DAA916DDBAA8CB372BDFCCE69DA9E7206F5C1B3D1E5058A17E1D99D490A96D3DB84D96B12094952738B388BC334624D3791366ABDF0D751F4711B6DE81952986AF32CBD19FE6B9AA193919A027347136549B7BF81EAC99A145CD6DABA72EBEBF6562367A56FC5CCD9487704AD82D661B4E1EE586511AD039563DD512A75B40E5599E82161594B57E42B07BBE3A85A59C75183DD71AAB5B00E569DE98E585313EBB035D3DDB18DEA57C735A65E4C3AD00ED9BDE584CD35AA7F6268A17D9AE46D1475157FAD4E3DBFCDAA17143B8FABCB678F64AD68BAA46479CDAAC9C5C675D3D64B273B152075E6928A511BF7E3A9B84876E4A9CFC9D2CA14EA38A059AD38E6F20942D5FC9D2436EFA2BDBDC1BA9BF70DD5926E47AF68B8CEEFE8191BB43D3847437DF0221DA44DF0ED3E62952DE61295AF54F9629429C3A264D8DE82B56A887C89EBA0FC0F3490F5C364CD054403B96030F93D3C0B2966C8CD824BC2E80CB8C8DF0CDDE3C3A363A377FB72FAA81EE741D8A999FAECCF9E54EA74EBC366CFC681DDCA640F24F11724F92E22ABEF753CFB29B35F97F0ABB5EC9E44717A7B2DDBE0B13DBA29ED0F52EDCF09CAD6BBB052D3A20BF05BECA145D7C399B6B6E11E8555D76ADB45578D8DB6477157DB4CDBD906DAE54313D47ACE1DB3005623F78F8CEAC419FF76AF080F9CEB0413F78973E8FCD9DB6A9593AD1F033A6D771E76E895FD3792776D9B6A0FF97BB7AE8F5EA2F46CCD58CFDC3BF48BD0529048459210AF455C247831B2CAB49B84329F2E4958E5D9BE2276B1BF54A00234673EC0129834AC2E55977D5A8B25856A38E236E19FB2F7B59776D7731ABDEDD5E2EBD97D5B29B477D3D7B700ED964197265F4B8F2F2F17F0389BC668E03C1535B5AAEA1A808DFDBF3AE0FAFE4F636BB0BD3358B74173ABEA093B87551DEB7D8F6DED42AB39F662BB83F50DC12715B047F3CFAE9631F0B49F3563D8733ADF40C84700067E25E4D49A319BC565FC1B1C954B8C83FE120409E4EB4E22285E89054ECB679EECE7285848A4B8E43C9A423066D7A958A6024586681A567EE7223348DBFE5987B3CAF3F07A99FD0C651F2264F50E5E7BAED9FB948681E2FBC2BEE83441C8D454DC9EA42D85BC45CDD70AE92A661D810AF5A98C7A07D13244307ECD26E40176E1ED1356043027FEBA7CF46806D96E88AADA871F28992724E205C6861EFF451F0EA2D5DB7F012DE57117DD2F0000, N'6.4.0')
/****** Object:  Index [IX_Author_Id]    Script Date: 1.05.2020 23:23:33 ******/
CREATE NONCLUSTERED INDEX [IX_Author_Id] ON [dbo].[Books]
(
	[Author_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Publisher_Id]    Script Date: 1.05.2020 23:23:33 ******/
CREATE NONCLUSTERED INDEX [IX_Publisher_Id] ON [dbo].[Books]
(
	[Publisher_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Books_dbo.Authors_Author_Id] FOREIGN KEY([Author_Id])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_dbo.Books_dbo.Authors_Author_Id]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Books_dbo.Publishers_Publisher_Id] FOREIGN KEY([Publisher_Id])
REFERENCES [dbo].[Publishers] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_dbo.Books_dbo.Publishers_Publisher_Id]
GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
