﻿using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.AdminVMs.CommentVMs
{
    public class AdminCommentListItemVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public IEnumerable<Comment> ChildComments { get; set; }
    }
}
