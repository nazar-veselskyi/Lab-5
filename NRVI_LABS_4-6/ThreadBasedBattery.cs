using System.Threading;

namespace NRVI_LABS_4_6 {
    public class ThreadBasedBattery: BatteryBase {
        public ThreadBasedBattery() {
            Thread thread = new Thread(StartDischargeTimer);
            thread.Start();
        }

        public override void StartCharging() {
            if (ChargeTimer == null) {
                Thread thread = new Thread(SetUpChargeTimer);
                thread.Start();
            }
            else
                ChargeTimer.Enabled = true;
        }
    }
}
