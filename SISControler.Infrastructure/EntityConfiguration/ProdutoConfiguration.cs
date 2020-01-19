using SISControler.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SISControler.Infrastructure.EntityConfiguration
{
    internal sealed class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        #region[FluentAPI]

        public ProdutoConfiguration()
        {
            ToTable("Produto");
            this.HasKey(x => x.id);
            this.Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.nomeProduto).HasMaxLength(50).IsRequired();
            this.Property(x => x.fornecedor).HasMaxLength(70).IsRequired();
            this.Property(x => x.marca).HasMaxLength(50).IsRequired();
            this.Property(x => x.valor).IsRequired();
        }

        #endregion
    }
}
