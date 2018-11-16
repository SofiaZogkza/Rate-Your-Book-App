namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextReview = c.String(),
                        Stars = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Books", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Evaluations", "Book_Id", "dbo.Books");
            DropIndex("dbo.Evaluations", new[] { "User_Id" });
            DropIndex("dbo.Evaluations", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Users_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Evaluations");
            DropTable("dbo.Books");
        }
    }
}
