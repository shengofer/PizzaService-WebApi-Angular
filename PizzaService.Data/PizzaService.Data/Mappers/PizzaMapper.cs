using PizzaService.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaService.Data.Mappers
{
    class PizzaMapper : EntityTypeConfiguration<Pizza>
    {
        public PizzaMapper()
        {
            this.ToTable("PIZZA");
            this.HasKey(s => s.id);
            this.Property(s => s.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.id).IsRequired();

            this.Property(s => s.name).IsRequired();
            this.Property(s => s.name).HasMaxLength(255);
            this.Property(s => s.name).IsUnicode(false);

            this.Property(s => s.price).IsRequired();
            this.Property(s => s.weight).IsRequired();
            this.Property(c => c.description).IsOptional();
            this.Property(c => c.description).HasMaxLength(1000);

            this.HasOptional(o => o.image).WithOptionalDependent(c => c.pizza).Map(p => p.MapKey("imageID")).WillCascadeOnDelete(true);
            //this.HasOptional(o => o.image).WithOptionalPrincipal(o => o.pizza).Map(c => c.MapKey("PizzaID")).WillCascadeOnDelete(false);

            //this.Property(c => c.image).HasColumnName("image").HasColumnType("varbinary");
            //this.Property(p => p.image).HasColumnType("image");
            //this.Property(c => c.image).IsOptional();
            //this.Property(c => c.image).IsOptional();
            //this.Property(c => c.image).HasMaxLength(1000);
        }
    }
}
