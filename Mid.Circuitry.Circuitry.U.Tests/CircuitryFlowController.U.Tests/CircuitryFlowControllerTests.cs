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
    public class CircuitryFlowControllerTests : BaseTestClass
    {

        #region Tests
        [TestMethod]
        public void TestNodeTraversal()
        {
            Circuit testCircuit = createTestCircuit01();

            RegisterCircuit(testCircuit);
            StepThroughCircuit(testCircuit.StartingNodeId);

            // Make sure every pin has been turned on by the NodeTraversal logic
            foreach (Node node in testCircuit.Nodes)
            {
                Assert.IsTrue(NodeTable.ContainsKey(node.NodeId));
                foreach (Pin pin in node.Pins)
                {
                    Assert.IsTrue(PinTable.ContainsKey(pin.PinId));
                    Assert.AreEqual(pin.State, StateEnum.ON);
                }
            }

            ClearAllTables();
        }

        [TestMethod]
        public void TestArrowCreation()
        {
            Circuit testCircuit = createTestCircuit01();

            RegisterCircuit(testCircuit);
            StepThroughCircuit(testCircuit.StartingNodeId);

            // Make sure a route is built
            //TODO implement arrow logic in order to visualize the flow
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Basic Circuit with 1 LED
        /// </summary>
        private Circuit createTestCircuit01()
        {
            PowerSource threeVolt = new PowerSource();
            TwoPinLED led = new TwoPinLED();
            Gpio gpio = new Gpio(17);

            threeVolt.On();

            // connect threevolt to anode
            threeVolt.AddRoute(threeVolt.PowerPin.PinId, led.Anode.PinId);

            // connect cathode to gpio
            led.AddRoute(led.Cathode.PinId, gpio.GpioPin.PinId);

            // no route needed at gpio (end node)

            // run through the circuit and try anurn each pin on
            return new Circuit(threeVolt.NodeId, new List<Node> { threeVolt, led, gpio }, "TestCircuit");
        }
        #endregion
    }
}
