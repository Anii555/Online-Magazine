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
                // ������� ��� ������� Product
                Product Product1 = new Product { Name = "������ BonaFide", Cost = 3500 };
                Product Product2 = new Product { Name = "����������� �������� 50��", Cost = 100 };

                // ��������� �� � ��
                db.Products.Add(Product1);
                db.Products.Add(Product2);
                db.SaveChanges();
                //Console.WriteLine("������� ������� ���������");

                // �������� ������� �� �� � ������� �� �������
                var Products = db.Products.ToList();
                //Console.WriteLine("������ ��������:");
                //foreach (Product u in Products)
                //{
                //    Console.WriteLine($"{u.Id}.{u.Name} - {u.Cost}");
                //}
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
