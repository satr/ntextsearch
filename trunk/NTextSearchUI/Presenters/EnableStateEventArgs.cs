using System;

namespace NTextSearch{
    public class EnableStateEventArgs: EventArgs{
        public bool Enable { get; set; }

        public EnableStateEventArgs(bool enable){
            Enable = enable;
        }
    }
}