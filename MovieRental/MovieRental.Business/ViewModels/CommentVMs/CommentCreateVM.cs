using MovieRental.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Business.ViewModels.CommentVMs
{
    public class CommentCreateVM
    {
        [Required, MaxLength(128)]
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
    }
}
