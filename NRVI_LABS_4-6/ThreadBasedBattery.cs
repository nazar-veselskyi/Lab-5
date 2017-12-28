using System.Threading;

namespace NazarVeselskyi.Threading {
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
