﻿using System.ComponentModel.DataAnnotations;

namespace ComicBookGalleryModel.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
