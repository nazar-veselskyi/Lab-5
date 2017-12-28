using System.Threading.Tasks;

namespace NazarVeselskyi.Threading {
    public class TaskBasedBattery: BatteryBase {
        public TaskBasedBattery() {
            Task.Run( ()=> StartDischargeTimer() );
        }

        public override void StartCharging() {
            if (ChargeTimer == null)
                Task.Run(() => SetUpChargeTimer());
            else
                ChargeTimer.Enabled = true;
        }
    }
}
