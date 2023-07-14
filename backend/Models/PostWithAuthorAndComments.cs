namespace gomomentus.Models
{
    public class PostWithAuthorAndComments
    {
        public Post Post { get; set; }
        public string Author { get; set; }
        public int CommentCount { get; set; }
    }
}
