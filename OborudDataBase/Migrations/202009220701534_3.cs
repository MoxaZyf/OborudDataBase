namespace OborudDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParamValueOboruds", "ParamValue_Id", "dbo.ParamValues");
            DropForeignKey("dbo.ParamValueOboruds", "Oboruds_Id", "dbo.Oboruds");
            DropIndex("dbo.ParamValueOboruds", new[] { "ParamValue_Id" });
            DropIndex("dbo.ParamValueOboruds", new[] { "Oboruds_Id" });
            AddColumn("dbo.ParamValues", "Oboruds_Id", c => c.Int());
            CreateIndex("dbo.ParamValues", "Oboruds_Id");
            AddForeignKey("dbo.ParamValues", "Oboruds_Id", "dbo.Oboruds", "Id");
            DropTable("dbo.ParamValueOboruds");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParamValueOboruds",
                c => new
                    {
                        ParamValue_Id = c.Int(nullable: false),
                        Oboruds_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParamValue_Id, t.Oboruds_Id });
            
            DropForeignKey("dbo.ParamValues", "Oboruds_Id", "dbo.Oboruds");
            DropIndex("dbo.ParamValues", new[] { "Oboruds_Id" });
            DropColumn("dbo.ParamValues", "Oboruds_Id");
            CreateIndex("dbo.ParamValueOboruds", "Oboruds_Id");
            CreateIndex("dbo.ParamValueOboruds", "ParamValue_Id");
            AddForeignKey("dbo.ParamValueOboruds", "Oboruds_Id", "dbo.Oboruds", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ParamValueOboruds", "ParamValue_Id", "dbo.ParamValues", "Id", cascadeDelete: true);
        }
    }
}
