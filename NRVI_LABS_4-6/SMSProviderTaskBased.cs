using System.Threading.Tasks;

namespace NazarVeselskyi.Threading {
    class SMSProviderTaskBased: SmsProviderBase {
        private Task _messagesTask;

        public override void StartTimer() {
            if (_messagesTask == null)
                _messagesTask = Task.Run(() => SetUpTimer());
            else
                Timer.Enabled = true;
        }
    }
}
