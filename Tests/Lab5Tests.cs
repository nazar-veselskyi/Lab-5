using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NazarVeselskyi.Threading;

namespace Tests {
    [TestClass]
    public class Lab5Tests {

        [TestMethod]
        public void TestTaskBasedChargeTopBoundsInOneUpdate() {
            BatteryBase battery = new TaskBasedBattery();

            battery.UpdateCharge(101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestTaskBasedChargeBottomBoundsInOneUpdate() {
            BatteryBase battery = new TaskBasedBattery();

            battery.UpdateCharge(-101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestTaskBasedChargeTopBoundsInManyUpdates() {
            BatteryBase battery = new TaskBasedBattery();

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestTaskBasedChargeBottomBoundsInManyUpdates() {
            BatteryBase battery = new TaskBasedBattery();

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(-1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestThreadBasedChargeTopBoundsInOneUpdate() {
            BatteryBase battery = new ThreadBasedBattery();

            battery.UpdateCharge(101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestThreadBasedChargeBottomBoundsInOneUpdate() {
            BatteryBase battery = new ThreadBasedBattery();

            battery.UpdateCharge(-101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestThreadBasedChargeTopBoundsInManyUpdates() {
            BatteryBase battery = new ThreadBasedBattery();

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestThreadBasedChargeBottomBoundsInManyUpdates() {
            BatteryBase battery = new ThreadBasedBattery();

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(-1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestDischargingThreadBased() {
            BatteryBase battery = new ThreadBasedBattery();
            int startCharge = battery.Charge;
            Thread.Sleep(3000);
            Assert.IsTrue(battery.Charge < startCharge);
        }

        [TestMethod]
        public void TestChargingThreadBased() {
            BatteryBase battery = new ThreadBasedBattery();
            int startCharge = battery.Charge;
            battery.StartCharging();
            Thread.Sleep(3000);
            Assert.IsTrue(battery.Charge > startCharge);
        }

        [TestMethod]
        public void TestDischargingTaskBased() {
            BatteryBase battery = new TaskBasedBattery();
            int startCharge = battery.Charge;
            Thread.Sleep(3000);
            Assert.IsTrue(battery.Charge < startCharge);
        }

        [TestMethod]
        public void TestChargingTaskBased() {
            BatteryBase battery = new TaskBasedBattery();
            int startCharge = battery.Charge;
            battery.StartCharging();
            Thread.Sleep(3000);
            Assert.IsTrue(battery.Charge > startCharge);
        }
    }
}
