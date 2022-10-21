using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Data;
using shared.Model;

namespace Service;

public class DataService
{
    private PostContext db { get; }

    public DataService(PostContext db) {
        this.db = db;
    }
    /// <summary>
    /// Seeder noget nyt data i databasen hvis det er nødvendigt.
    /// </summary>
    public void SeedData() {
        

        Post post = db.Posts.FirstOrDefault()!;
        if (post == null)
        {
            db.Posts.Add(new Post { Id = 1, Title = "post 1", Content = "hej ven", Author = "gitte", Date = DateTime.Now ,Upvote = 1, Downvote = 1});
            db.Posts.Add(new Post { Id = 2, Title = "post 2", Content = "hej ven igen ", Author = "frans" , Date = DateTime.Now ,Upvote = 1, Downvote = 1});
            db.Posts.Add(new Post { Id = 3, Title = "post 3", Content = "hej ven igen igen", Author = "din far", Date = DateTime.Now ,Upvote = 1, Downvote = 1});
        }

        Comment comment = db.Comments.FirstOrDefault()!;
        if (post == null)
        {
            db.Comments.Add(new Comment{Id = 1, Title = "comment 1", Author = "joakim", Content = "hej", Date = DateTime.Now, Upvote = 1, Downvote = 1, Post_Id = 1});
            db.Comments.Add(new Comment{Id = 2, Title = "comment 2", Author = "hans", Content = "hej", Date = DateTime.Now, Upvote = 1, Downvote = 1, Post_Id = 2});
            db.Comments.Add(new Comment{Id = 3, Title = "comment 3", Author = "lars", Content = "hej", Date = DateTime.Now, Upvote = 1, Downvote = 1, Post_Id = 3});
        }

        db.SaveChanges();

        
    }
    //Get
    public List<Post> GetPosts() {
        return db.Posts.ToList();
    }

    public Post GetPost(int id) {
        return db.Posts.FirstOrDefault(b => b.Id == id);
    }


    public List<Comment> GetComments(int id){
        return db.Comments.Where(p => p.Post_Id == id).ToList();
    }
    //Post
    public void postPost(Post post)
    {
            db.Posts.Add(new Post{Title = post.Title, Content = post.Content, Author = post.Author, Date = DateTime.Now, Upvote = 0, Downvote = 0});
            db.SaveChanges();
           
    }
    public void postComment(Comment comment)
    {
            db.Comments.Add(new Comment{Title = comment.Title, Content = comment.Content, Author = comment.Author, Date = DateTime.Now, Post_Id = comment.Post_Id, Upvote = 0, Downvote = 0});
            db.SaveChanges();
           
    }
    public void UpvotePost(int id)
    {
        var postUpvote = db.Posts.FirstOrDefault(p => p.Id == id);
        postUpvote.Upvote += 1;
        db.SaveChanges();
    }
        public void DownvotePost(int id)
    {
        var postDownvote = db.Posts.FirstOrDefault(p => p.Id == id);
        postDownvote.Downvote += 1;
        db.SaveChanges();
    }
        public void UpvoteComment(int id)
    {
        var commentUpvote = db.Comments.FirstOrDefault(p => p.Id == id);
        commentUpvote.Upvote += 1;
        db.SaveChanges();
    }
        public void DownvoteComment(int id)
    {
        var commentDownvote = db.Comments.FirstOrDefault(p => p.Id == id);
        commentDownvote.Downvote += 1;
        db.SaveChanges();
    }



}