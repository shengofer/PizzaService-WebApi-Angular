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
    class CustomerMapper : EntityTypeConfiguration<Customer>
    {
        public CustomerMapper()
        {
            this.ToTable("CUSTOMERS");
            this.HasKey(s => s.id);
            this.Property(s => s.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.id).IsRequired();

            this.Property(s => s.email).IsRequired();
            this.Property(s => s.email).HasMaxLength(255);
            this.Property(s => s.email).IsUnicode(false);

            this.Property(s => s.username).IsRequired();
            this.Property(s => s.username).HasMaxLength(50);
            this.Property(s => s.username).IsUnicode(false);

            this.Property(s => s.password).IsRequired();
            this.Property(s => s.password).HasMaxLength(255);

            this.Property(s => s.role).IsRequired();
  
        }
    }
}
