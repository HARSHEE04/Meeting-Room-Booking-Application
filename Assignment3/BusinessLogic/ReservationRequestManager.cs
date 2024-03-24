using Assignment3.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

//Manages collections of MeetingRooms and ResevationRequests.
namespace Assignment3.BusinessLogic
{
    
    internal class ReservationRequestManager
    {
        public List<MeetingRoom> _meetingRooms = new List<MeetingRoom>();
        public ReservationRequestManager()
        {
             _meetingRooms.Add(new MeetingRoom("A102", 20, RoomLayoutType.hollowsquare, "hollowsquare.png"));
            _meetingRooms.Add(new MeetingRoom("B013", 20, RoomLayoutType.ushape, "ushape.png"));
            _meetingRooms.Add(new MeetingRoom("C202", 40, RoomLayoutType.classroom, "classroom.png"));
            _meetingRooms.Add(new MeetingRoom("C105", 200, RoomLayoutType.auditorium, "auditorium.png"));
        }

       
    }
}
