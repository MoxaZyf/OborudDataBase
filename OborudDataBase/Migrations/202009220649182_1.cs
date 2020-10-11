namespace OborudDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Oboruds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Oborud_TypeVal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Oboruds_Id = c.Int(),
                        ParamValues_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oboruds", t => t.Oboruds_Id)
                .ForeignKey("dbo.ParamValues", t => t.ParamValues_Id)
                .Index(t => t.Oboruds_Id)
                .Index(t => t.ParamValues_Id);
            
            CreateTable(
                "dbo.ParamValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Num_value = c.Int(nullable: false),
                        Str_value = c.String(),
                        Oboruds_Id = c.Int(),
                        Parameters_Id = c.Int(),
                        TypesVariant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oboruds", t => t.Oboruds_Id)
                .ForeignKey("dbo.Parameters", t => t.Parameters_Id)
                .ForeignKey("dbo.TypesVariants", t => t.TypesVariant_Id)
                .Index(t => t.Oboruds_Id)
                .Index(t => t.Parameters_Id)
                .Index(t => t.TypesVariant_Id);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateVvoda = c.DateTime(nullable: false),
                        Description = c.String(),
                        GroupType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupTypes", t => t.GroupType_Id)
                .Index(t => t.GroupType_Id);
            
            CreateTable(
                "dbo.TypesVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Variant_num = c.Int(nullable: false),
                        Name = c.String(),
                        Parameters_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parameters", t => t.Parameters_Id)
                .Index(t => t.Parameters_Id);
            
            CreateTable(
                "dbo.ParamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OborudsGroupTypes",
                c => new
                    {
                        Oboruds_Id = c.Int(nullable: false),
                        GroupType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Oboruds_Id, t.GroupType_Id })
                .ForeignKey("dbo.Oboruds", t => t.Oboruds_Id, cascadeDelete: true)
                .ForeignKey("dbo.GroupTypes", t => t.GroupType_Id, cascadeDelete: true)
                .Index(t => t.Oboruds_Id)
                .Index(t => t.GroupType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OborudsGroupTypes", "GroupType_Id", "dbo.GroupTypes");
            DropForeignKey("dbo.OborudsGroupTypes", "Oboruds_Id", "dbo.Oboruds");
            DropForeignKey("dbo.Oborud_TypeVal", "ParamValues_Id", "dbo.ParamValues");
            DropForeignKey("dbo.ParamValues", "TypesVariant_Id", "dbo.TypesVariants");
            DropForeignKey("dbo.TypesVariants", "Parameters_Id", "dbo.Parameters");
            DropForeignKey("dbo.ParamValues", "Parameters_Id", "dbo.Parameters");
            DropForeignKey("dbo.Parameters", "GroupType_Id", "dbo.GroupTypes");
            DropForeignKey("dbo.ParamValues", "Oboruds_Id", "dbo.Oboruds");
            DropForeignKey("dbo.Oborud_TypeVal", "Oboruds_Id", "dbo.Oboruds");
            DropIndex("dbo.OborudsGroupTypes", new[] { "GroupType_Id" });
            DropIndex("dbo.OborudsGroupTypes", new[] { "Oboruds_Id" });
            DropIndex("dbo.TypesVariants", new[] { "Parameters_Id" });
            DropIndex("dbo.Parameters", new[] { "GroupType_Id" });
            DropIndex("dbo.ParamValues", new[] { "TypesVariant_Id" });
            DropIndex("dbo.ParamValues", new[] { "Parameters_Id" });
            DropIndex("dbo.ParamValues", new[] { "Oboruds_Id" });
            DropIndex("dbo.Oborud_TypeVal", new[] { "ParamValues_Id" });
            DropIndex("dbo.Oborud_TypeVal", new[] { "Oboruds_Id" });
            DropTable("dbo.OborudsGroupTypes");
            DropTable("dbo.ParamTypes");
            DropTable("dbo.TypesVariants");
            DropTable("dbo.Parameters");
            DropTable("dbo.ParamValues");
            DropTable("dbo.Oborud_TypeVal");
            DropTable("dbo.Oboruds");
            DropTable("dbo.GroupTypes");
        }
    }
}
