using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

using CPUVisNEA.Properties;

namespace CPUVisNEA
{
    [TestFixture]
    
    public class TestConsole
    {
        //generating new CPU
        private CPU cpu = new CPU();
        
        [Test]
        public void TestofTests()
        {
            Console.WriteLine("Thou doth work with great fanciness ");
        }
        
    }
}