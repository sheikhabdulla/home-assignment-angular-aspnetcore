using gomomentus.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class JsonPlaceholderService
{
    private readonly HttpClient _httpClient;
    private readonly string usersFilePath;
    private readonly string postsFilePath;
    private readonly string commentsFilePath;

    public JsonPlaceholderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        string projectFolderPath = Directory.GetCurrentDirectory();
         usersFilePath = Path.Combine(projectFolderPath, "resourses", "users.json");
        postsFilePath = Path.Combine(projectFolderPath, "resourses", "posts.json");
        commentsFilePath = Path.Combine(projectFolderPath, "resourses", "comments.json");
    }

    public List<Post> LoadLocalPosts()
    {
        var json = File.ReadAllText(postsFilePath);

        var posts = JsonSerializer.Deserialize<List<Post>>(json);

        return posts;
    }

    public List<User> LoadLocalUsers()
    {
        var json = File.ReadAllText(usersFilePath);

        var users = JsonSerializer.Deserialize<List<User>>(json);

        return users;
    }

    public List<Comment> LoadLocalComments()
    {
        var json = File.ReadAllText(commentsFilePath);

        var comments = JsonSerializer.Deserialize<List<Comment>>(json);

        return comments;
    }
    public async Task<List<PostWithAuthorAndComments>> GetPostsAsync()
    {

        var posts = LoadLocalPosts();

        var users = LoadLocalUsers();
        var comments = LoadLocalComments();

        var postWithAuthorAndCommentsList = new List<PostWithAuthorAndComments>();

        foreach (var post in posts)
        {
            var author = users.FirstOrDefault(u => u.id == post.userId)?.name;
            var commentCount = comments.Count(c => c.postId == post.id);

            var postWithAuthorAndComments = new PostWithAuthorAndComments
            {
                Post = post,
                Author = author,
                CommentCount = comments.Count(c => c.postId == post.id)
            };

            postWithAuthorAndCommentsList.Add(postWithAuthorAndComments);
        }

        return postWithAuthorAndCommentsList;
    }

    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        var comments = LoadLocalComments();
        var maxId = comments.Max(c => c.id);
        comment.id = maxId + 1;

        comments.Add(comment);
        var json = JsonSerializer.Serialize(comments);
        File.WriteAllText(commentsFilePath, json);

        return comment;
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        var comments = LoadLocalComments();
        var commentToRemove = comments.FirstOrDefault(c => c.id == commentId);

        if (commentToRemove != null)
        {
            comments.Remove(commentToRemove);
            var json = JsonSerializer.Serialize(comments);
            File.WriteAllText(commentsFilePath, json);
        }
    }

    public async Task DeletePostAsync(int postid)
    {
        var posts = LoadLocalPosts();
        var postToRemove = posts.FirstOrDefault(c => c.id == postid);

        if (postToRemove != null)
        {
            posts.Remove(postToRemove);
            var json = JsonSerializer.Serialize(posts);
            File.WriteAllText(postsFilePath, json);
        }
    }

    public async Task UpdatePostsAsync(List<Post> posts)
    {
        var json = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(postsFilePath, json);
    }
    public async Task RefreshDataFromSourceAsync()
    {
        var posts = await GetFromSourceAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
        var users = await GetFromSourceAsync<List<User>>("https://jsonplaceholder.typicode.com/users");
        var comments = await GetFromSourceAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments");

        SaveToLocalFile(posts, postsFilePath);
        SaveToLocalFile(users, usersFilePath);
        SaveToLocalFile(comments, commentsFilePath);
    }

    private async Task<T> GetFromSourceAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json);
    }

    private void SaveToLocalFile<T>(T data, string filePath)
    {
        var json = JsonSerializer.Serialize(data);
        File.WriteAllText(filePath, json);
    }


    public async Task<Post> GetPostAsync(int id)
    {
        var posts = await LoadPostsAsync();
        return posts.FirstOrDefault(p => p.id == id);
    }

    public async Task UpdatePostAsync(Post post)
    {
        var posts = await LoadPostsAsync();
        var existingPost = posts.FirstOrDefault(p => p.id == post.id);

        if (existingPost != null)
        {
            existingPost.favourite = post.favourite;
            await SavePostsAsync(posts);
        }
    }

    private async Task<List<Post>> LoadPostsAsync()
    {
        var json = await File.ReadAllTextAsync(postsFilePath);
        return JsonSerializer.Deserialize<List<Post>>(json);
    }

    private async Task SavePostsAsync(List<Post> posts)
    {
        var json = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(postsFilePath, json);
    }



}
