using System;
using NUnit.Framework;

namespace Demo.Tests
{
    [TestFixture]
    public class PersonTests
    {

        [Test]
        public void DoesMyNameWorkProperly()
        {
            Person person = new Person("Yovko");


            string expectedResult = "Yovko";
            string actualResult = person.WhatsMyName();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
