using System;
using System.Timers;

namespace NRVI_LABS_4_6 {
    public abstract class BatteryBase {
        public int Charge { get; set; }
        private System.Timers.Timer _dischargeTimer;
        protected System.Timers.Timer ChargeTimer;
        private readonly object _lockObject = new object();

        public delegate void ChargeChangedDelegate(int newCharge);
        public event ChargeChangedDelegate OnChargeChanged;

        protected BatteryBase() {
            Charge = 58;
            RaiseChargeChangedEvent(Charge);
        }

        public void UpdateCharge(int chargeDelta) {
            lock (_lockObject) {
                int newValue = Charge + chargeDelta;
                if (newValue < 0 || newValue > 100)
                    return;

                Charge = newValue;
                RaiseChargeChangedEvent(Charge);
            }
        }

        private void RaiseChargeChangedEvent(int newCharge) {
            var handler = OnChargeChanged;
            if (handler != null)
                handler(newCharge);
        }

        private void DoDischarge(object obj, ElapsedEventArgs args) {
            UpdateCharge(-1);
            Console.WriteLine("Discharge: " + Charge);
        }

        private void DoCharge(object obj, ElapsedEventArgs args) {
            UpdateCharge(1);
            Console.WriteLine("Charge: " + Charge);
        }
        protected void StartDischargeTimer() {
            _dischargeTimer = new System.Timers.Timer(2000);
            _dischargeTimer.Elapsed += DoDischarge;
            _dischargeTimer.AutoReset = true;
            _dischargeTimer.Enabled = true;
        }
        protected void SetUpChargeTimer() {
            ChargeTimer = new System.Timers.Timer(900);
            ChargeTimer.Elapsed += DoCharge;
            ChargeTimer.AutoReset = true;
            ChargeTimer.Enabled = true;
        }

        public abstract void StartCharging();

        public void StopCharging() {
            if (ChargeTimer != null)
                ChargeTimer.Enabled = false;
        }
    }
}
