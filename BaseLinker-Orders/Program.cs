using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace BaseLinker_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardKernel _standardKernel = new StandardKernel(new NinjectBindings());

            var _test = _standardKernel.Get<BTest>();

            string msg = _test.Insert();
            Console.WriteLine(msg);
            Console.ReadLine();

        }
    }
}
