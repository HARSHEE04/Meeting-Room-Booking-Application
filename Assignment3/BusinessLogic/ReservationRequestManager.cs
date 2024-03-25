using Assignment3.BusinessLogic;
using Microsoft.Maui.Controls.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

//Manages collections of MeetingRooms and ResevationRequests.
namespace Assignment3.BusinessLogic
{
    //this class manages the collections of Meeting Rooms and Reservation Requests. 
    //Has two methods 1) Add meeting room and 2) Add Reservation Request
    internal class ReservationRequestManager
    {
        public List<MeetingRoom> _meetingRooms = new List<MeetingRoom>();
        public List<ReservationRequest> _reservationRequests = new List<ReservationRequest>();
        public ReservationRequestManager()
        {
             _meetingRooms.Add(new MeetingRoom("A102", 20, RoomLayoutType.hollowsquare, "hollowsquare.png"));
            _meetingRooms.Add(new MeetingRoom("B013", 20, RoomLayoutType.ushape, "ushape.png"));
            _meetingRooms.Add(new MeetingRoom("C202", 40, RoomLayoutType.classroom, "classroom.png"));
            _meetingRooms.Add(new MeetingRoom("C105", 200, RoomLayoutType.auditorium, "auditorium.png"));
        }

        //AddMeetingRoom: accepts the data required to create an instance of meeting
        //room, and adds it to the collection of meeting rooms provided the room
        //number is not duplicate
        public MeetingRoom AddMeetingRoom(string roomNumber, int seatingCapacity, RoomLayoutType layoutType, string roomImageFileName)
        {
            //check to see if the room number already exists
                foreach (MeetingRoom current in _meetingRooms)
                {
                    if (current.RoomNumber ==roomNumber)
                    {
                    throw new Exception("A room with this room number already exists");
                    }
                }   
            MeetingRoom meetRoom1= new MeetingRoom (roomNumber, seatingCapacity, layoutType, roomImageFileName);
            _meetingRooms.Add(meetRoom1);
            return meetRoom1;
        }

        ////AddReservationRequest: accepts the data required to create a reservationrequest(except request id and request status).

        //public ReservationRequest AddReservationRequest(string requestedBy, string description, DateTime startDateTime, DateTime endDateTime, int participants, string roomNumber)
        //{
        //    ////ensure expected guests does not go over the max
        //    //if(participants> )
        //    ////check to see if the room exists
        //    //foreach(MeetingRoom current in _meetingRooms)
        //    //{
        //    //    if(current.RoomNumber==roomNumber)
        //    //}
        //}





    }
}
