using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLinker_Orders
{
    class BTest
    {

        private readonly ITest _test;
        public BTest(ITest test)
        {
            _test = test;

        }

        public string Insert()
        {
            return _test.InsertTest();
        }
    }
}
