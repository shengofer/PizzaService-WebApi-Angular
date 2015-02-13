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
    class OrderMapper : EntityTypeConfiguration<Order>
    {
        public OrderMapper()
        {
            this.ToTable("ORDERS");
            this.HasKey(o => o.id);
            this.Property(o => o.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(o => o.id).IsRequired();
            this.Property(o => o.activeStatus).IsRequired();

            this.HasOptional(o => o.customer).WithMany(o => o.orders).Map(s => s.MapKey("customerID")).WillCascadeOnDelete(false);
            this.HasOptional(o => o.pizza).WithMany(o => o.orders).Map(c => c.MapKey("PizzaID")).WillCascadeOnDelete(false);

        }
    }
}
