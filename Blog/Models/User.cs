using Blog.API.Controllers.InterfaceController;
using Blog.API.Models.DTOs;
using Blog.API.Models.InterfaceModel;
using Blog.API.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Models
{
    public class User : IUser
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Bio { get; private set; }
        public string Image { get; private set; }
        public string Slug { get; private set; }
        public List<Role> Roles { get; private set; } = new List<Role>();

        public User(string name, string email, string passwordHash, string bio, string image, string slug)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Bio = bio;
            Image = image;
            Slug = slug;
        }
    }
}
