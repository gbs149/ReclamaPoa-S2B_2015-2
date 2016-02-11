namespace ReclamaPoa2013.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioOficial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Oficial", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Oficial");
        }
    }
}
