using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class ShoppingCartCatalog
    {
        public List<Product> _cartList;

        public ShoppingCartCatalog()
        {
            _cartList = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _cartList.Add(product);
        }

        public void RemoveProduct(int id)
        {
            foreach (var product in _cartList)
            {
                if (product.Id == id)
                {
                    _cartList.Remove(product);
                    break;
                }
            }
        }

        public double TotalPrice()
        {
            double totalPrice = 0;
            foreach (var product in _cartList)
            {
                totalPrice = totalPrice + product.Price;
            }

            return totalPrice;
        }
    }
}
