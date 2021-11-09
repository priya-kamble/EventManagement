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
                new Category { CategoryName = "Community & Culture" },
                new Category { CategoryName = "Family & Education" },
                new Category { CategoryName = "Fashion & Beauty" },
                new Category { CategoryName = "Film, Media & Entertainment" },
                new Category { CategoryName = "Food & Drink" },
                new Category { CategoryName = "Government & Politics" },
                new Category { CategoryName = "Health & Wellness" },
                new Category { CategoryName = "Hobbies & Special Interest" },
                new Category { CategoryName = "Home & Lifestyle" },
                new Category { CategoryName = "Music" },
                new Category { CategoryName = "Other" },
                new Category { CategoryName = "Performing & Visual Arts" },
                new Category { CategoryName = "Religion & Spirituality" },
                new Category { CategoryName = "Science & Technology" },
                new Category { CategoryName = "School Activities" },
                new Category { CategoryName = "Seasonal & Holiday" },
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
                new SubCategory { SubCategoryName = "City/Town", CategoryId = 4 },
                new SubCategory { SubCategoryName = "County", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Heritage", CategoryId = 4 },
                new SubCategory { SubCategoryName = "LGBT", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Language", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Medieval", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Nationality", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Renaissance", CategoryId = 4 },
                new SubCategory { SubCategoryName = "State", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Alumni", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Baby", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Children & Youth", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Education", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Parenting", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Parents Association", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Reunion", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Senior Citizen", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Accessories", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Beauty", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Bridal", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Fashion", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Adult", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Anime", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Comedy", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Comics", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Film", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Gaming", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 7 },
                new SubCategory { SubCategoryName = "TV", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Beer", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Food", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Spirits", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Wine", CategoryId = 8 },
                new SubCategory { SubCategoryName = "County/Municipal Government", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Democratic Party", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Federal Government", CategoryId = 9 },
                new SubCategory { SubCategoryName = "International Affairs", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Military", CategoryId = 9 },
                new SubCategory { SubCategoryName = "National Security", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Non-partisan", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Other Party", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Republican Party", CategoryId = 9 },
                new SubCategory { SubCategoryName = "State Government", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Medical", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Mental Health", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Personal Health", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Spa", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Yoga", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Adult", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Anime/Comics", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Books", CategoryId = 11 },
                new SubCategory { SubCategoryName = "DIY", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Drawing & Painting", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Gaming", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Knitting", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Photography", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Dating", CategoryId = 12 },
                new SubCategory { SubCategoryName = "Home & Garden", CategoryId = 12 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 12 },
                new SubCategory { SubCategoryName = "Pets & Animals", CategoryId = 12 },
                new SubCategory { SubCategoryName = "Acoustic", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Alternative", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Americana", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Bluegrass", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Blues", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Blues & Jazz", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Classical", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Country", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Cultural", CategoryId = 13 },
                new SubCategory { SubCategoryName = "DJ / Dance", CategoryId = 13 },
                new SubCategory { SubCategoryName = "EDM", CategoryId = 13 },
                new SubCategory { SubCategoryName = "EDM / Electronic", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Electronic", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Experimental", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Folk", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Hip Hop / Rap", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Indie", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Jazz", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Latin", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Metal", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Opera", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Pop", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Psychedelic", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Punk/Hardcore", CategoryId = 13 },
                new SubCategory { SubCategoryName = "R&B", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Religious/Spiritual", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Rock", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Singer/Songwriter", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Top 40", CategoryId = 13 },
                new SubCategory { SubCategoryName = "World", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Ballet", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Comedy", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Craft", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Dance", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Design", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Fine Art", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Jewelry", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Literary Arts", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Musical", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Opera", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Orchestra", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Painting", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Sculpture", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Theatre", CategoryId = 15 },
                new SubCategory { SubCategoryName = "Agnosticism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Atheism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Buddhism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Christianity", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Eastern Religion", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Folk Religions", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Hinduism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Islam", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Judaism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Mormonism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Mysticism & Occult", CategoryId = 16 },
                new SubCategory { SubCategoryName = "New Age", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Shintoism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Sikhism", CategoryId = 16 },
                new SubCategory { SubCategoryName = "Unaffiliated", CategoryId = 16 },
                new SubCategory { SubCategoryName = "After School Care", CategoryId = 17 },
                new SubCategory { SubCategoryName = "Dinner", CategoryId = 17 },
                new SubCategory { SubCategoryName = "Fund Raiser", CategoryId = 17 },
                new SubCategory { SubCategoryName = "Parking", CategoryId = 17 },
                new SubCategory { SubCategoryName = "Public Speaker", CategoryId = 17 },
                new SubCategory { SubCategoryName = "Raffle", CategoryId = 17 },
                new SubCategory { SubCategoryName = "Biotech", CategoryId = 18 },
                new SubCategory { SubCategoryName = "High Tech", CategoryId = 18 },
                new SubCategory { SubCategoryName = "Medicine", CategoryId = 18 },
                new SubCategory { SubCategoryName = "Mobile", CategoryId = 18 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 18 },
                new SubCategory { SubCategoryName = "Robotics", CategoryId = 18 },
                new SubCategory { SubCategoryName = "Science", CategoryId = 18 },
                new SubCategory { SubCategoryName = "Social Media", CategoryId = 18 },
                new SubCategory { SubCategoryName = "Channukah", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Christmas", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Easter", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Fall Events", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Halloween/Haunt", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Independence Day", CategoryId = 19 },
                new SubCategory { SubCategoryName = "New Years Day", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 19 },
                new SubCategory { SubCategoryName = "St Patricks Day", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Thanksgiving", CategoryId = 19 },
                new SubCategory { SubCategoryName = "Baseball", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Basketball", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Camps", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Cheer", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Cycling", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Exercise", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Fighting & Martial Arts", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Football", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Golf", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Hockey", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Lacrosse", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Motorsports", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Mountain Biking", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Obstacles", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Rugby", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Running", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Snow Sports", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Soccer", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Softball", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Swimming & Water Sports", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Tennis", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Track & Field", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Volleyball", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Walking", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Weightlifting", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Wrestling", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Yoga", CategoryId = 20 },
                new SubCategory { SubCategoryName = "Canoeing", CategoryId = 21 },
                new SubCategory { SubCategoryName = "Climbing", CategoryId = 21 },
                new SubCategory { SubCategoryName = "Hiking", CategoryId = 21 },
                new SubCategory { SubCategoryName = "Kayaking", CategoryId = 21 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 21 },
                new SubCategory { SubCategoryName = "Rafting", CategoryId = 21 },
                new SubCategory { SubCategoryName = "Travel", CategoryId = 21 }
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
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },
                
                new Event { Title = "Photowalk", Description = "Seattle Center with Nikon", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2", 
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 3, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Dream House", Description = "New Homebuyer Workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3", 
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 3, 3) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 5, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Tech Carrier Fair ", Description = "Exclusive Tech Hiring", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4", 
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 7, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Taste Maker", Description = "Cooking Classes", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5", 
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 12) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 9, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "The Market Experience", Description = "Classic Italian Cuisine", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6", 
                    MaxOccupancy = 10, MaxTicketsPerUser = 4, StartDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 12) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 11, Address = "8352 Marvon Dr.",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Know your options", Description = "How to choose right insurance plan workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7", 
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 13, Address = "8352 Marvon Dr.",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Karaoke Event", Description = "A melodious night", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8", 
                    MaxOccupancy = 40, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 2, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Harmony", Description = "A musical workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9", 
                    MaxOccupancy = 15, MaxTicketsPerUser = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 1) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 4, Address = "8352 Marvon Dr.",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Cruise Away", Description = "Exploring the sea together", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10", 
                    MaxOccupancy = 150, MaxTicketsPerUser = 6, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 6, Address = "1000 1st Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Park & Hike Event", Description = "Hike in the woods", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11", 
                    MaxOccupancy = 20, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "8352 Marvon Dr.",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Family.Life.Education", Description = "Learn-Grow-Fulfill your Potential", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12", 
                    MaxOccupancy = 6, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 3, 3) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "8352 Marvon Dr.",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Education Foundation", Description = "Education for All", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13", 
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2021, 4, 4) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 8, Address = "8352 Marvon Dr.",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "After School Enrichment Programs", Description = "S.T.E.M", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14", 
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 8, Address = "219 Madison Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Seattle Job Fair", Description = "Seattle Career Fair", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15", 
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Meet us at the sky", Description = "Hot Air Balloon adventure ride", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16", 
                    MaxOccupancy = 25, MaxTicketsPerUser = 4, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 3, Address = "219 Madison Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Vector Stock", Description = "A complete wellness guide", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/17", 
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 2, 2), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Pro Club", Description = "A complete sports league", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/18", 
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 3, 3), EndDate = new DateTime(2022, 4, 4) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },

                new Event { Title = "Mind, Heart & Soul", Description = "A complete You!!", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/19", 
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 2, 2) , IsPaidEvent = false , 
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://itneedstobereplaced/eventlink/1", LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 1, UserId = 3, FormatId = 1 },
            };
        }
    }
}
