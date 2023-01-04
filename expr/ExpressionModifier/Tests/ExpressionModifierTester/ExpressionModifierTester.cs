using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

using ExpressionModifier;

namespace ExpressionModifierTester
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ExpressionModifierTester
    {
        public ExpressionModifierTester()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        
        [TestMethod]
        public void TestSimpleFunction()
        {
            Expression<Func<double, double>> originalExpression = t => t * t * t + 20;

            Expression<Func<double, double>> substituteExpression = t => t * t;

            LambdaExpression modifiedExpression = originalExpression.Substitute("t", substituteExpression);

            Func<double, double> modifiedFunction =
               (Func<double, double>) modifiedExpression.Compile();

            Assert.AreEqual((int) modifiedFunction(1), 21);
            Assert.AreEqual((int) modifiedFunction(2), 2 * 2 * 2 * 2 * 2 * 2 + 20);
        }

        [TestMethod]
        public void TestComplexPolynomial()
        {
            Expression<Func<double, double>> originalExpression =
                (t) => (1 - t) * (1 - t) * (1 - t) * (-50) +
                        3 * (1 - t) * (1 - t) * t * (-25) +
                        3 * (1 - t) * t * t * 25 +
                        t * t * t * 50;

            Expression<Func<double, double, double, double>> substituteExpression = (t, factor, shift) => t * factor + shift;

            LambdaExpression modifiedExpression = originalExpression.Substitute("t", substituteExpression);

            Func<double, double, double, double> modifiedFunction = 
                (Func<double, double, double, double>) modifiedExpression.Compile();

            double result = modifiedFunction(1, 10, -9);
            Assert.AreEqual(result, 50);

            Console.WriteLine(originalExpression);
            Console.WriteLine();
            Console.WriteLine(modifiedExpression);
        }
    }
}
