using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRVI_LABS_4_6;

namespace Tests {
    [TestClass]
    public class Lab5Tests {
        [TestMethod]
        public void TestChargeBounds() {
            BatteryBase battery = new TaskBasedBattery();

            battery.UpdateCharge(101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);

            battery.UpdateCharge(-101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(-1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);

            battery = new ThreadBasedBattery();

            battery.UpdateCharge(101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);

            battery.UpdateCharge(-101);
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);

            for (int i = 0; i < 101; i++) {
                battery.UpdateCharge(-1);
            }
            Assert.IsTrue(battery.Charge <= 100 && battery.Charge >= 0);
        }

        [TestMethod]
        public void TestChargingDischargingThreadBased() {
            BatteryBase battery = new ThreadBasedBattery();
            int prevCharge = battery.Charge;
            int startCharge = battery.Charge;

            for (int i = 0; i < 10; i++) {
                Thread.Sleep(1000);
                Assert.IsTrue(battery.Charge <= prevCharge);
                prevCharge = battery.Charge;
            }

            Assert.IsTrue(battery.Charge < startCharge);

            battery.StartCharging();
            startCharge = battery.Charge;

            for (int i = 0; i < 10; i++) {
                Thread.Sleep(1000);
                Assert.IsTrue(battery.Charge >= prevCharge);
                prevCharge = battery.Charge;
            }

            Assert.IsTrue(battery.Charge > startCharge);
        }

        [TestMethod]
        public void TestChargingDischargingTaskBased() {
            BatteryBase battery = new TaskBasedBattery();
            int prevCharge = battery.Charge;
            int startCharge = battery.Charge;

            for (int i = 0; i < 10; i++) {
                Thread.Sleep(1000);
                Assert.IsTrue(battery.Charge <= prevCharge);
                prevCharge = battery.Charge;
            }

            Assert.IsTrue(battery.Charge < startCharge);

            battery.StartCharging();
            startCharge = battery.Charge;

            for (int i = 0; i < 10; i++) {
                Thread.Sleep(1000);
                Assert.IsTrue(battery.Charge >= prevCharge);
                prevCharge = battery.Charge;
            }

            Assert.IsTrue(battery.Charge > startCharge);
        }
    }
}
