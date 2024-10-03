using System;
using System.Numerics;
using System.Text;
using NUnit.Framework;
using SwinAdventure;


namespace SwinAdventureGameTests
{
	public class TestingInventory
	{
        Inventory _inventory;
        Item shovel;
        Item sword;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();

            shovel = new Item(new string[] { "shovel" }, "a shovel", "A shovel used for digging");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a dangerous sword");

            _inventory.Put(shovel);
            _inventory.Put(sword);

        }

        [Test]
        public void TestingFindItem()
        {
            Assert.True(_inventory.HasItem("shovel"));
            Assert.True(_inventory.HasItem("sword"));

            Assert.False(_inventory.HasItem("spade"));
            
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(_inventory.HasItem("gem"));
        }


        [Test]
        public void TestingFetchItem()
        {
             Item fetchedItem = _inventory.Fetch("shovel");
             Assert.AreSame(shovel, fetchedItem);
             Assert.True(_inventory.HasItem("shovel"));

        }

        [Test]
        public void TestingTakeItem()
        {
            Item fetchedItem = _inventory.Take("shovel");
            Assert.AreSame(shovel, fetchedItem);
            Assert.False(_inventory.HasItem("shovel"));
        }

        [Test]
        public void TestingItemList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\ta shovel (shovel)");
            sb.AppendLine($"\ta bronze sword (sword)");
            string expected = sb.ToString();

            string itemlist = _inventory.ItemList;

            Assert.AreEqual(expected, itemlist);

        }
    }
}

