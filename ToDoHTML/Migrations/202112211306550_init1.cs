namespace ToDoHTML.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PerformerImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performers", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PerformerId = c.Int(nullable: false),
                        Importance = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Time = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performers", t => t.PerformerId, cascadeDelete: true)
                .Index(t => t.PerformerId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopicTasks",
                c => new
                    {
                        Topic_Id = c.Int(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Topic_Id, t.Task_Id })
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Topic_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TopicTasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.TopicTasks", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Tasks", "PerformerId", "dbo.Performers");
            DropForeignKey("dbo.PerformerImages", "Id", "dbo.Performers");
            DropIndex("dbo.TopicTasks", new[] { "Task_Id" });
            DropIndex("dbo.TopicTasks", new[] { "Topic_Id" });
            DropIndex("dbo.Tasks", new[] { "PerformerId" });
            DropIndex("dbo.PerformerImages", new[] { "Id" });
            DropTable("dbo.TopicTasks");
            DropTable("dbo.Topics");
            DropTable("dbo.Tasks");
            DropTable("dbo.Performers");
            DropTable("dbo.PerformerImages");
        }
    }
}
