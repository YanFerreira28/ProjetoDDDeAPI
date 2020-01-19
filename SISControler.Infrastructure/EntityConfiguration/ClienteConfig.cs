using SISControler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISControler.Infrastructure.EntityConfiguration
{
    internal sealed class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        #region[FluentAPI]

        public ClienteConfig()
        {
            ToTable("Cliente");
            this.HasKey(x => x.id);
            this.Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.nomeCliente).HasMaxLength(50).IsRequired();
            this.Property(x => x.sobrenome).HasMaxLength(50).IsRequired();

        }

        #endregion
    }
}
