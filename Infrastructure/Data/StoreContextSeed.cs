﻿using Core.Entities.Product;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
  public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext,ILoggerFactory loggerFactory )
        {
            try
            {
                if(!storeContext.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsData);
                    foreach (var item in brands)
                    {
                        storeContext.ProductBrands.Add(item);
                    }
                    await storeContext.SaveChangesAsync();

                }
                if (!storeContext.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        storeContext.ProductTypes.Add(item);
                    }
                    await storeContext.SaveChangesAsync();

                }
                if (!storeContext.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        storeContext.Products.Add(item);
                    }
                    await storeContext.SaveChangesAsync();

                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
            
            
  }
}
