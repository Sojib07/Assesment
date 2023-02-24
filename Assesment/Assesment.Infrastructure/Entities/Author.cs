namespace Assesment.Infrastructure.Entities
{
    public class Author : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}