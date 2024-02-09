namespace PruebasVariasTest
{
    [TestClass]
    public class Calculator
    {
        [TestMethod]
        public void Suma()
        {   
            var result = CnsPruebasVarias.Business.Calculator.Suma(2, 2);

            Assert.AreEqual(4, result);
        }
    }
}