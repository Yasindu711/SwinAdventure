using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureGameTests
{
    public class TestIdentifiableObjects
    {
        IdentifiableObject _identifiableobj;

        [SetUp]
        public void Setup()
        {
            _identifiableobj = new IdentifiableObject(new string[] { "fred", "bob" });
        }

        [Test]
        public void TestingAreYou()
        {
            Assert.True(_identifiableobj.AreYou("fred"));
            Assert.True(_identifiableobj.AreYou("bob"));
        }

        [Test]
        public void TestingNotAreYou()
        {
            Assert.False(_identifiableobj.AreYou("wilma"));
            Assert.False(_identifiableobj.AreYou("boby"));
        }

        [Test]
        public void TesingCaseSensitive()
        {
            Assert.True(_identifiableobj.AreYou("FRED"));
            Assert.True(_identifiableobj.AreYou("bOb"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual("fred", _identifiableobj.FirstId);
        }

        [Test]
        public void TestFirstIdWithNoIds()
        {
            _identifiableobj = new IdentifiableObject(new string[] { });
            Assert.AreEqual("", _identifiableobj.FirstId);
        }

        [Test]
        public void TestAddId()
        {
            _identifiableobj.AddIdentifier("wilma");

            Assert.IsTrue(_identifiableobj.AreYou("fred"));
            Assert.IsTrue(_identifiableobj.AreYou("bob"));
            Assert.IsTrue(_identifiableobj.AreYou("wilma"));
        }
    }
}

