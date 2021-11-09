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
                new Category { CategoryName = "Auto, Boat & Air" },
                new Category { CategoryName = "Business & Professional" },
                new Category { CategoryName = "Charity & Causes" },
           
                new Category { CategoryName = "Food & Drink" },
            
                new Category { CategoryName = "Health & Wellness" },
            
                new Category { CategoryName = "Home & Lifestyle" },
                new Category { CategoryName = "Music" },
           
                new Category { CategoryName = "Performing & Visual Arts" },
            
                new Category { CategoryName = "School Activities" },
             
                new Category { CategoryName = "Sports & Fitness" },
                new Category { CategoryName = "Travel & Outdoor" }
            };
        }
        private static IEnumerable<SubCategory> GetSubCategories()
        {
            return new List<SubCategory>
            {
                new SubCategory { SubCategoryName = "Air", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Auto", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Boat", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Motorcycle/ATV", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Career", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Design", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Educators", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Environment & Sustainability", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Finance", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Investment", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Media", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Non Profit & NGOs", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Real Estate", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Sales & Marketing", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Startups & Small Business", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Animal Welfare", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Disaster Relief", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Education", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Healthcare", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Human Rights", CategoryId = 3 },
                new SubCategory { SubCategoryName = "International Aid", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Poverty", CategoryId = 3 },
       
                new SubCategory { SubCategoryName = "Beer", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Food", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Other", CategoryId =4 },
                new SubCategory { SubCategoryName = "Spirits", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Wine", CategoryId = 4 },
               
                new SubCategory { SubCategoryName = "Medical", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Mental Health", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Personal Health", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Spa", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Yoga", CategoryId = 5 },
                
                
                new SubCategory { SubCategoryName = "Home & Garden", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Pets & Animals", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Acoustic", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Alternative", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Americana", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Bluegrass", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Blues", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Blues & Jazz", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Classical", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Country", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Cultural", CategoryId = 7 },
                new SubCategory { SubCategoryName = "DJ / Dance", CategoryId = 7 },
                new SubCategory { SubCategoryName = "EDM", CategoryId = 7 },
                new SubCategory { SubCategoryName = "EDM / Electronic", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Electronic", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Experimental", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Folk", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Hip Hop / Rap", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Indie", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Jazz", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Latin", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Metal", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Opera", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Pop", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Psychedelic", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Punk/Hardcore", CategoryId = 7 },
                new SubCategory { SubCategoryName = "R&B", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Religious/Spiritual", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Rock", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Singer/Songwriter", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Top 40", CategoryId = 7 },
                new SubCategory { SubCategoryName = "World", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Ballet", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Comedy", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Craft", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Dance", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Design", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Fine Art", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Jewelry", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Literary Arts", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Musical", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Opera", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Orchestra", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Painting", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Sculpture", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Theatre", CategoryId = 8 },
              
                new SubCategory { SubCategoryName = "Biotech", CategoryId = 9 },
                new SubCategory { SubCategoryName = "High Tech", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Medicine", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Mobile", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Robotics", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Science", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Social Media", CategoryId = 9 },
              
               
                new SubCategory { SubCategoryName = "Baseball", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Basketball", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Camps", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Cheer", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Cycling", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Exercise", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Fighting & Martial Arts", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Football", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Golf", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Hockey", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Lacrosse", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Motorsports", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Mountain Biking", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Obstacles", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Rugby", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Running", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Snow Sports", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Soccer", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Softball", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Swimming & Water Sports", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Tennis", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Track & Field", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Volleyball", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Walking", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Weightlifting", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Wrestling", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Yoga", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Canoeing", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Climbing", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Hiking", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Kayaking", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Rafting", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Travel", CategoryId = 11 }
            };
        }
        private static IEnumerable<Format> GetFormats()
        {
            return new List<Format>
            {
                new Format { FormatName = "Appearance or Signing" },
                new Format { FormatName = "Attraction" },
                new Format { FormatName = "Camp, Trip, or Retreat" },
                new Format { FormatName = "Class, Training, or Workshop" },
                new Format { FormatName = "Concert or Performance" },
                new Format { FormatName = "Conference" },
                new Format { FormatName = "Convention" },
                new Format { FormatName = "Dinner or Gala" },
                new Format { FormatName = "Festival or Fair" },
                new Format { FormatName = "Game or Competition" },
                new Format { FormatName = "Meeting or Networking Event" },
                new Format { FormatName = "Other" },
                new Format { FormatName = "Party or Social Gathering" },
                new Format { FormatName = "Race or Endurance Event" },
                new Format { FormatName = "Rally" },
                new Format { FormatName = "Screening" },
                new Format { FormatName = "Seminar or Talk" },
                new Format { FormatName = "Tour" },
                new Format { FormatName = "Tournament" },
                new Format { FormatName = "Tradeshow, Consumer Show, or Expo" }
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
                    SubCategoryId = 89, UserId = 3, FormatId = 8 },

                new Event { Title = "Photowalk", Description = "Seattle Center with Nikon", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 3, Address = "1000 1st Ave",
                    SubCategoryId = 80, UserId = 3, FormatId = 17 },

                new Event { Title = "Dream House", Description = "New Homebuyer Workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3",
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 5, Address = "1000 1st Ave",
                    SubCategoryId = 94, UserId = 3, FormatId = 10 },

                new Event { Title = "Tech Carrier Fair ", Description = "Exclusive Tech Hiring", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 7, Address = "1000 1st Ave",
                    SubCategoryId = 89, UserId = 3, FormatId = 8 },

                new Event { Title = "Taste Maker", Description = "Cooking Classes", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 12) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 9, Address = "1000 1st Ave",
                    SubCategoryId = 68, UserId = 3, FormatId = 3 },

                new Event { Title = "The Market Experience", Description = "Classic Italian Cuisine", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6",
                    MaxOccupancy = 10, MaxTicketsPerUser = 4, StartDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 12) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 11, Address = "8352 Marvon Dr.",
                    SubCategoryId = 68, UserId = 3, FormatId = 7 },

                new Event { Title = "Know your options", Description = "How to choose right insurance plan workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7",
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 13, Address = "8352 Marvon Dr.",
                    SubCategoryId = 74, UserId = 3, FormatId = 3 },

                new Event { Title = "Karaoke Event", Description = "A melodious night", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8",
                    MaxOccupancy = 40, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 2, Address = "1000 1st Ave",
                    SubCategoryId = 114, UserId = 3, FormatId = 12 },

                new Event { Title = "Harmony", Description = "A musical workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9",
                    MaxOccupancy = 15, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 4, Address = "8352 Marvon Dr.",
                    SubCategoryId = 75, UserId = 3, FormatId = 3 },

                new Event { Title = "Cruise Away", Description = "Exploring the sea together", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10",
                    MaxOccupancy = 150, MaxTicketsPerUser = 6, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 6, Address = "1000 1st Ave",
                    SubCategoryId = 128, UserId = 3, FormatId = 2 },

                new Event { Title = "Park & Hike Event", Description = "Hike in the woods", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11",
                    MaxOccupancy = 20, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "8352 Marvon Dr.",
                    SubCategoryId = 36, UserId = 3, FormatId = 10 },

                new Event { Title = "Family.Life.Education", Description = "Learn-Grow-Fulfill your Potential", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12",
                    MaxOccupancy = 6, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "8352 Marvon Dr.",
                    SubCategoryId = 126 , UserId = 3, FormatId = 5 },

                new Event { Title = "Education Foundation", Description = "Education for All", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13",
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 8, Address = "8352 Marvon Dr.",
                    SubCategoryId = 75, UserId = 3, FormatId = 5 },

                new Event { Title = "After School Enrichment Programs", Description = "S.T.E.M", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14",
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 8, Address = "219 Madison Ave",
                    SubCategoryId = 5, UserId = 3, FormatId = 3 },

                new Event { Title = "Seattle Job Fair", Description = "Seattle Career Fair", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 89, UserId = 3, FormatId = 8 },

                new Event { Title = "Meet us at the sky", Description = "Hot Air Balloon adventure ride", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16",
                    MaxOccupancy = 25, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 3, Address = "219 Madison Ave",
                    SubCategoryId = 128, UserId = 3, FormatId = 2 },

                new Event { Title = "Vector Stock", Description = "A complete wellness guide", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/17",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 95, UserId = 3, FormatId = 5 },

                new Event { Title = "Pro Club", Description = "A complete sports league", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/18",
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 4, 4) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 52, UserId = 3, FormatId = 9 },

                new Event { Title = "Mind, Heart & Soul", Description = "A complete You!!", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/19",
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 96, UserId = 3, FormatId = 16 },
            };
        }
    }
}
