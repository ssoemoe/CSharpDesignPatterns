using System;

///<summary>
/// Decorator pattern combines all necessary layers in the runtime.
/// Decorator class constructors take in the same type of instance.
/// The pattern is an example of open/closed principle of SOLID.
/// Open for extension but closed for modification
///</summary>
namespace CSharpDesignPatterns.StructuralPatterns
{

    public class Decorator
    {
        public static void DecoratorPatternTest()
        {
            var product1 = new NormalProduct
            {
                Price = 100,
                TaxPercent = 8
            };
            var discountProduct = new DiscountProduct(product1) { DiscountPercent = 4 };
            var product2 = new NormalProduct
            {
                Price = 200,
                TaxPercent = 8
            };
            var premiumProduct = new PremiumProduct(product2) { PremiumPrice = 25 };
            Console.WriteLine($"Total price of product on discount is {discountProduct.CalculateTotalPrice()}");
            Console.WriteLine($"Total price of premium product is {premiumProduct.CalculateTotalPrice()}");
        }

        public abstract class Product
        {
            public double Price { get; set; }
            public abstract double CalculateTotalPrice();
        }

        public class NormalProduct : Product
        {
            public double TaxPercent { get; set; }

            public override double CalculateTotalPrice()
            {
                return (Price * TaxPercent / 100.0) + Price;
            }
        }

        public class DiscountProduct : Product
        {
            public double DiscountPercent { get; set; }
            public Product Product { get; private set; }
            public DiscountProduct(Product product)
            {
                Product = product;
            }
            public override double CalculateTotalPrice()
            {
                Product.Price -= Product.Price * DiscountPercent / 100.0;
                return Product.CalculateTotalPrice();
            }
        }

        public class PremiumProduct : Product
        {
            public double PremiumPrice { get; set; }
            public Product Product { get; private set; }
            public PremiumProduct(Product product)
            {
                Product = product;
            }

            public override double CalculateTotalPrice()
            {
                return Product.CalculateTotalPrice() + PremiumPrice;
            }
        }
    }
}