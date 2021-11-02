using FluentMigrator;

namespace Persistence.Migrations
{
    [Migration(202110131930)]
    public class AddExerciseTable : Migration
    {
        public override void Up()
        {
            Create.Table("Exercise")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Image").AsBinary().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Exercise");
        }
    }
}
