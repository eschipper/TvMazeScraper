namespace WebApi.Model
{
    public record class FeaturedShow
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public IEnumerable<CastMember> Cast { get; init; } = Enumerable.Empty<CastMember>();
    }
}
