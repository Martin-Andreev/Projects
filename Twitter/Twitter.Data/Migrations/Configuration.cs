namespace Twitter.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Data;

    public sealed class Configuration : DbMigrationsConfiguration<TwitterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TwitterContext";
        }

        protected override void Seed(TwitterContext context)
        {
        }
    }
}
