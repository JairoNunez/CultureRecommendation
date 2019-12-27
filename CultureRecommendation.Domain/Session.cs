using System;

namespace CultureRecommendation.Domain
{

    public class Session
    {

        #region Properties
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SeatsSold { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        #endregion

    }

}
