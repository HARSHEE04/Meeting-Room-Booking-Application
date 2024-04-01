using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.BusinessLogic
{
    #region RoomLayoutType Enumeration
    //The RoomLayoutType enum holds the types of rooms the users can choose from.
    //The options here are stored as integral constants.
    //The Meeting Room class is the whole and the RoomLayoutType is the part in the composition class relationship.


    public enum RoomLayoutType
    {
        hollowsquare,
        ushape,
        classroom,
        auditorium
    }
    #endregion

    /// <summary>
    /// The Meeting Room class is designed for the instances of the meeting rooms and represents the possible meeting venues for which reservations can be made.
    /// </summary>
    public class MeetingRoom
    {
        private string _roomNumber;
        private int _seatingCapacity;
        private RoomLayoutType _layoutType;
        private string _roomImageFileName; 


        #region Properties

        //Room Number property
      
        public string RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))// validation to ensure that the room number is not empty
                {
                    throw new Exception("Room number is required");
                }
                _roomNumber = value;
            }
        }

        //Seating Capacity property
        public int SeatingCapacity
        {
            get { return _seatingCapacity; }
            set
            {
                if (value <= 0) // validation to ensure that the seating capacity is greater 0.
                {
                    throw new Exception("The seating capacity needs to be greater than 0");
                }
                _seatingCapacity = value;
            }
        }

        //Room Layout property
        public RoomLayoutType LayoutType
        {
            get { return _layoutType; }
            init { _layoutType = value; }  //init keyword used instead of setter because we only want this to be changed in the constructor.
                                           
        }

        //RoomImageFileName property
        public string RoomImageFileName
        {
            get { return _roomImageFileName; }
            set
            {
                if(string.IsNullOrEmpty(value)) //validation to ensure the imgae file name is provided.
                {
                    throw new Exception("The string for the image of the room is required");
                }
                _roomImageFileName = value;
            }
        }

        //RoomTypeIcon property
        public string RoomTypeIcon
        {
            get { return $"{_layoutType}_icon.png"; } //No setter  provided here because this is a computed property because means it already returns an expression thus no setter needed.
        }

        #endregion

        #region constructor
        /// <summary>
        /// Below is the constuctor of this Meeting Room class. This creates the object of class Meeting Room while also performing validation checks since the properties defined above are used before inilising.
        /// </summary>
        /// <param name="roomNumber"> This is the room number of each meeting room, is of the string data type</param>
        /// <param name="seatingCapacity">This is the max number of people who can fit into the room</param>
        /// <param name="layoutType">This variable holds the layout of the room and uses the RoomLayoutType enum as possible options</param>
        /// <param name="roomImageFileName">This variable holds the real image of the room, not the icon, will be used to show what the actaul rooms look like.</param>
        public MeetingRoom(string roomNumber, int seatingCapacity, RoomLayoutType layoutType, string roomImageFileName)
        {
            RoomNumber= roomNumber;
            SeatingCapacity= seatingCapacity;
            LayoutType= layoutType;
            RoomImageFileName= roomImageFileName;
        }
        #endregion


    }
}
