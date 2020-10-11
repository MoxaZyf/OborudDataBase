namespace OborudDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParamValues", "Oboruds_Id", "dbo.Oboruds");
            DropIndex("dbo.ParamValues", new[] { "Oboruds_Id" });
            CreateTable(
                "dbo.ParamValueOboruds",
                c => new
                    {
                        ParamValue_Id = c.Int(nullable: false),
                        Oboruds_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParamValue_Id, t.Oboruds_Id })
                .ForeignKey("dbo.ParamValues", t => t.ParamValue_Id, cascadeDelete: true)
                .ForeignKey("dbo.Oboruds", t => t.Oboruds_Id, cascadeDelete: true)
                .Index(t => t.ParamValue_Id)
                .Index(t => t.Oboruds_Id);
            
            DropColumn("dbo.ParamValues", "Oboruds_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParamValues", "Oboruds_Id", c => c.Int());
            DropForeignKey("dbo.ParamValueOboruds", "Oboruds_Id", "dbo.Oboruds");
            DropForeignKey("dbo.ParamValueOboruds", "ParamValue_Id", "dbo.ParamValues");
            DropIndex("dbo.ParamValueOboruds", new[] { "Oboruds_Id" });
            DropIndex("dbo.ParamValueOboruds", new[] { "ParamValue_Id" });
            DropTable("dbo.ParamValueOboruds");
            CreateIndex("dbo.ParamValues", "Oboruds_Id");
            AddForeignKey("dbo.ParamValues", "Oboruds_Id", "dbo.Oboruds", "Id");
        }
    }
}
