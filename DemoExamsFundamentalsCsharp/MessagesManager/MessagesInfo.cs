using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesManager
{
    public class MessagesInfo
    {
        public int Sent { get; set; }
        public int Recived { get; set; }

        public MessagesInfo(int sent, int recived)
        {
            this.Sent = sent;
            this.Recived = recived;
        }

        public int Total => this.Sent + this.Recived;
    }
}
