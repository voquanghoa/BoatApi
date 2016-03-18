namespace BoatApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthentication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authentication",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SessionHash = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.User", "Name", c => c.String(nullable: false));
            AddColumn("dbo.User", "PasswordHash", c => c.String(nullable: false));
            DropColumn("dbo.User", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserName", c => c.String(nullable: false));
            DropForeignKey("dbo.Authentication", "User_Id", "dbo.User");
            DropIndex("dbo.Authentication", new[] { "User_Id" });
            DropColumn("dbo.User", "PasswordHash");
            DropColumn("dbo.User", "Name");
            DropTable("dbo.Authentication");
        }
    }
}
