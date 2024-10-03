using System.Text;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureGameTests
{
    public class BagTests
    {
        Bag bag;

        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[] { "bag" }, "leather backpack", "A small brown leather backpack");

            Item gem = new Item(new string[] { "gem" }, "a red gem", "A bright red ruby the size of your fist!");
            bag.Inventory.Put(gem);
        }

        [Test]
        public void TestingBagLocatesItems()
        {
            GameObject gem = bag.Locate("gem");

            Assert.NotNull(gem);
            Assert.True(gem.AreYou("gem"));
            Assert.True(bag.Inventory.HasItem("gem"));
        }

        [Test]
        public void TestingBagLocatesItself()
        {
            GameObject obj = bag.Locate("bag");

            Assert.NotNull(obj);
            Assert.True(obj.AreYou("bag"));
            Assert.AreEqual("leather backpack", obj.Name);
        }

        [Test]
        public void TestingBagLocatesNothing()
        {
            GameObject obj = bag.Locate("coin");

            Assert.Null(obj);
        }

        [Test]
        public void TestingBagfullDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("In the leather backpack you can see:");
            sb.Append("\ta red gem (gem)");

            Assert.AreEqual(sb.ToString().TrimEnd(), bag.FullDesc.TrimEnd());
        }


        [Test]
        public void TestBagInBag()
        {
            Bag b1 = new Bag(new string[] { "bag1" }, "bag1", "a bag");
            Bag b2 = new Bag(new string[] { "bag2" }, "bag2", "a bag");

            b1.Inventory.Put(b2);

            Assert.AreEqual(b2, b1.Locate("bag2"));
            Assert.IsNull(b2.Locate("sword"));

            Item sword = new Item(new string[] { "sword" }, "a sword", "a sharp sword");
            b1.Inventory.Put(sword);
            Assert.AreEqual(sword, b1.Locate("sword"));
        }

    }
}

