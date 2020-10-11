using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OborudDataBase.Model
{

   
  public  class DB : DbContext
    {

        //private const string DatabaseConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OborudDB;Integrated Security=True";
        public DB() : base("DB") { }// (DatabaseConnectionString) { }

        public DbSet<Oboruds> Oboruds { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<TypesVariant> TypesVariants        { get; set; }
        public DbSet<ParamValue> ParamValues { get; set; }
        public DbSet<Oborud_TypeVal> oborud_TypeVals { get; set; }
        public DbSet<Parameters> Parameters { get; set; }

       // public DbSet<Oborud_Group> oborud_Groups { get; set; }
        public DbSet<ParamTypes> paramTypes { get; set; }
        public DbSet<Location> locations { get; set; }
    }
}
