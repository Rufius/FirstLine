using FirstLine.Task.Contracts;
using NUnit.Framework;

namespace FirstLine.Task.UTest
{
    public class CartServiceTests
    {
        private ICartService _cartService;
        Item item1 = null;
        Item item2 = null;
        Item item3 = null;

        [SetUp]
        public void Setup()
        {

            item1 = new Item("Vase", 1.2M, 0, 0);
            item2 = new Item("Big mug", 1, 1.5M, 2);
            item3 = new Item("Napkins pack", 0.45M, 0.90M, 3);
        }

        [Test]
        public void GetTotal_NoDiscount()
        {
            _cartService = new CartService();
            _cartService.Add(item1);
            _cartService.Add(item2);
            _cartService.Add(item3);

            decimal total = _cartService.GetTotal();

            Assert.AreEqual(item1.Price + item2.Price + item3.Price, total);

            _cartService.Remove(item2);

            total = _cartService.GetTotal();

            Assert.AreEqual(item1.Price + item3.Price, total);
        }

        [Test]
        public void GetTotal_WithDiscount()
        {
            _cartService = new CartService();

            _cartService.Add(item1);
            _cartService.Add(item1);

            _cartService.Add(item2);
            _cartService.Add(item2);
            _cartService.Add(item2);
            _cartService.Add(item2);
            _cartService.Add(item2);


            _cartService.Add(item3);
            _cartService.Add(item3);
            _cartService.Add(item3);

            decimal total = _cartService.GetTotal();
            Assert.AreEqual(7.3M, total);

            _cartService.Remove(item1);

            _cartService.Remove(item2);
            _cartService.Remove(item2);

            _cartService.Remove(item3);

            total = _cartService.GetTotal();

            Assert.AreEqual(4.6M, total);
        }
    }
}