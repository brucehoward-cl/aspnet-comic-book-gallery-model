﻿using System;
using System.Collections.Generic;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        public int Id { get; set; }

        public int SeriesID { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        //public Series Series { get; set; } // Pre Loading-Related-Entities
        //public ICollection<ComicBookArtist> Artists { get; set; } // Pre Loading-Related-Entities
        //public virtual Series Series { get; set; }  //for lazy loading in Loading-Related-Entities
        //public virtual ICollection<ComicBookArtist> Artists { get; set; }  //for lazy loading in Loading-Related-Entities
        public Series Series { get; set; }
        public virtual ICollection<ComicBookArtist> Artists { get; set; }

        //public int SeriesRefID { get; set; }  //if the foreign key has a nonconventional name use ForeignKey attribute on the foreign class
        //[ForeignKey("SeriesRefId")]
        //public Series Series { get; set; }



        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }
    }
}
