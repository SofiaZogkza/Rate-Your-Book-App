namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookOwnerships", "BookId_Id", "dbo.Books");
            DropForeignKey("dbo.BookOwnerships", "UserId_Id", "dbo.Users");
            DropIndex("dbo.BookOwnerships", new[] { "BookId_Id" });
            DropIndex("dbo.BookOwnerships", new[] { "UserId_Id" });
            RenameColumn(table: "dbo.Books", name: "UserOwner_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Books", name: "IX_UserOwner_Id", newName: "IX_User_Id");
            DropTable("dbo.BookOwnerships");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookOwnerships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId_Id = c.Int(),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameIndex(table: "dbo.Books", name: "IX_User_Id", newName: "IX_UserOwner_Id");
            RenameColumn(table: "dbo.Books", name: "User_Id", newName: "UserOwner_Id");
            CreateIndex("dbo.BookOwnerships", "UserId_Id");
            CreateIndex("dbo.BookOwnerships", "BookId_Id");
            AddForeignKey("dbo.BookOwnerships", "UserId_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.BookOwnerships", "BookId_Id", "dbo.Books", "Id");
        }
    }
}
