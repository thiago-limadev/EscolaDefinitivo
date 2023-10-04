using EscolaDefinitivo.Helpper;
using EscolaDefinitivo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDefinitivo.Data.EntityConfig
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            var admin = new Usuario("Ademiro", "Admin", "Admin@admin.com", "Admin123", Enums.PerfilEnum.Admin);
            admin.Id = 1;
            admin.SetSenhaHash();

            builder
                .HasData(admin);

        }
    }
}
