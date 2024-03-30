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
    public class ReservationRequestManager
    {
        private List<MeetingRoom> _meetingRooms; // IS THIS ALLOWED?
        private List<ReservationRequest> _reservationRequests;
        public ReservationRequestManager()
        {
            _meetingRooms=new List<MeetingRoom>();
            _reservationRequests=new List<ReservationRequest>();
             _meetingRooms.Add(new MeetingRoom("A102", 20, RoomLayoutType.hollowsquare, "hollowsquare.png"));
            _meetingRooms.Add(new MeetingRoom("B013", 20, RoomLayoutType.ushape, "ushape.png"));
            _meetingRooms.Add(new MeetingRoom("C202", 40, RoomLayoutType.classroom, "classroom.png"));
            _meetingRooms.Add(new MeetingRoom("C105", 200, RoomLayoutType.auditorium, "auditorium.png"));
        }


        public List<MeetingRoom> MeetingRooms { get { return _meetingRooms; } }
        public List<ReservationRequest> ReservationRequests { get { return _reservationRequests; } }


        //AddMeetingRoom: accepts the data required to create an instance of meeting
        //room, and adds it to the collection of meeting rooms provided the room
        //number is not duplicate
        public void AddMeetingRoom(string roomNumber, int seatingCapacity, RoomLayoutType layoutType, string roomImageFileName)
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
           
        }

 
        public void AddReservationRequest(string requestedBy, string description, DateTime startDateTime, DateTime endDateTime, int participants, string roomNumber)
        {
                     
            foreach (MeetingRoom current in _meetingRooms)
            {
                if (current.RoomNumber == roomNumber)
                {
                  
                    if (current.SeatingCapacity < participants)
                    {
                        throw new Exception($"The participants need to be less than or equal to the seating capacity, which is {current.SeatingCapacity}");
                    }
                    else
                    {
                        ReservationRequest request1 = new ReservationRequest(requestedBy, description, startDateTime, endDateTime, participants);
                        int requestID = request1.RequestID;
                        _reservationRequests.Add(request1);
                        
                        break;
                        
                    }

                    break; 
                }
            }

            //if (!roomExists)
            //{
            //    throw new Exception("The room number does not exist");
            //}
        }

    }
}
