using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiraSerieSolution.Test
{
    using NUnit.Framework;
    
    [TestFixture]
    class TestArithmeticPipeline
    {
        [Test]
        public void test_loaded_in_list_one_element(){
            List<IArrayOperation> actual = XLoader.Load("AddValue");
            Assert.AreEqual(1, actual.Count);
        }

        [Ignore]
        public void test_empty_loaded_list() {
            List<IArrayOperation> actual = XLoader.Load(null);
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void test_loaded_in_list_three_element()
        {
            List<IArrayOperation> actual = XLoader.Load("AddValue", "SubValue", "DivValue");
            Assert.AreEqual(3, actual.Count);
        }
         

    }
}
