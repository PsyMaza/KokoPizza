using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KokoPizza.Identity.Extensions;

public static class ConvertToSnakeCaseExtension
{
    public static void ConvertToSnakeCase(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var schema = entity.GetSchema();
            var tableName = entity.GetTableName();
            var storeObjectIdentifier = StoreObjectIdentifier.Table(tableName, schema);

            entity.SetTableName(tableName.ToSnakeCase());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName(storeObjectIdentifier).ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }

            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.Name.ToSnakeCase());
            }
        }
    }
}