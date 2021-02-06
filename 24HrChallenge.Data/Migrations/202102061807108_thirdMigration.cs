namespace _24HrChallenge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Author", c => c.Guid(nullable: false));
            AddColumn("dbo.Comment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Comment", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "userId", c => c.Guid(nullable: false));
            DropColumn("dbo.Comment", "CreatedUtc");
            DropColumn("dbo.Comment", "Author");
        }
    }
}
