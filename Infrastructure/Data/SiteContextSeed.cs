using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class SiteContextSeed
    {
        public static async Task SeedAsync(SiteContext context) {
            if (!context.Brands.Any()) {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                foreach (var item in brands) {
                    context.Brands.Add(item);
                }
            }

            if (!context.Types.Any()) {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                foreach (var item in types) {
                    context.Types.Add(item);
                }
            }

            if (!context.Products.Any()) {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                foreach (var item in products) {
                    context.Products.Add(item);
                }
            }

            if (context.ChangeTracker.HasChanges()) {
                await context.SaveChangesAsync();
            }
        }
    }
}