using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;

using Data;
using shared.Model;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilføj DbContext factory som service.
builder.Services.AddDbContext<PostContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();

// Dette kode kan bruges til at fjerne "cykler" i JSON objekterne.
/*
builder.Services.Configure<JsonOptions>(options =>
{
    // Her kan man fjerne fejl der opstår, når man returnerer JSON med objekter,
    // der refererer til hinanden i en cykel.
    // (altså dobbelrettede associeringer)
    options.SerializerOptions.ReferenceHandler = 
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
*/

var app = builder.Build();

// Seed data hvis nødvendigt.
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
    dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}

app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

// Middlware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});


// DataService fås via "Dependency Injection" (DI)
//Get
app.MapGet("/", (DataService service) =>
{
    return new { message = "Hello World!" };
});

app.MapGet("/api/posts/", (DataService service) =>
{
    return service.GetPosts();
});

app.MapGet("api/posts/{id}", (DataService service, int id) => {
    return service.GetPost(id);
});

app.MapGet("/api/comments/{id}", (DataService service, int id)=> {
    return service.GetComments(id);
});


//Post methods for posts og comments
app.MapPost("/api/posts", (DataService service, Post post) =>
{
  service.postPost(post);
});
app.MapPost("/api/comments", (DataService service, Comment comment) =>
{
  service.postComment(comment);
});

//Put

//Upvote Post
app.MapPut("/api/posts/upvote/{id}", (DataService service, int id) =>
{
    service.UpvotePost(id);
});

//Downvote Post
app.MapPut("/api/posts/downvote/{id}", (DataService service, int id) =>
{
    service.DownvotePost(id);
});

//Upvote Comment
app.MapPut("/api/comments/upvote/{id}", (DataService service, int id) =>
{
    service.UpvoteComment(id);
});

//Downvote Comment
app.MapPut("/api/comments/downvote/{id}", (DataService service, int id) =>
{
    service.DownvoteComment(id);
});


app.Run();

record NewPostContext(string Titel, int AuthorId);