
using Microsoft.EntityFrameworkCore;

namespace refund.Utilities
{
    public static class ModelBuilderExtensions
    {
         public static void ApplyDecimalPrecision(this ModelBuilder modelBuilder, int precision, int scale)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var decimalProperties = entityType.GetProperties()
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

            foreach (var property in decimalProperties)
            {
                property.SetColumnType($"decimal({precision},{scale})");
            }
        }
    }
    }
}