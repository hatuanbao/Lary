using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lary.Models
{
    public class LaryDatabaseInitializer: CreateDatabaseIfNotExists<LaryDbContext>
    {
        protected override void Seed(LaryDbContext context)
        {
            base.Seed(context);
            
            context.SaveChanges();
        }
    }
}