namespace FiladelfiaKyrkan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ministryname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubmissionForms", "MinistryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubmissionForms", "MinistryName");
        }
    }
}
