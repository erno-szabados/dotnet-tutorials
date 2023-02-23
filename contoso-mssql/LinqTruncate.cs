using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace Contoso
{
    public static class LinqExtension
    {
        // This is not necessary in EF Core 7+, use ExecuteDelete instead!
        public static void Truncate<T>(this DbSet<T> dbSet) where T : class
        {
            var ctx = dbSet.GetService<ICurrentDbContext>().Context;
            var entityType = typeof(T);
            var m = ctx.Model.FindEntityType(entityType);
            var tableName = m?.GetSchemaQualifiedTableName();
            if (tableName is not null)
            {
                if (ctx.Database.IsSqlServer())
                {
                    // This is slow, but works with FKs (unlike TRUNCATE).
                    var sqlCommand = $"DELETE FROM {tableName} DBCC CHECKIDENT({tableName}, RESEED, 0)";
                    ctx.Database.ExecuteSqlRaw(sqlCommand);
                }
            }
        }
    }
}
