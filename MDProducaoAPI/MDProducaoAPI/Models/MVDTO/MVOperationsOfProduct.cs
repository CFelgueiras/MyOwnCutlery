using System.Collections.Generic;

namespace MDProducaoAPI.Models.MVDTO
{
    public class MVOperationsOfProduct
    {
        public string ProductName { get; set; }
        
        public List<string> Operations { get; set; }

        public MVOperationsOfProduct(string productName, List<string> operations)
        {
            this.ProductName = productName;
            this.Operations = operations;
        }

        public MVOperationsOfProduct()
        {
        }

        public static List<MVOperationsOfProduct> FromList(List<List<string>> oplist)
        {
            List<MVOperationsOfProduct> listOfOperationsByProduct= new List<MVOperationsOfProduct>();
            

            foreach (var m in oplist)
            {
                MVOperationsOfProduct mvOpOfProd = new MVOperationsOfProduct();

                mvOpOfProd.ProductName = m[0];
                m.Remove(m[0]);
                List<string> temp = new List<string>();

                foreach (var op in m)
                {
                    temp.Add(op);
                }

                mvOpOfProd.Operations = temp;
                listOfOperationsByProduct.Add(mvOpOfProd);
            }



            return listOfOperationsByProduct;
        }
    }
}