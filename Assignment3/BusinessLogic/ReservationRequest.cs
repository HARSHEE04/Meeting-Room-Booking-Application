
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.BusinessLogic
{
    //the methods required to make this class work are still needed, the property and constructor is made
    //in UI, allow change of status, populate enum on UI using something and we need setter for this

    //what methods would be required for this Reservation Request class?
   /*Overide to string method
    */
    public enum RequestStatus
    {
        Accepted,
        Rejected,
        Pending
    }
    public class ReservationRequest
    {
        private static int lastRequestID = 0;
        private int _requestID;
        private string _requestedBy;
        private string _description;
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private int _participants;
        private RequestStatus _status;
        private List<MeetingRoom> _meetingRooms;


        //RequestID property

        public int RequestID { 
            get { return _requestID; }
            set { _requestID = lastRequestID+1; }
        }

        //RequestedBy property
        public string RequestedBy
        {
            get { return _requestedBy; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("The name of the requester must be present");
                }
                _requestedBy = value; }
        }

        //Description property
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("A description of the purpose for the request must be provided");

                }
                _description = value;
            }
        }

        //StartDateTime property
        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set
            {
                if (value < DateTime.Today)
                {
                    throw new Exception("The day must be a future date and Time");
                }
                _startDateTime = value;
            }
        }

        //EndDateTime property 
        public DateTime EndDateTime
        {
            get { return _endDateTime; }
            set
            {
                if (value.Date != _startDateTime.Date)
                {
                    throw new Exception("The end day must be the same as the start day");
                }
                if (value < _startDateTime)
                {
                    throw new Exception("The end time must be greater than the start time");
                }
                _endDateTime = value;
            }
        }

        //Participant property
        public int Participants
        {
            get { return _participants; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The participant count must be greater than 0");
                }
                _participants = value;
            }
        }

        //RequestStatus property
        public RequestStatus Status
        {
            get { return _status; }
            set
            {
                _status = value; //check this over, do we need to do this since it is set initially already?
            }
        }


        //property for association with a MeetingRoom class
        public List<MeetingRoom> MeetingRooms
        {
            get { return _meetingRooms; }
            set { _meetingRooms = value; }
        }


        public ReservationRequest(string requestedBy, string description, DateTime startDateTime, DateTime endDateTime, int participants) //need to see if we need it for bonus, call setter 
        {
            RequestedBy=requestedBy;
            Description=description;
            StartDateTime=startDateTime;
            EndDateTime=endDateTime;
            Participants=participants;
            Status = RequestStatus.Pending;
            RequestID = _requestID;
        }

        public override string ToString()
        {
            return $" Requested by {RequestedBy} for Meeting of {Description} \n " +
                $"Scheduled on {StartDateTime.Date.ToString()} from {StartDateTime.ToString()} to {EndDateTime.ToString()}.\n Status {Status}" ;
        }
    }

}
