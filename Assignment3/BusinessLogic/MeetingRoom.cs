using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.BusinessLogic
{
    //what methods would be required for this Meeting Room class?
    /*This class creates the objects of each individual meeting room eg A012 etc
     * This would be similar to the products class which had the construcor, properties but overide tostring method would be in 
     * requests class since requests are displayed on the View Reservation Requests page
     */
    public enum RoomLayoutType
    {
        hollowsquare,
        ushape,
        classroom,
        auditorium
    }

    //include properties for all field variables
    //inlcude validation checks in the setters of these properties
    //add XML comments in the end


    //stilll need to add the methods needed to make this class work properly


    //Shows the possible meeting venues
    public class MeetingRoom
    {
        private string _roomNumber;
        private int _seatingCapacity;
        private RoomLayoutType _layoutType;
        private string _roomImageFileName; //you basically pass the image of the room as a parameter in the constructor


        #region Properties

        //Room Number property

        public string RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
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
                if (value <= 0)
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
            set { _layoutType = value; }
        }

        //RoomImageFileName property
        public string RoomImageFileName
        {
            get { return _roomImageFileName; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception("The string for the image of the room is required");
                }
                _roomImageFileName = value;
            }
        }

        //before you try to fetch image, search the images and see if the image is there, use try catch block
        //RoomTypeIcon, this is a computed property 
        public string RoomTypeIcon
        {
            get { return $"{_layoutType}_icon.png"; } //check to see if methods are returned? try returning codes
        }

        #endregion

        #region constructor
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
