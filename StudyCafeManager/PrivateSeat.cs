using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCafeManager
{
    class PrivateSeat : ISeat
    {
        private string seatnum;
        public string SeatNum 
        {
            get { return seatnum; }
        }
        public PrivateSeat(string seatnum)
        {
            this.seatnum = seatnum;
        }
    }
}
