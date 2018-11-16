namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookOwnerships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId_Id = c.Int(),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId_Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.BookId_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookOwnerships", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.BookOwnerships", "BookId_Id", "dbo.Books");
            DropIndex("dbo.BookOwnerships", new[] { "UserId_Id" });
            DropIndex("dbo.BookOwnerships", new[] { "BookId_Id" });
            DropTable("dbo.BookOwnerships");
        }
    }
}
