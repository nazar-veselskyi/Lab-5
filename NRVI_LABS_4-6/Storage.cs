﻿using System;
using System.Collections.Generic;

namespace NRVI_LABS_4_6 {
    public class Storage {
        public delegate void SMSAddedDelegate(Message message);
        public event SMSAddedDelegate SMSAdded;

        public delegate void SMSRemovedDelegate(Message message);
        public event SMSRemovedDelegate SMSRemoved;

        public List<Message> Messages;

        public Storage() {
            Messages = new List<Message>();
        }

        private void RaiseSMSAddedEvent(Message message) {
            var handler = SMSAdded;
            if (handler != null)
                handler(message);
        }

        private void RaiseSMSRemovedEvent(Message message) {
            var handler = SMSRemoved;
            if (handler != null)
                handler(message);
        }

        public void AddMessage(Message message) {
            Messages.Add(message);
            Console.WriteLine("AddMessage: " + message + ", messages: " + Messages.Count);

            RaiseSMSAddedEvent(message);
        }

        public void RemoveMessage(Message message) {
            if (Messages.Contains(message)) {
                Messages.Remove(message);
                RaiseSMSRemovedEvent(message);
            }
        }
    }
}
