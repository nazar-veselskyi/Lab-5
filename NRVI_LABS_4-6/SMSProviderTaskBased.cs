using System.Threading.Tasks;

namespace NRVI_LABS_4_6 {
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
