namespace ComicBookGalleryModel.Models
{
    public class ComicBookArtist
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        public int ArtistId { get; set; }
        public int RoleId { get; set; }

        //public ComicBook ComicBook { get; set; }  // Pre Loading-Related-Entities
        //public Artist Artist { get; set; }  // Pre Loading-Related-Entities
        //public Role Role { get; set; }  // Pre Loading-Related-Entities
        public virtual ComicBook ComicBook { get; set; }  
        public virtual Artist Artist { get; set; }  
        public virtual Role Role { get; set; }  
    }
}
