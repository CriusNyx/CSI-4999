using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
    public interface IEventListener
    {
        void AcceptEvent(IEvent e);
    }
}
