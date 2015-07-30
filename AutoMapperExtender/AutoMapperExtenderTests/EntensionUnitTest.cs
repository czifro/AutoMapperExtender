using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExtenderTests
{
    [TestClass]
    public class EntensionUnitTest
    {
        [TestMethod]
        public void TestIgnoreExtraProperties()
        {
            AutoMapperConfig.ConfigureIgnoreExtraProperties();
            var c = new C
            {
                Prop1 = "Test",
                Prop2 = "Another Test"
            };
            var a = Mapper.Map<A>(c);

            Assert.IsTrue(a.Prop1 == c.Prop1 && a.Prop2 == c.Prop2 && a.Prop3 == null);
        }

        [TestMethod]
        public void TestMapFromProperty()
        {  
            AutoMapperConfig.ConfigureMapFromProperty();
            var b = new B
            {
                PropA = new A
                {
                    Prop1 = "Test",
                    Prop2 = "Another Test",
                    Prop3 = "Yet Another Test"
                }
            };

            var a = Mapper.Map<A>(b);
            var temp = a;
        }
    }
}
