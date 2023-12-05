using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using WebApi.Model;

namespace WebApi.Logic
{
    public class FeaturedShowFactory
    {
        public static FeaturedShow Create(Models.Show show, Models.ShowCast? showCast)
        {
            ArgumentNullException.ThrowIfNull(show);

            IEnumerable<CastMember> cast = showCast?.Cast.Select(
                    c => new CastMember
                    {
                        Id = c.person.id,
                        Name = c.person.name,
                        BirthDay = !string.IsNullOrEmpty(c.person.birthday)
                            ? DateTime.ParseExact(c.person.birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                            : null
                    }) ?? Enumerable.Empty<CastMember>();

            return new FeaturedShow
            {
                Id = show.id,
                Name = show.name,
                Cast = cast.OrderByDescending(c => c.BirthDay)
            };
        }
    }
}
