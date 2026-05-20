using ShoppingCartApp;

namespace ShoppingCartAppTests
{
    [TestClass]
    public class CartItemTests
    {
        [TestMethod]
        public void Constructor_ValidArguments()
        {
            var item = new CartItem("Apple", 1.50, 3);
            Assert.AreEqual("Apple", item.Name);
            Assert.AreEqual(1.50, item.UnitPrice);
            Assert.AreEqual(3, item.Quantity);
            {
                Assert.ThrowsException<ArgumentException>(() => new CartItem("", 1.50, 3));
                Assert.ThrowsException<ArgumentException>(() => new CartItem("ASD", 0, 3));
                Assert.ThrowsException<ArgumentException>(() => new CartItem("ASD", 1.50, 0));
            }
        }
        // TODO: null/üres name -> ArgumentException
        // TODO: unitPrice <= 0 -> ArgumentException
        // TODO: quantity <= 0 -> ArgumentException

        [TestMethod]
        public void GetTotal_MultipleQuantity()
        {
            var item = new CartItem("Banana", 0.75, 4);
            Assert.AreEqual(3.00, item.GetLineTotal());
        }

        [TestMethod]
        public void UpdateQuantity_ValidValue()
        {
            var item = new CartItem("Milk", 1.20, 1);
            item.UpdateQuantity(5);
            Assert.AreEqual(5, item.Quantity);
            Assert.ThrowsException<ArgumentException>(() => item.UpdateQuantity(-10));
        }
        // TODO: quantity <= 0 -> ArgumentException
    }

    [TestClass]
    public class ShoppingCartTests
    {
        private ShoppingCart CreateCartWithItems()
        {
            var cart = new ShoppingCart();
            cart.AddItem("Apple", 1.00, 3);
            cart.AddItem("Bread", 2.50, 1);
            return cart;
        }

        [TestMethod]
        public void AddItem_NewItem()
        {
            var cart = new ShoppingCart();
            cart.AddItem("Apple", 1.00, 2);
            Assert.AreEqual(2, cart.GetItemCount());
            cart.AddItem("Apple", 1.00, 2);
            Assert.AreEqual(4, cart.GetItemCount());
            Assert.ThrowsException<ArgumentException>(() => cart.AddItem("", 1.50, 2));
            Assert.ThrowsException<ArgumentException>(() => cart.AddItem("ASD", 0, 2));
            Assert.ThrowsException<ArgumentException>(() => cart.AddItem("ASD", 1.50, 0));
        }
        // TODO: ugyanolyan nevű item hozzáadása, mennyiséget növel annál az adott item-nél (nincs új item)
        // TODO: érvénytelen argumentumok -> ArgumentException

        [TestMethod]
        public void RemoveItem_ExistingItem()
        {
            var cart = CreateCartWithItems();
            cart.AddItem("Apple", 1.00, 2);
            bool result = cart.RemoveItem("Apple");
            bool result2 = cart.RemoveItem("apple");
            Assert.IsTrue(result);
            Assert.IsTrue(result2);
            Assert.AreEqual(1, cart.GetItemCount());
        }
        // TODO: nem létező item -> false
        // TODO: törlés kis-nagybetű független-e ("apple" törli az "Apple"-t)

        [TestMethod]
        public void GetTotal_MultipleItems()
        {
            var cart = new ShoppingCart();
            cart.AddItem("Apple", 1.00, 3);  // 3.00
            cart.AddItem("Bread", 2.50, 2);  // 5.00
            Assert.AreEqual(8.00m, cart.GetTotal());
            cart.RemoveItem("apple");
            cart.RemoveItem("bread");
            Assert.AreEqual(0.00m, cart.GetTotal());
        }
        // TODO: üres kosár -> 0
        // TODO: item törlése után helyes-e az összeg

        [TestMethod]
        public void Clear_CartWithItems()
        {
            var cart = CreateCartWithItems();
            cart.Clear();
            Assert.AreEqual(0, cart.GetItemCount());
            Assert.AreEqual(0m, cart.GetTotal());
            cart.Clear();
        }
        // TODO: üres kosáron Clear() nem dob kivételt
    }

    [TestClass]
    public class DiscountTests
    {
        [TestMethod]
        public void ApplyPercentage_TenPercent()
        {
            var discount = new Discount();
            Assert.AreEqual(180, discount.ApplyPercentage(200, 10));
            Assert.AreEqual(180, discount.ApplyPercentage(180, 0));
            Assert.AreEqual(0, discount.ApplyPercentage(180, 100));
            Assert.ThrowsException<ArgumentException>(()=> discount.ApplyPercentage(180, 192));
        }
        // TODO: 0% -> változatlan összeg
        // TODO: 100% -> 0
        // TODO: percent > 100 -> ArgumentException

        [TestMethod]
        public void ApplyFixed_AmountLessThanTotal()
        {
            var discount = new Discount();
            Assert.AreEqual(75, discount.ApplyFixed(100, 25));
            Assert.AreEqual(0, discount.ApplyFixed(100, 100));
            Assert.AreEqual(0, discount.ApplyFixed(100, 125));
            Assert.ThrowsException<ArgumentException>(() => discount.ApplyFixed(100, -125));
        }
        // TODO: kedvezmény > total -> 0 (nem negatív)
        // TODO: negatív discountAmount -> ArgumentException

        [TestMethod]
        public void IsValid_PositiveValue()
        {
            var discount = new Discount();
            Assert.IsTrue(discount.IsValid(15));
            Assert.IsTrue(discount.IsValid(1));
            Assert.IsTrue(discount.IsValid(0.000001));
            Assert.IsTrue(!discount.IsValid(0));
            Assert.IsTrue(!discount.IsValid(-5));
        }
        // TODO: 0 -> false
        // TODO: negatív -> false
    }
}
