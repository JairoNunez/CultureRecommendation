using System;

namespace CultureRecommendation.Domain
{
    public class Cinema
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OpenSince { get; set; }
        public int CityId { get; set; }
        #endregion     
    }
}
