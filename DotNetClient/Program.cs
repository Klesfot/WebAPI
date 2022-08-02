using System.Net.Http.Headers;
using System.Net.Http.Json;
using DotNetClient.Models;

namespace DotNetClient
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}\t" +
                                  $"Name: {product.ProductName}\t" +
                                  $"Category id: {product.CategoryId}\t" +
                                  $"Unit price: {product.UnitPrice}\t" +
                                  $"Units in stock: {product.UnitsInStock}");
            }
        }

        static void ShowCategories(List<Category> categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine($"\n\nId: {category.Id}\t" +
                                  $"Name: {category.CategoryName}\t" +
                                  $"Description: {category.Description}\t" +
                                  $"Image link: {category.ImageLink}\t");
            }
        }

        static async Task<List<Product>> GetProductsAsync(string url)
        {
            var products = new List<Product>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadFromJsonAsync<List<Product>>();
            }
            return products;
        }

        static async Task<List<Category>> GetCategoriesAsync(string url)
        {
            var categories = new List<Category>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                categories = await response.Content.ReadFromJsonAsync<List<Category>>();
            }
            return categories;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:7150/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var productsUrl = "https://localhost:7150/api/products/";
                var categoriesUrl = "https://localhost:7150/api/categories/";
                
                var productList = await GetProductsAsync(productsUrl);
                ShowProducts(productList);
                var categoriesList = await GetCategoriesAsync(categoriesUrl);
                ShowCategories(categoriesList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}