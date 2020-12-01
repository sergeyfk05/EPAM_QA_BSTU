using System;
using System.Collections.Generic;
using System.Text;

namespace DellPages
{
    public class Product
    {
        public string Title { get; set; }
        public int Count { get; set; }
        public double Subtotal { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Title == product.Title &&
                   Count == product.Count &&
                   Subtotal == product.Subtotal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Count, Subtotal);
        }
    }
}
