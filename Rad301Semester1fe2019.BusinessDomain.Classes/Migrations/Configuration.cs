namespace Rad301Semester1fe2019.BusinessDomain.Classes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rad301Semester1fe2019.BusinessDomain.Classes.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rad301Semester1fe2019.BusinessDomain.Classes.Context context)
        {
            //  The data was seeded using the SQL server explorer interface
        }
    }
}
