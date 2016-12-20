using Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {

        public Comment(string content, string authorId, int articleId)
        {
            this.Content = content;
            this.AuthorId = authorId;
            this.ArticleId = articleId;
        }

        public Comment()
        {

        }
        
        [Key]
        public int Id { get; set; }
        
        [Index MaxLength (500)]
        public string Content { get; set; }


        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }


        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}