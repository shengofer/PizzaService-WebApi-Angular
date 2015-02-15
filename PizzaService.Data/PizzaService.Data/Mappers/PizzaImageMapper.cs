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
    class PizzaImageMapper: EntityTypeConfiguration<PizzaImage>
    {
        public PizzaImageMapper()
        {
            this.ToTable("IMAGES");
            this.HasKey(o => o.id);
            this.Property(o => o.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(o => o.id).IsRequired();

            this.Property(s => s.path).IsRequired();
            this.Property(s => s.path).HasMaxLength(255);
            
        }
    }
}
