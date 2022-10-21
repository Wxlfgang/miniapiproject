using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

using shared.Model;

namespace miniapi.Data;

public class ApiService 
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public ApiService(HttpClient http, IConfiguration configuration)
    {
       this.http = http;
       this.configuration = configuration;
       this.baseAPI = configuration["base_api"];
    }
    //Get
    public async Task<Post[]> GetPost()
    {
        string url = $"{baseAPI}/api/posts/";
        return await http.GetFromJsonAsync<Post[]>(url);
    }

    public async Task<Post> GetPost(int id)
    {
        string url = $"{baseAPI}/api/posts/{id}";
        return await http.GetFromJsonAsync<Post>(url);
    }
    public async Task<Comment[]> GetComments(int id)
    {
        string url = $"{baseAPI}/api/comments/{id}/";
        return await http.GetFromJsonAsync<Comment[]>(url);
    }
    //Post

       public async void postPost(Post post)
    {   
        string url = $"{baseAPI}/api/posts/";
         await http.PostAsJsonAsync(url, post);
    }

    public async void postComment(Comment comment)
    {
        string url = $"{baseAPI}/api/comments";
        await http.PostAsJsonAsync(url, comment);
    }
    //Put
    public async void UpvotePost(int id)
    {
        string url = $"{baseAPI}/api/posts/upvote/{id}";
        await http.PutAsJsonAsync(url, "");
    }
    public async void DownvotePost(int id)
    {
        string url = $"{baseAPI}/api/posts/downvote/{id}";
        await http.PutAsJsonAsync(url, "");
    }
      public async void UpvoteComment(int id)
    {
        string url = $"{baseAPI}/api/comments/upvote/{id}";
        await http.PutAsJsonAsync(url, "");
    }
    public async void DownvoteComment(int id)
    {
        string url = $"{baseAPI}/api/comments/downvote/{id}";
        await http.PutAsJsonAsync(url, "");
    }


}