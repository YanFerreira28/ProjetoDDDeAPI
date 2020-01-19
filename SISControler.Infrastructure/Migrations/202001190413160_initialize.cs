namespace SISControler.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nomeCliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        sobrenome = c.String(nullable: false, maxLength: 50, unicode: false),
                        idade = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nomeProduto = c.String(nullable: false, maxLength: 50, unicode: false),
                        fornecedor = c.String(nullable: false, maxLength: 70, unicode: false),
                        marca = c.String(nullable: false, maxLength: 50, unicode: false),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_id)
                .Index(t => t.Cliente_id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        senha = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Cliente_id", "dbo.Cliente");
            DropIndex("dbo.Produto", new[] { "Cliente_id" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.Cliente");
        }
    }
}
