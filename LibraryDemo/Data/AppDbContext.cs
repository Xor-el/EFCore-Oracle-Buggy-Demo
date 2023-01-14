using LibraryDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace LibraryDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureOracleDbFunctions(builder);

            builder.Entity<Book>().Property(e => e.Metadata)
                    .HasColumnType("CLOB")
                    .HasColumnName("Metadata");
            // Define relationship between books and authors
            builder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books);

            // Seed database with authors and books for demo
            new DbInitializer(builder).Seed();
        }

        private static void ConfigureOracleDbFunctions(ModelBuilder builder)
        {
            var jsonValueMethodInfo = typeof(OracleDbFunctions).GetMethod(nameof(OracleDbFunctions.JsonValue), new[] { typeof(string), typeof(string) })!;

            builder.HasDbFunction(jsonValueMethodInfo)
                        .HasTranslation(args =>
                        {
                            return new SqlFunctionExpression(functionName: "JSON_VALUE",
                                                             arguments: args,
                                                             nullable: true,
                                                             argumentsPropagateNullability: new[] { false, false },
                                                             type: jsonValueMethodInfo.ReturnType,
                                                             typeMapping: null);
                        });

            // <======== Workaround =========>
            //builder.HasDbFunction(jsonValueMethodInfo)
            //.HasTranslation(args =>
            //{
            //    var newArgs = args.ToList();
            //    newArgs[1] = new SqlFragmentExpression($"'{(newArgs[1] as SqlConstantExpression)?.Value as string}'");

            //    return new SqlFunctionExpression(functionName: "JSON_VALUE",
            //                                     arguments: newArgs,
            //                                     nullable: true,
            //                                     argumentsPropagateNullability: new[] { false, false },
            //                                     type: jsonValueMethodInfo.ReturnType,
            //                                     typeMapping: null);
            //});
        }
    }
}
