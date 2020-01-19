using SISControler.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SISControler.Infrastructure.EntityConfiguration
{
    internal sealed class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        #region[FluentAPI]

        public UsuarioConfiguration()
        {
            ToTable("Usuario");
            this.HasKey(x => x.id);
            this.Property(x => x.id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(x => x.nome).HasMaxLength(50).IsRequired();
            this.Property(x => x.senha).HasMaxLength(50).IsRequired();
        }

        #endregion
    }
}
