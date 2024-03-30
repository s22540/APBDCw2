using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBDCw2.Interface
{
    public interface IHazardNotifier
    {      
        void SendHazardNotification(string message);
    }
}
