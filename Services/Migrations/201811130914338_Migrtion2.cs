namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrtion2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Users_Id", newName: "UserOwner_Id");
            RenameIndex(table: "dbo.Books", name: "IX_Users_Id", newName: "IX_UserOwner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_UserOwner_Id", newName: "IX_Users_Id");
            RenameColumn(table: "dbo.Books", name: "UserOwner_Id", newName: "Users_Id");
        }
    }
}
