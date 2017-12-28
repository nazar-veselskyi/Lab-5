namespace NazarVeselskyi.Threading {
    public class Mobile {
        private readonly SmsProviderBase _smsProvider;
        public Storage Storage { get; set; }
        public BatteryBase Battery { get; set; }

        public Mobile() {
            _smsProvider = new SMSProviderTaskBased();
            _smsProvider.SMSReceived += OnSMSReceived;

            Storage = new Storage();
            Battery = new TaskBasedBattery();
        }

        public void StartGeneratingMessages() {
            _smsProvider.StartTimer();
        }

        public void StopGeneratingMessages() {
            _smsProvider.StopTimer();
        }

        private void OnSMSReceived(Message message) {
            Storage.AddMessage(message);
        }
    }
}
