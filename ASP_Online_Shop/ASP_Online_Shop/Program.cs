using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASP_Online_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта Product
                Product Product1 = new Product { Name = "Лосины BonaFide", Cost = 3500 };
                Product Product2 = new Product { Name = "Протеиновый батончик 50гр", Cost = 100 };

                // добавляем их в бд
                db.Products.Add(Product1);
                db.Products.Add(Product2);
                db.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
