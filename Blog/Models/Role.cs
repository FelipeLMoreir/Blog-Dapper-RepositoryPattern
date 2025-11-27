using Blog.API.Models.InterfaceModel;

namespace Blog.API.Models
{
    public class Role : IRole
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }

        public Role(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
