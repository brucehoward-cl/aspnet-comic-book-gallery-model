namespace TestClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ComicBook
    {
        public int Id { get; set; }

        public string SeriesTitle { get; set; }

        public int IssueNumber { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public decimal? AverageRating { get; set; }
    }
}
