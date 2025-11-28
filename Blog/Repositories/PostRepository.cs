using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Post;
using Blog.API.Repositories.InterfaceRepository;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SqlConnection _connection;
        private ILogger<PostRepository> _logger;

        public PostRepository(ConnectionDB connection, ILogger<PostRepository> logger)
        {
            _connection = connection.GetConnection();
            _logger = logger;
        }

        public async Task<List<PostResponseDTO>> GetAllPostsAsync()
        {
            try
            {
                var sql = "SELECT Id, CategoryId, AuthorId, Title, Summary, Body, Slug, CreateDate, LastUpdateDate FROM Post";
                return (await _connection.QueryAsync<PostResponseDTO>(sql)).ToList();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task CreatePostAsync(Post post)
        {
            try
            {
                var sql = @"
                    INSERT INTO Post (CategoryId, AuthorId, Title, Summary, Body, Slug, CreateDate, LastUpdateDate) 
                    VALUES (@CategoryId, @AuthorId, @Title, @Summary, @Body, @Slug, @CreateDate, @LastUpdateDate)";

                await _connection.ExecuteAsync(sql, new
                {
                    post.CategoryId,
                    post.AuthorId,
                    post.Title,
                    post.Summary,
                    post.Body,
                    post.Slug,
                    post.CreateDate,
                    post.LastUpdateDate
                });
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task UpdatePostAsync(int id, Post post)
        {
            try
            {
                var sql = @"
                    UPDATE Post SET 
                        CategoryId = @CategoryId,
                        AuthorId = @AuthorId,
                        Title = @Title,
                        Summary = @Summary,
                        Body = @Body,
                        Slug = @Slug,
                        LastUpdateDate = @LastUpdateDate
                    WHERE Id = @Id";

                await _connection.ExecuteAsync(sql, new
                {
                    Id = id,
                    post.CategoryId,
                    post.AuthorId,
                    post.Title,
                    post.Summary,
                    post.Body,
                    post.Slug,
                    LastUpdateDate = DateTime.Now
                });
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task DeletePostAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Post WHERE Id = @Id";
                await _connection.ExecuteAsync(sql, new { Id = id });
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<List<Post>> GetAllPostsTags()
        {
            var sql = @"
        SELECT p.Title AS PostTitle, t.Name AS TagName
        FROM Post p
        JOIN PostTag pt ON p.Id = pt.PostId
        JOIN Tag t ON pt.TagId = t.Id;";

            IEnumerable<Post> postTags = new List<Post>();

            using (var con = _connection)
            {
                postTags = await con.QueryAsync<Post, Tag, Post>(
                    sql,
                    (post, tag) =>
                    {
                        post.Tags.Add(tag);
                        return post;
                    },
                    splitOn: "Id"
                );
            }
            return postTags.ToList();
        }

        public async Task<List<Tag>> GetAllTagsPosts()
        {
            var sql = @"
        SELECT t.Id, t.Name AS TagName, p.Id AS PostId, p.Title AS PostTitle
        FROM Tag t
        JOIN PostTag pt ON t.Id = pt.TagId
        JOIN Post p ON pt.PostId = p.Id;";

            IEnumerable<Tag> tagPosts = new List<Tag>();

            using (var con = _connection)
            {
                tagPosts = await con.QueryAsync<Tag, Post, Tag>(
                    sql,
                    (tag, post) =>
                    {
                        tag.Posts.Add(post);
                        return tag;
                    },
                    splitOn: "PostId"
                );
            }
            return tagPosts.ToList();
        }

    }
}
