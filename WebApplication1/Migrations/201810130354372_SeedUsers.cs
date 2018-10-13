namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33c0870a-15a2-420b-8eeb-83324bbfb01b', N'guest@test.com', 0, N'AGJfaiHlAsg5mfNNDvkE0d+tc+6mL10ZqNZB2VOy7aKe8BpPFMKIcy64nvsbPti6gQ==', N'761041fe-00ce-4e41-988b-5e551dbf8334', NULL, 0, 0, NULL, 1, 0, N'guest@test.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3853b1e8-347e-43c3-8ba5-307a09947821', N'admin@vidly.com', 0, N'AEB95snHEnutKCA6igrxBeNomNln9Cyrcx5tQnM4mD61JsAqhzug75UlwhLctN1uNg==', N'1f88163f-0ef1-4c8f-9271-d5f9df33d879', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f8cdfeac-de80-47f1-b9ce-69915078038d', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3853b1e8-347e-43c3-8ba5-307a09947821', N'f8cdfeac-de80-47f1-b9ce-69915078038d')

    ");
        }

        public override void Down()
        {
        }
    }
}
