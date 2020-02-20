using System.Collections.Generic;
using MDProducaoAPI.Models.ValueObjects;

namespace MDProducaoAPI.Models.MVDTO
{
    public class MVProduct
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ManPlan { get; set; }

        public MVProduct() { }

        public MVProduct(long id, string name, string manPlan)
        {
            this.Id = id;
            this.Name = name;
            this.ManPlan = manPlan;
        }

        public static MVProduct FromFull(Product p)
        {
            return new MVProduct(p.ProductId, p.Name.name, p.ManPlan.Name.name);
        }

        public static MVProduct From(Product p)
        {
            return new MVProduct(p.ProductId, p.Name.name, p.ManPlan.Name.name);
        }
        
        public static List<MVProduct> FromList(List<Product> prods)
        {
            List<MVProduct> prodlist = new List<MVProduct>();

            foreach (var p in prods)
            {
                MVProduct mVProduct = new MVProduct();
                mVProduct.Id = p.ProductId;
                mVProduct.Name = p.Name.name;
                mVProduct.ManPlan = p.ManPlan.Name.name;
                prodlist.Add(mVProduct);
            }
            return prodlist;
        }
        
        public static string[] ListProducts(List<Product> pls)
        {
            string[] plArray = new string[pls.Count];

            List<string> plNames = new List<string>();

            foreach(var pl in pls) {
                plNames.Add(pl.Name.name);
            }

            plNames.CopyTo(plArray);

            return plArray;
        }
    }
}