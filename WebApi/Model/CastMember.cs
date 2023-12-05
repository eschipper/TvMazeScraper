namespace WebApi.Model
{
    public record class CastMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }

    }
}
