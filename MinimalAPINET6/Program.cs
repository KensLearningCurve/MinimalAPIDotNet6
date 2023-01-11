using MinimalAPINET6.Logic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Movie> movies = new()
{
    new() { Id = 1, Rating = 5, Title = "Shrek" },
    new() { Id = 2, Rating = 1, Title = "Inception" },
    new() { Id = 3, Rating = 3, Title = "Jaws" },
    new() { Id = 4, Rating = 1, Title = "The Green Latern" },
    new() { Id = 5, Rating = 5, Title = "The Matrix" },
};

app.MapGet("/api/movies/", () =>
{
    return Results.Ok(movies);
});

app.MapGet("/api/movies/{id:int}", (int id) =>
{
    return Results.Ok(movies.Single(x => x.Id == id));
});

app.MapPost("/api/movies/", (Movie movie) =>
{
    movies.Add(movie);

    return Results.Ok(movies);
});

app.MapDelete("/api/movies/{id:int}", (int id) =>
{
    movies.Remove(movies.Single(x => x.Id == id));

    return movies;
});

app.Run();