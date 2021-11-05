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
            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(GetOrganizations());
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(GetUsers());
                context.SaveChanges();
            }
            if (!context.EventCatalog.Any())
            {
                context.EventCatalog.AddRange(GetEvents());
                context.SaveChanges();
            }
        }
        private static IEnumerable<Category> GetCategories(){
            return new List<Category>
            {
                new Category { CategoryName = "Appearance or Signing" },
                new Category { CategoryName = "Attraction" },
                new Category { CategoryName = "Camp, Trip, or Retreat" },
                new Category { CategoryName = "Class, Training, or Workshop" },
                new Category { CategoryName = "Concert or Performance" },
                new Category { CategoryName = "Conference" },
                new Category { CategoryName = "Convention" },
                new Category { CategoryName = "Dinner or Gala" },
                new Category { CategoryName = "Festival or Fair" },
                new Category { CategoryName = "Game or Competition" },
                new Category { CategoryName = "Meeting or Networking Event" },
                new Category { CategoryName = "Other" },
                new Category { CategoryName = "Party or Social Gathering" },
                new Category { CategoryName = "Race or Endurance Event" },
                new Category { CategoryName = "Rally" },
                new Category { CategoryName = "Screening" },
                new Category { CategoryName = "Seminar or Talk" },
                new Category { CategoryName = "Tour" },
                new Category { CategoryName = "Tournament" },
                new Category { CategoryName = "Tradeshow, Consumer Show, or Expo" }
            };
        }
        private static IEnumerable<SubCategory> GetSubCategories()
        {
            return new List<SubCategory>
            {
                /*new SubCategory { SubCategoryName = "Auto, Boat & Air", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Business & Professional", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Charity & Causes", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Community & Culture", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Family & Education", CategoryId = 12 },
                new SubCategory { SubCategoryName = "Fashion & Beauty", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Film, Media & Entertainment", CategoryId = 13 },
                new SubCategory { SubCategoryName = "Food & Drink", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Government & Politics", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Health & Wellness", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Hobbies & Special Interest", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Home & Lifestyle", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Music", CategoryId = 9 },
                new SubCategory { SubCategoryName = "Other", CategoryId = 10 },
                new SubCategory { SubCategoryName = "Performing & Visual Arts", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Religion & Spirituality", CategoryId = 11 },
                new SubCategory { SubCategoryName = "Science & Technology", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Seasonal & Holiday", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Sports & Fitness", CategoryId = 8 },
                new SubCategory { SubCategoryName = "Travel & Outdoor", CategoryId = 4 }*/
            };
        }
        private static IEnumerable<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                new Organization { UserEmailId = "john@gmail.com" },
                new Organization { UserEmailId = "wei@gmail.com" },
                new Organization { UserEmailId = "jose@gmail.com" },
                new Organization { UserEmailId = "mohammed@gmail.com" },
                new Organization { UserEmailId = "hui@gmail.com" },
                new Organization { UserEmailId = "sunita@gmail.com" },
                new Organization { UserEmailId = "fatima@gmail.com" },
                new Organization { UserEmailId = "nushi@gmail.com" },
                new Organization { UserEmailId = "anna@gmail.com" },
                new Organization { UserEmailId = "maria@gmail.com" },
                new Organization { UserEmailId = "elena@gmail.com" },
                new Organization { UserEmailId = "tatyana@gmail.com" },
                new Organization { UserEmailId = "richard@gmail.com" },
                new Organization { UserEmailId = "hong@gmail.com" },
                new Organization { UserEmailId = "sergey@gmail.com" }
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
        private static IEnumerable<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event { SubCategoryId = 1, UserEmailId = "elena@gmail.com", Title = "Women's Self Defense Seminar"  }//,
                /*new Event { SubCategoryId = 17, UserEmailId = "aleksandr@gmail.com", Title = "West Seattle April Art Walk" },
                new Event { SubCategoryId = 4, UserEmailId = "tatyana@gmail.com", Title = "Seattle Job Fair - Seattle Career Fair" },
                new Event { SubCategoryId = 1, UserEmailId = "pedro@gmail.com", Title = "2nd Saturday Work Party in Volunteer Park" },
                new Event { SubCategoryId = 16, UserEmailId = "sergey@gmail.com", Title = "The Market Experience" },
                new Event { SubCategoryId = 12, UserEmailId = "anna@gmail.com", Title = "Online Speed Dating (3 age groups) - Seattle" },
                new Event { SubCategoryId = 1, UserEmailId = "wei@gmail.com", Title = "Waterfront Birding for Beginners with Seattle Audubon" },
                new Event { SubCategoryId = 11, UserEmailId = "hui@gmail.com", Title = "2021 Pioneer Square Business Improvement Area Annual Meeting" },
                new Event { SubCategoryId = 18, UserEmailId = "richard@gmail.com", Title = "Ballard Comedy Club Presents Open Mic" },
                new Event { SubCategoryId = 3, UserEmailId = "jose@gmail.com", Title = "Photowalk: Seattle Center with Nikon" },
                new Event { SubCategoryId = 8, UserEmailId = "olga@gmail.com", Title = "ONLINE: Seattle --Saturday Free Guided Meditation. Experience the joy!" },
                new Event { SubCategoryId = 15, UserEmailId = "ibrahim@gmail.com", Title = "Introduction to the Commitment to Educational Equity" },
                new Event { SubCategoryId = 6, UserEmailId = "ram@gmail.com", Title = "Introduction to Projects & Grants" },
                new Event { SubCategoryId = 14, UserEmailId = "antonio@gmail.com", Title = "Real Estate Investing for Entrepreneurs - Seattle Online" },
                new Event { SubCategoryId = 19, UserEmailId = "nushi@gmail.com", Title = "Cathedral Yoga at Saint Marks" },
                new Event { SubCategoryId = 20, UserEmailId = "john@gmail.com", Title = "Lighting Demo: Creative Lighting featuring Nanlite Pavotubes" },
                new Event { SubCategoryId = 11, UserEmailId = "mohammed@gmail.com", Title = "Seattle Climate Strike 2021" },
                new Event { SubCategoryId = 17, UserEmailId = "lei@gmail.com", Title = "Meet Your Local Running Groups" },
                new Event { SubCategoryId = 4, UserEmailId = "maria@gmail.com", Title = "Alki Beach Clean Up" },
                new Event { SubCategoryId = 13, UserEmailId = "sunita@gmail.com", Title = "Spiritual Happy Hour / Crystals" },
                new Event { SubCategoryId = 2, UserEmailId = "elena@gmail.com", Title = "New Homebuyer Workshop" },
                new Event { SubCategoryId = 5, UserEmailId = "elena@gmail.com", Title = "Maker Chat / Open House / Show & Tell" },
                new Event { SubCategoryId = 10, UserEmailId = "hong@gmail.com", Title = "SYML live @ St Mark's Cathedral, Seattle (Abbey Arts Presents)" },
                new Event { SubCategoryId = 9, UserEmailId = "wei@gmail.com", Title = "Shaina Shepherd w/ Maya Marie, Oh Rose, Charity Thielen & Matty Gervais" }*/
            };
        }
    }  
}

