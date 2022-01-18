namespace ToDoHTML.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayOfWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeekName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskDayOfWeeks",
                c => new
                    {
                        Task_Id = c.Int(nullable: false),
                        DayOfWeek_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.DayOfWeek_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .ForeignKey("dbo.DayOfWeeks", t => t.DayOfWeek_Id, cascadeDelete: true)
                .Index(t => t.Task_Id)
                .Index(t => t.DayOfWeek_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskDayOfWeeks", "DayOfWeek_Id", "dbo.DayOfWeeks");
            DropForeignKey("dbo.TaskDayOfWeeks", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TaskDayOfWeeks", new[] { "DayOfWeek_Id" });
            DropIndex("dbo.TaskDayOfWeeks", new[] { "Task_Id" });
            DropTable("dbo.TaskDayOfWeeks");
            DropTable("dbo.DayOfWeeks");
        }
    }
}
