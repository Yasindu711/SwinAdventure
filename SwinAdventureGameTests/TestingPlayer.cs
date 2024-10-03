using System;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureGameTests
{
    public class PlayerTests
    {
        Player _player;
        Item _shovel;
        Item _sword;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Karl", "the mighty explorer");
            _shovel = new Item(new string[] { "shovel", "blade" }, "a shovel", "A mighty, shovel.");
            _sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a deadly sword");

            _player.Inventory.Put(_shovel);
            _player.Inventory.Put(_sword);

           
        }


        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItem()
        {
            GameObject locatedItem = _player.Locate("shovel");

            Assert.NotNull(locatedItem);
            Assert.AreSame(_shovel, locatedItem);


            locatedItem = _player.Locate("sword");

            Assert.NotNull(locatedItem);
            Assert.AreSame(_sword, locatedItem);
        }

        [Test]
        public void TestPlayerLocatesItSelf()
        {
            GameObject player = _player.Locate("me");
            Assert.NotNull(player);
            Assert.AreEqual(_player, player);

            player = _player.Locate("inventory");
            Assert.NotNull(player);
            Assert.AreEqual(_player, player);

        }


        [Test]
        public void TestPlayerLocatesNothing()
        {
            GameObject obj = _player.Locate("club");
            Assert.IsNull(obj);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"You are Karl, the mighty explorer.");
            sb.AppendLine($"You are carrying:");
            sb.AppendLine($"\ta shovel (shovel)");
            sb.AppendLine($"\ta bronze sword (sword)");

            string expectedDescription = sb.ToString();

            Assert.AreEqual(expectedDescription, _player.FullDesc);
        }

    }
}
