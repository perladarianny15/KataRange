using NUnit.Framework;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Test1();
        }

        [Test]
        public void Test1()
        {
            var message = "hola";
            var mm = string.Empty;
            Assert.IsFalse(string.IsNullOrWhiteSpace(message));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mm));

        }
    }
}