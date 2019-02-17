using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mid.Circuitry.CircuitryFlowController;

namespace Mid.Circuitry.U.Tests
{
    public class TestInitialize
    {
        [TestInitialize]
        public void Initialize()
        {
            Console.WriteLine(">> Starting up...");

            Console.WriteLine("Initializing Circuitry Unit Tests...");

            CFC.Initialize();

            Console.WriteLine("Circuitry Unit Tests Initialized.");

            Console.WriteLine("<< Exit.");
        }
    }
}
