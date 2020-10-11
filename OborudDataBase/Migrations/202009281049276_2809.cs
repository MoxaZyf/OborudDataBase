namespace OborudDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2809 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Oboruds", "DateVvoda", c => c.DateTime());
            AddColumn("dbo.Oboruds", "DescriptionOborud", c => c.String());
            AddColumn("dbo.Oboruds", "Location_Id", c => c.Int());
            CreateIndex("dbo.Oboruds", "Location_Id");
            AddForeignKey("dbo.Oboruds", "Location_Id", "dbo.Locations", "Id");
            DropColumn("dbo.Parameters", "DateVvoda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parameters", "DateVvoda", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Oboruds", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Oboruds", new[] { "Location_Id" });
            DropColumn("dbo.Oboruds", "Location_Id");
            DropColumn("dbo.Oboruds", "DescriptionOborud");
            DropColumn("dbo.Oboruds", "DateVvoda");
            DropTable("dbo.Locations");
        }
    }
}
