using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            int idade = 20;

            if (idade > 18)
                Assert.IsTrue(true);
            else
                Assert.IsFalse(false);
        }
    }
}
