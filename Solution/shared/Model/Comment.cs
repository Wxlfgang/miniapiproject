namespace shared.Model
{
    public class Comment
    {
        public Comment (int id, string title, string author, string content, DateTime date, int upvote, int downvote, int Post_Id)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Content = content; 
            this.Date = date;
            this.Upvote = upvote;
            this.Downvote = downvote;
            this.Post_Id = Post_Id; 
        }
   public Comment()
    {

    }
    
    public int Id {get; set;}
    public string Title {get; set;}
    public string Author {get; set;}
    public string Content {get; set;}
    public DateTime Date {get; set;}
    public int Upvote {get; set;}
    public int Downvote {get; set;}
    public int Post_Id {get; set;}
    }
}