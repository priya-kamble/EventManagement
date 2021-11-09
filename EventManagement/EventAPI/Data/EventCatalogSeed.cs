using EventAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Data
{
    public static class EventCatalogSeed
    {
        public static void Seed(EventCatalogContext context)
        {
            context.Database.Migrate();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(GetCategories());
                context.SaveChanges();
            }
            if (!context.SubCategories.Any())
            {
                context.SubCategories.AddRange(GetSubCategories());
                context.SaveChanges();
            }

            if (!context.Formats.Any())
            {
                context.Formats.AddRange(GetFormats());
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(GetUsers());
                context.SaveChanges();
            }

            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(GetOrganizations());
                context.SaveChanges();
            }

            if (!context.Locations.Any())
            {
                context.Locations.AddRange(GetLocations());
                context.SaveChanges();
            }

            if (!context.EventCatalog.Any())
            {
                context.EventCatalog.AddRange(GetEvents());
                context.SaveChanges();
            }
        }
        private static IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
               
                new Category { CategoryName = "Business & Professional" },
                new Category { CategoryName = "Charity & Causes" },
                new Category { CategoryName = "Food & Drink" },
                new Category { CategoryName = "Health & Wellness" },
                new Category { CategoryName = "Music" },
                new Category { CategoryName = "School Activities" },
                new Category { CategoryName = "Sports & Fitness" },
                new Category { CategoryName = "Travel & Outdoor" }
            };
        }
        private static IEnumerable<SubCategory> GetSubCategories()
        {
            return new List<SubCategory>
            {
                
                new SubCategory { SubCategoryName = "Career", CategoryId = 1 },

                new SubCategory { SubCategoryName = "Real Estate", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Sales & Marketing", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Education", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Food", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Medical", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Classical", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Robotics", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Hiking", CategoryId = 7 }
                new SubCategory { SubCategoryName = "League", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Travel", CategoryId = 8 }
            };
        }
        private static IEnumerable<Format> GetFormats()
        {
            return new List<Format>
            {
            
                new Format { FormatName = "Camp, Trip, or Retreat" },
                new Format { FormatName = "Class, Training, or Workshop" },
                new Format { FormatName = "Conference" },
                new Format { FormatName = "Festival or Fair" },
                new Format { FormatName = "Game or Competition" },
                new Format { FormatName = "Meeting or Networking Event" },
                new Format { FormatName = "Party or Social Gathering" },
                new Format { FormatName = "Seminar or Talk" },
                new Format { FormatName = "Tour" },
                new Format { FormatName = "Dinner or Gala" } ,
                new Format { FormatName = "Camp, Trip, or Retreat" }
             };
        }
        private static IEnumerable<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                new Organization { UserId = 3, OrganizationName = "Creative Hands" },
                new Organization { UserId = 4, OrganizationName = "Yoga and Meditation" },
                new Organization { UserId = 5, OrganizationName = "Real Estate In Seattle" },
                new Organization { UserId = 6, OrganizationName = "Sport and Meditation" },
                new Organization { UserId = 7, OrganizationName = "Clean World" },
                new Organization { UserId = 8, OrganizationName = "Festivals Arrangement Company" },
                new Organization { UserId = 9, OrganizationName = "Running Supplies" },
                new Organization { UserId = 10, OrganizationName = "Private Art Exhibition Arrangement Company" },
            };
        }
        private static IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User { UserEmailId = "john@gmail.com" },
                new User { UserEmailId = "wei@gmail.com" },
                new User { UserEmailId = "jose@gmail.com" },
                new User { UserEmailId = "mohammed@gmail.com" },
                new User { UserEmailId = "sunita@gmail.com" },
                new User { UserEmailId = "maria@gmail.com" },
                new User { UserEmailId = "nushi@gmail.com" },
                new User { UserEmailId = "ram@gmail.com" },
                new User { UserEmailId = "anna@gmail.com" },
                new User { UserEmailId = "antonio@gmail.com" },
                new User { UserEmailId = "hui@gmail.com" },
                new User { UserEmailId = "hong@gmail.com" },
                new User { UserEmailId = "fatima@gmail.com" },
                new User { UserEmailId = "ibrahim@gmail.com" },
                new User { UserEmailId = "lei@gmail.com" },
                new User { UserEmailId = "aleksandr@gmail.com" },
                new User { UserEmailId = "richard@gmail.com" },
                new User { UserEmailId = "olga@gmail.com" },
                new User { UserEmailId = "sergey@gmail.com" },
                new User { UserEmailId = "pedro@gmail.com" },
                new User { UserEmailId = "elena@gmail.com" },
                new User { UserEmailId = "tatyana@gmail.com" },
            };
        }
        private static IEnumerable<Location> GetLocations()
        {
            return new List<Location>
            {
                new Location { City = "Redmond", State = "WA" },
                new Location { City = "Redmond", State = "OR" },
                new Location { City = "Seattle", State = "WA" },
                new Location { City = "Portland", State = "OR" },
                new Location { City = "Bellevue", State = "WA" },
                new Location { City = "Kirkland", State = "WA" },
                new Location { City = "Shoreline", State = "WA" },
                new Location { City = "Everett", State = "WA" },
                new Location { City = "Tacoma", State = "WA" },
                new Location { City = "Auburn", State = "WA" },
                new Location { City = "Renton", State = "WA" },
                new Location { City = "Kent", State = "WA" },
                new Location { City = "Federal Way", State = "WA" },
                new Location { City = "Edmonds", State = "WA" },
                new Location { City = "Lynnwood", State = "WA" },
                new Location { City = "Burien", State = "WA" },
                new Location { City = "Bremerton", State = "WA" },
                new Location { City = "Des Moines", State = "WA" },
                new Location { City = "Puyallup", State = "WA" },
                new Location { City = "Lake Stevens", State = "WA" },
                new Location { City = "Bothell", State = "WA" },
                new Location { City = "Issaquah", State = "WA" },
                new Location { City = "Lakewood", State = "WA" },
                new Location { City = "Bellingham", State = "WA" },
                new Location { City = "Olympia", State = "WA" },
                new Location { City = "Port Townsend", State = "WA" },
                new Location { City = "Arlington", State = "WA" },
                new Location { City = "Mount Vernon", State = "WA" },
                new Location { City = "Atlanta", State = "GA" },
                new Location { City = "El Paso", State = "TX" },
                new Location { City = "San Francisco", State = "CA" },
                new Location { City = "Boise", State = "ID" },
                new Location { City = "Vancouver", State = "BC"}
            };
        }
        private static IEnumerable<Event> GetEvents()
        {
            return new List<Event>
            {

                new Event { Title = "Diversity Career Group", Description = "Tech Career Fair", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 4 },

                new Event { Title = "Photowalk", Description = "Seattle Center with Nikon", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 3, Address = "1000 1st Ave",
                    SubCategoryId = 3, UserId = 3, FormatId = 9 },

                new Event { Title = "Dream House", Description = "New Homebuyer Workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3",
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 5, Address = "1000 1st Ave",
                    SubCategoryId = 2, UserId = 3, FormatId = 6 },

                new Event { Title = "Tech Carrier Fair ", Description = "Exclusive Tech Hiring", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 7, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 4 },

                new Event { Title = "Taste Maker", Description = "Cooking Classes", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 12) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 9, Address = "1000 1st Ave",
                    SubCategoryId = 5, UserId = 3, FormatId = 2 },

                new Event { Title = "The Market Experience", Description = "Classic Italian Cuisine", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6",
                    MaxOccupancy = 10, MaxTicketsPerUser = 4, StartDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 12) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 11, Address = "8352 Marvon Dr.",
                    SubCategoryId = 5, UserId = 3, FormatId = 10 },

                new Event { Title = "Know your options", Description = "How to choose right insurance plan workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7",
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 13, Address = "8352 Marvon Dr.",
                    SubCategoryId = 6, UserId = 3, FormatId = 2 },

                new Event { Title = "Karaoke Event", Description = "A melodious night", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8",
                    MaxOccupancy = 40, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 2, Address = "1000 1st Ave",
                    SubCategoryId = 7, UserId = 3, FormatId = 7 },

                new Event { Title = "Harmony", Description = "A musical workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9",
                    MaxOccupancy = 15, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 4, Address = "8352 Marvon Dr.",
                    SubCategoryId = 4, UserId = 3, FormatId = 11 },

                new Event { Title = "Cruise Away", Description = "Exploring the sea together", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10",
                    MaxOccupancy = 150, MaxTicketsPerUser = 6, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 6, Address = "1000 1st Ave",
                    SubCategoryId = 10, UserId = 3, FormatId = 11 },

                new Event { Title = "Park & Hike Event", Description = "Hike in the woods", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11",
                    MaxOccupancy = 20, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "8352 Marvon Dr.",
                    SubCategoryId = 8, UserId = 3, FormatId = 6 },

                new Event { Title = "Family.Life.Education", Description = "Learn-Grow-Fulfill your Potential", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12",
                    MaxOccupancy = 6, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "8352 Marvon Dr.",
                    SubCategoryId = 4 , UserId = 3, FormatId = 3 },

                new Event { Title = "Education Foundation", Description = "Education for All", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13",
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 8, Address = "8352 Marvon Dr.",
                    SubCategoryId = 4, UserId = 3, FormatId = 3 },

                new Event { Title = "After School Enrichment Programs", Description = "S.T.E.M", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14",
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 8, Address = "219 Madison Ave",
                    SubCategoryId = 8, UserId = 3, FormatId = 3 },

                new Event { Title = "Seattle Job Fair", Description = "Seattle Career Fair", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 4 },

                new Event { Title = "Meet us at the sky", Description = "Hot Air Balloon adventure ride", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16",
                    MaxOccupancy = 25, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 3, Address = "219 Madison Ave",
                    SubCategoryId = 10, UserId = 3, FormatId = 11 },

                new Event { Title = "Vector Stock", Description = "A complete wellness guide", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/17",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 6, UserId = 3, FormatId = 3 },

                new Event { Title = "Pro Club", Description = "A complete sports league", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/18",
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 9, UserId = 3, FormatId = 5 },

                new Event { Title = "Mind, Heart & Soul", Description = "A complete You!!", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/19",
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 6, UserId = 3, FormatId = 8 },
            };
        }
    }
}
