using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mid.Circuitry.U.Tests;
using Mid.Circuitry.Shared;
using Mid.Circuitry.Shared.ComplexObjects;
using Mid.Circuitry.Shared.CircuitryToolbox;
using static Mid.Circuitry.CircuitryFlowController.CFC;

namespace Mid.Circuitry.Circuitry.U.Tests.CircuitryFlowController
{
    [TestClass]
    public class CircuitryFlowControllerTests : TestInitialize
    {
        [TestMethod]
        public void TestCircuit1()
        {
            // TODO Setup 01 basic Circuit with LED

            PowerSource threeVolt = new PowerSource();

            TwoPinLED led = new TwoPinLED();

            // connect threeVolt to anode
            ConnectPin(threeVolt, threeVolt.Pin.PinId, led.Anode.PinId);

            GPIO gpio = new GPIO(17);

            // connect cathode to gpio
            ConnectPin(led, led.Cathode.PinId, gpio.Pin.PinId);

            //Assert.AreEqual(true, true);
        }
    }
}
