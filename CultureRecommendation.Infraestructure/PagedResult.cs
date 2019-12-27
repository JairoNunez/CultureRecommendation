using System.Collections.Generic;

namespace CultureRecommendation.Infraestructure
{

    public class PagedResult<T> where T : class
    {

        public List<T> Data { get; set; }
        public int Total { get; set; }

        private PagedResult() { }

        public PagedResult(List<T> data, int totalRecords)
        {
            Data = data;
            Total = totalRecords;
        }

    }

}
