using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureGameTests
{
    [TestFixture]
    public class ItemTests
    {
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _item = new Item(new string[] { "shovel", "spade" }, "a bronze sword", "A beautiful, sword made of bronze.");
        }

        [Test]
        public void TestIsIdentifiable()
        {
            Assert.IsTrue(_item.AreYou("shovel"));
            Assert.IsTrue(_item.AreYou("spade"));
            Assert.IsFalse(_item.AreYou("hammer"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("a bronze sword (shovel)", _item.ShortDesc);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("A beautiful, sword made of bronze.", _item.FullDesc);
        }
    }
}



