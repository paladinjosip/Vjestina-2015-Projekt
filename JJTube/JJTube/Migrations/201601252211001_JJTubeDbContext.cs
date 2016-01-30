namespace JJTube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JJTubeDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemLink = c.String(nullable: false),
                        ItemName = c.String(nullable: false),
                        List_ListID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Lists", t => t.List_ListID)
                .Index(t => t.List_ListID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        ListName = c.String(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ListID)
                .ForeignKey("dbo.People", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lists", "User_UserID", "dbo.People");
            DropForeignKey("dbo.Items", "List_ListID", "dbo.Lists");
            DropIndex("dbo.Lists", new[] { "User_UserID" });
            DropIndex("dbo.Items", new[] { "List_ListID" });
            DropTable("dbo.People");
            DropTable("dbo.Lists");
            DropTable("dbo.Items");
        }
    }
}
