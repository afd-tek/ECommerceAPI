using System;
using System.Collections.Generic;
using System.IO;
using BiSanat.DAL.Entities;
using BiSanat.DAL.Repositories;
using BiSanat.DAL.Repositories.Concrete.EFCore;

namespace BiSanat.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductDAL productDal = new ProductDAL(new BiContext());
            IList<Product> products = productDal.GetList();
            for(int i =0 ;i<products.Count;i++)
            {
                Byte[] bytes = File.ReadAllBytes($"C:/Users/Ahmet/Desktop/biRes/bimages/{products[i].Id}.jpg");
                String file = Convert.ToBase64String(bytes);
                products[i].Image = file;
                productDal.Update(products[i]);
            }
        }
    }
}
