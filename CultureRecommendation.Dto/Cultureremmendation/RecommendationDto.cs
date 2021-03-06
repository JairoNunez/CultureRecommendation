﻿using System;
using System.Collections.Generic;

namespace CultureRecommendation.Dto
{
    public class RecommendationDto
    {

        public string Title { get; set; }
        public string Overview { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string WebSite { get; set; }
        public List<string> AssociatedKeywords { get; set; }

    }

}
