using System;
using System.Timers;

namespace NazarVeselskyi.Threading {
    public abstract class SmsProviderBase {
        public delegate void SMSReceivedDelegate(Message message);
        public event SMSReceivedDelegate SMSReceived;
        
        protected System.Timers.Timer Timer;
        private int _messageNumber = 1;

        private void RaiseSmsReceivedEvent(Message message) {
            var handler = SMSReceived;
            if (handler != null)
                handler(message);
        }

        public void SetUpTimer() {
            Timer = new System.Timers.Timer(500);
            Timer.Elapsed += OnTimerEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        public abstract void StartTimer();

        public void StopTimer() {
            Timer.Enabled = false;
        }

        private void OnTimerEvent(Object source, ElapsedEventArgs e) {
            Random rand = new Random();
            double nextDouble = rand.NextDouble();
            string user = "Subscriber1";
            if (nextDouble < 0.33)
                user = "Subscriber2";
            else if (nextDouble < 0.66)
                user = "Subscriber3";

            Message msg = new Message { User = user, ReceivingTime = DateTime.Now, Text = "Message №" + _messageNumber++ + " received!" };
            RaiseSmsReceivedEvent(msg);
        }
    }
}
