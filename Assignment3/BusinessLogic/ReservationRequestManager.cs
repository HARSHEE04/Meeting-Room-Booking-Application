using Assignment3.BusinessLogic;

using Microsoft.Maui.Controls.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3.BusinessLogic
{
    //this class manages the collections of Meeting Rooms and Reservation Requests. 
    //Has two methods 1) Add meeting room and 2) Add Reservation Request

    /// <summary>
    /// This class manages the collection of Meeting Rooms and Reservation Requests. This is why it is in a whole- part relationship with both the meeting room and the reservationrequests class. This is the whole while
    /// The other two are the parts. For this reason, we have a list of meetings rooms and a list of reservation requests in the filed vairbales which is initlized using the new keyword in the constructor of this classs. 
    /// </summary>
    public class ReservationRequestManager 

    {
        //field varibale to comply with composition relationship. 
        private List<MeetingRoom> _meetingRooms= new List<MeetingRoom>();
        private List<ReservationRequest> _reservationRequests = new List<ReservationRequest>();
        private static ReservationRequestManager instance;


        /// <summary>
        /// This method uses the principle of the Singleton Design Pattern. With this pattern,
        /// a class only has one instance in the program (ours is created in the pickroompage)  which can be accessed in other classes.
        /// The reason why I needed this is because my ReservationRequestManager is only created in my PickRoomPage and I should be taking info of that one instance that was 
        /// created to other pages such as the ViewRequests page so I can use the properties of that instance such as the ReservationRequests which is the list with all of my requests.
        /// The pattern is perfect for that because it provides a single point of access to this particular instance (in our case the _requestmanager in PickRoomPage) so this instance is easy to maintain and use
        /// The references for this pattern is here: https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
        /// </summary>
        public static ReservationRequestManager Instance //declares a static property named Instance of the type ReservationRequestManager.Static ensures it belows to class rather than instance allowing us to use that single instance concept.
            
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReservationRequestManager();// checks to see if the instance is null, if it is, new one is created
                }
                return instance;
            }
        }

        /// <summary>
        /// Below was the public constructor I has made for this class before, but since I implemented the Singleton Design Pattern, I took this out because these constructors create new instances of the class and can be 
        /// accessed outside the class which would mean multiple insstances of the class could be made which violates the rule that only one instance of this class can be made.
        /// References: https://csharpindepth.com/articles/Singleton
        /// </summary>
        //public ReservationRequestManager()
        //{

        //instanciating of the meeting room and reservtion request list to comply with composition relationship requirements.



        //four harded coded instances of meeting room added to list of meeting rooms, will be used to populate the pickroompage
        //_meetingrooms.add(new meetingroom("a102", 20, roomlayouttype.hollowsquare, "hollowsquare.png"));
        //_meetingrooms.add(new meetingroom("b013", 20, roomlayouttype.ushape, "ushape.png"));
        //_meetingrooms.add(new meetingroom("c202", 40, roomlayouttype.classroom, "classroom.png"));
        //_meetingrooms.add(new meetingroom("c105", 200, roomlayouttype.auditorium, "auditorium.png"));

        //    //tried hard-coding the requests but was not working as intended
        //    //DateTime startDateTime = DateTime.Now;
        //    ////Console.WriteLine(startDateTime.ToString());

        //    //DateTime endDateTime = DateTime.Now;
        //    //_reservationRequests.Add(new ReservationRequest("John Doe", "Description, academic council", startDateTime, endDateTime, 25));
        //}

        #region Properties
        //two properties made that return the new meeting room and reservation request list in this class. Helpful because it would allow objects of this class to have access to the list of meeting rooms and _reservationrequests
        public List<MeetingRoom> MeetingRooms { get { return _meetingRooms; } } //change the name, try refactoring
        public List<ReservationRequest> ReservationRequests { get { return _reservationRequests; } } //change name, try refactoring

       
        #endregion

        
        #region Methods
        /// <summary>
        /// This method accepts the data which is required to create an instance of a Meeting Room and it added it to the collection of meetings rooms.
        /// Also checks to ensure that the meeting room does not already exists using Room Number of each meeting room as an identifier.
        /// </summary>
        /// <param name="roomNumber">The room number which is used to identify the meeting room</param>
        /// <param name="seatingCapacity"> The max number of people which the room can hold</param>
        /// <param name="layoutType"> The layout of room from the RoomLayoutType enum</param>
        /// <param name="roomImageFileName"> string which holds the name of the image file name for each room</param>
        /// <exception cref="Exception"> If the room already exists, an exception is thrown telling the user a duplicate cannot be added</exception>
        public void AddMeetingRoom(string roomNumber, int seatingCapacity, RoomLayoutType layoutType, string roomImageFileName)
        {
            //check to see if the room number already exists
            foreach (MeetingRoom current in _meetingRooms)
            {
                if (current.RoomNumber == roomNumber)
                {
                    throw new Exception("A room with this room number already exists");
                }
            }
            MeetingRoom meetRoom1 = new MeetingRoom(roomNumber, seatingCapacity, layoutType, roomImageFileName);
            _meetingRooms.Add(meetRoom1);

        }

        /// <summary>
        /// This method takes the paramters required to create a reseration and also takes in the room number for the room that is selected to create a request. 
        /// First checks to ensure the room actaully exists within the list of meeting rooms ensuring one selected is a valid option. Then it checks to ensure the reseervation is being made within the 
        /// guidline for the number of people allowed in the room by comparing particiapnts with the seating capacity for the room. If all conditions are met, the request is created an added to the _reservationRequests list
        /// </summary>
        /// <param name="requestedBy"> The user's name who has request the room</param>
        /// <param name="description">The purpose of the request</param>
        /// <param name="startDateTime">Start date and time of the request as selected by the user</param>
        /// <param name="endDateTime">End date and time of the request as selected by the user</param>
        /// <param name="participants"> number of people expected to use the room during reservation</param>
        /// <param name="roomNumber">The room number of the room that was selected for the request</param>
        /// <exception cref="Exception"> Exception thrown if the user is trying to have participants which exceeds the searting capacity for the chosen room</exception>
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
                }
            }
        }
     
    }
    #endregion
}
