using session3.Data;
using session3.Model;

namespace session3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbcontex = new ApplicationDbContext();
            //Add Data to Product Table
             Product p=new Product() {Name="Laptop",Price=1000 };
             dbcontex.products.Add(p);
             dbcontex.products.Add(new Product() { Name = "Apple watch",Price = 3000 });
             dbcontex.products.Add(new Product() { Name = "Phone", Price = 6000 });

            //Add Data to Order Table
            Order o1 = new Order() { Address = "Qalqilya", CreatedAt = new DateTime(2023, 8, 16, 20, 38, 0) };
             Order o2 = new Order() { Address = "Jenin", CreatedAt = DateTime.Parse("2024-03-8 12:40:00") };
             Order o3 = new Order { Address = "Ramallah", CreatedAt = new DateTime(2024, 10, 13, 2, 17, 4) };


             dbcontex.orders.Add(o1);
             dbcontex.orders.Add(o2);
             dbcontex.orders.Add(o3);
            dbcontex.SaveChanges();

            // Get All Products

            Console.WriteLine("Products : ");
            var products = dbcontex.products.ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }


            // Get All Orders

            Console.WriteLine("Orders : ");
            var orders = dbcontex.orders.ToList();
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id}, Address: {order.Address}, CreatedAt: {order.CreatedAt}");
            }
            var productsToUpdate = dbcontex.products.Where(p => p.Id == 1).FirstOrDefault();
            if (productsToUpdate != null)
            {
                productsToUpdate.Name = "Laptop";
                dbcontex.SaveChanges();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            dbcontex.SaveChanges();
            // Update Product Name 
            var ProductToUpdate = dbcontex.products.FirstOrDefault(P => P.Name== "Laptop");
            if (ProductToUpdate != null)
            {
                ProductToUpdate.Name = new string("Earphone");
                dbcontex.SaveChanges();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            dbcontex.SaveChanges();

            // Update Order CreatedAt
            var orderToUpdate = dbcontex.orders.FirstOrDefault(o => o.Id == 1);
            if (orderToUpdate != null)
            {
                orderToUpdate.CreatedAt = new DateTime(2023, 12, 31, 23, 59, 59);
                dbcontex.SaveChanges();
            }
            else
            {
                Console.WriteLine("Order not found.");
            }

            dbcontex.SaveChanges();

            //remove product with id 2
            dbcontex.Remove(dbcontex.products.First(p => p.Id == 2));

            //remove order with id 3
            dbcontex.Remove(dbcontex.orders.First(p => p.Id == 3));


            dbcontex.SaveChanges();
        }
    }
}