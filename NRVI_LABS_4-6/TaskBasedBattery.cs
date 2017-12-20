using System.Threading.Tasks;

namespace NRVI_LABS_4_6 {
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
