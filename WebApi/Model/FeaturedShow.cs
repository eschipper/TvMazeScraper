namespace WebApi.Model
{
    public class FeaturedShow
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CastMember> Cast { get; init; }
    }
}
