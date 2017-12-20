using System.Threading;

namespace NRVI_LABS_4_6 {
    public class SMSProviderThreadBased: SmsProviderBase {
        private Thread _messagesThread;

        public override void StartTimer() {
            if (_messagesThread == null) {
                _messagesThread = new Thread(SetUpTimer);
                _messagesThread.Start();
            }
            else
                Timer.Enabled = true;
        }
    }
}
