using FluentMigrator;

namespace serverT2.Infrastructure.Migrations.Versions
{
    [Migration(DataBaseVersions.TABLE_USER, "Create Table to save the user's information")]
    public class Version0000001 : VersionBase
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}
