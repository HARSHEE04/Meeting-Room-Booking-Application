using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.BusinessLogic
{
    internal class ViewModel
    {
        public MeetingRoom SelectedRoom { get; set; }
        public List<ReservationRequest> ReservationsRequests { get; set; }
    }
}
