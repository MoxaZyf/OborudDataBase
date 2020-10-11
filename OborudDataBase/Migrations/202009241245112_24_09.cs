namespace OborudDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24_09 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parameters", "ParamTypes_Id", c => c.Int());
            CreateIndex("dbo.Parameters", "ParamTypes_Id");
            AddForeignKey("dbo.Parameters", "ParamTypes_Id", "dbo.ParamTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parameters", "ParamTypes_Id", "dbo.ParamTypes");
            DropIndex("dbo.Parameters", new[] { "ParamTypes_Id" });
            DropColumn("dbo.Parameters", "ParamTypes_Id");
        }
    }
}
