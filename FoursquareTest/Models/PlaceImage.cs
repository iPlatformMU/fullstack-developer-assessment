using System.ComponentModel.DataAnnotations;

namespace FoursquareTest.Models
{
    public class PlaceImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FsqId { get; set; }
        [Required]
        public string ImageUri { get; set; }
    }
}
