namespace shared.Model
{
    public class Post
    {
        public Post (int id, string title, string content, string author, DateTime date, int upvote, int downvote)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.Author = author;
            this.Date = date;
            this.Upvote = upvote;
            this.Downvote = downvote;
       
        }
        public Post()
        {

        }

        public int Id {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public string Author {get; set;}
        public DateTime Date {get; set;}
        public int Upvote {get; set;}
        public int Downvote {get; set;}

        

    }
}