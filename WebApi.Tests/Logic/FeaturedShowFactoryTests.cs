using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Logic;
using WebApi.Model;

namespace WebApi.Tests.Logic
{
    public class FeaturedShowFactoryTests
    {
        private Show? _show;
        private ShowCast? _showCast;
        
        private FeaturedShow? _actual;

        [Fact]
        public void Throws_ArgumentNullException_when_Show_is_null()
        {
            _show = null;
            _showCast = new ShowCast();

            Assert.Throws<ArgumentNullException>("show", When_the_FeaturedShow_object_is_created);
        }

        [Fact]
        public void Creates_empty_Cast_when_cast_is_null()
        {
            Given_a_show_without_a_cast();
            When_the_FeaturedShow_object_is_created();
            Then_the_cast_property_is_an_empty_collection();
        }

        [Fact]
        public void Orders_the_cast_by_birthday_descending()
        {
            Given_a_show_with_an_unordered_cast();
            When_the_FeaturedShow_object_is_created();
            Then_the_cast_property_is_sorted();
        }


        private void Given_a_show_without_a_cast()
        {
            _show = new Show
            {
                id = "1"
            };
            _showCast = null;
        }

        private void Given_a_show_with_an_unordered_cast()
        {
            _show = new Show
            {
                id = "1"
            };
            _showCast = new ShowCast
            {
                id = "1",
                Cast = CreateUnorderedCast()
            };
        }


        private void When_the_FeaturedShow_object_is_created()
        {
            _actual = FeaturedShowFactory.Create(_show!, _showCast);
        }

        private void Then_the_cast_property_is_an_empty_collection()
        {
            Assert.Empty(_actual!.Cast);
        }

        private void Then_the_cast_property_is_sorted()
        {
            Assert.Equal(
                CreateOrderedCast().Select (
                    x => new CastMember { BirthDay = DateTime.ParseExact(x.person.birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture) }),
                _actual!.Cast);
        }


        private static Cast[] CreateUnorderedCast()
        {
            return [
                new Cast
                {
                    person = new Person
                    {
                        birthday = "2001-12-01"
                    }
                },
                new Cast
                {
                    person = new Person
                    {
                        birthday = "2000-12-01"
                    }
                },
                new Cast
                {
                    person = new Person
                    {
                        birthday = "2002-12-01"
                    }
                }];
        }

        private static Cast[] CreateOrderedCast()
        {
            return [
                new Cast
                {
                    person = new Person
                    {
                        birthday = "2002-12-01"
                    }
                },
                new Cast
                {
                    person = new Person
                    {
                        birthday = "2001-12-01"
                    }
                },
                new Cast
                {
                    person = new Person
                    {
                        birthday = "2000-12-01"
                    }
                }];
        }

    }
}
