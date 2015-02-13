﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace PizzaService.Data
{
    class PizzaContextMigrationConfiguration : DbMigrationsConfiguration<PizzaContext>
    {
        public PizzaContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

#if DEBUG
        protected override void Seed(PizzaContext context)
        {
            new PizzaDataSeeder(context).Seed();
        }
#endif
    }
}
