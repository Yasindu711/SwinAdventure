using System;
using SwinAdventure;

namespace SwinAdventureGameTests
{
	public class TestLookCommand
	{
        Player karl;
        Item gem;
        Bag bag;
        LookCommand lookCommand;

        [SetUp]
        public void Setup()
        {
            karl = new Player("Karl", "the mighty explorer");
            gem = new Item(new string[] { "gem" }, "a red gem", "A bright red ruby the size of your fist!");
            bag = new Bag(new string[] { "bag" }, "leather backpack", "A small brown leather backpack");
            lookCommand = new LookCommand();

            karl.Inventory.Put(gem);
            bag.Inventory.Put(gem);
        }

        [Test]
        public void TestingLookAtMe()
        {
            string[] command = new string[] { "look", "at", "me" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(karl.FullDesc, result);
        }

        [Test]
        public void TestingLookAtGem()
        {
            karl.Inventory.Put(gem);

            string[] command = new string[] { "look", "at", "gem" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(gem.FullDesc, result);
        }

        [Test]
        public void TestingLookAtUnk()
        {
            karl.Inventory.Take("gem");

            string[] command = new string[] { "look", "at", "gem" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual("I can't find the gem", result);
        }

        [Test]
        public void TestingLookAtGemInMe()
        {
            karl.Inventory.Put(gem);

            string[] command = new string[] { "look", "at", "gem", "in", "me" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(gem.FullDesc, result);
        }

        [Test]
        public void TestingLookAtGemInBag()
        {
            karl.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            string[] command = new string[] { "look", "at", "gem", "in", "bag" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(gem.FullDesc, result);
        }

        [Test]
        public void TestingLookAtGemInNoBag()
        {
            karl.Inventory.Put(gem);

            string[] command = new string[] { "look", "at", "gem", "in", "bag" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual("I can't find the bag", result);
        }


        [Test]
        public void TestingLookAtNoGemInBag()
        {
            bag.Inventory.Take("gem");
            karl.Inventory.Put(bag);

            string[] command = new string[] { "look", "at", "gem", "in", "bag" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual("I can't find the gem", result);
        }

        [Test]
        public void TestingInvalidCommand()
        {
            //Test for invalid command length

            karl.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            string[] command = new string[] { "look", "around" };

            string result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual("I don't know how to look like that", result);


            //Test for first word in command

            command = new string[] { "hello", "at", "gem" };

            result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual("Error in look input", result);


            //Test for second word in command

            command = new string[] { "look", "up", "gem" };

            result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual("What do you want to look at?", result);


            //Test for fourth word in command
            command = new string[] { "look", "at", "a", "at", "b" };

            result = lookCommand.Execute(karl, command);

            Assert.IsNotEmpty(result);
            Assert.AreEqual("What do you want to look in?", result);

        }
    }
}

