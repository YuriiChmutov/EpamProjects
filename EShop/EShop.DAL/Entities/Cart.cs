using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Entities
{
    //сущность, имитирующая работу корзины
    public class Cart
    {
        //коллекция для хранения списка покупок
        private List<CartLine> lineCollection = new List<CartLine>();

        //добавление продукта в корзину, с заданым количеством
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.ProductId == product.ProductId)
            .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {

                line.Quantity += quantity;
            }

        }

        //удаление продукта из корзины
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        //подсчет суммы стоимости
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        //чистка корзины
        public void Clear()
        {
            lineCollection.Clear();
        }

        //свойство считывания данных про корзину
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
        public class CartLine
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
