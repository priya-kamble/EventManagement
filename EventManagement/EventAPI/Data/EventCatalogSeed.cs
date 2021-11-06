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
                new SubCategory { SubCategoryName = "Auto, Boat & Air", CategoryId = 5 },
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
                new SubCategory { SubCategoryName = "Travel & Outdoor", CategoryId = 4 }
            };
        }
        private static IEnumerable<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                new Organization { UserId = 3 ,OrganizationName="Creative Hands"  },
                new Organization { UserId = 4 ,OrganizationName=" Yoga and Meditation"},
                new Organization { UserId =5 ,OrganizationName="Real State In Seattle "},
                new Organization { UserId = 6 ,OrganizationName=" Sport and Meditation"},
                new Organization { UserId = 7 ,OrganizationName=" Clean World"},
                new Organization { UserId = 8 ,OrganizationName=" Festivals Arrangement Comapny"},
                new Organization { UserId = 9 ,OrganizationName=" Running Supplies"},
                new Organization { UserId = 10 ,OrganizationName=" Private Art Exhibition Arrangement Company "},
                
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
                new Event { SubCategoryId = 1, UserId = 21, Title = "Women's Self Defense Seminar"  },
                new Event { SubCategoryId = 17, UserId = 3, Title = "West Seattle April Art Walk" },
                new Event { SubCategoryId = 4, UserId = 22, Title = "Seattle Job Fair - Seattle Career Fair" },
                new Event { SubCategoryId = 1, UserId = 19, Title = "2nd Saturday Work Party in Volunteer Park" },
                new Event { SubCategoryId = 16, UserId = 18, Title = "The Market Experience" },
                new Event { SubCategoryId = 12, UserId = 9, Title = "Online Speed Dating (3 age groups) - Seattle" },
                new Event { SubCategoryId = 1, UserId = 3, Title = "Waterfront Birding for Beginners with Seattle Audubon" },
                new Event { SubCategoryId = 11, UserId = 11, Title = "2021 Pioneer Square Business Improvement Area Annual Meeting" },
                new Event { SubCategoryId = 18, UserId = 17, Title = "Ballard Comedy Club Presents Open Mic" },
                new Event { SubCategoryId = 3, UserId = 3, Title = "Photowalk: Seattle Center with Nikon" },
                new Event { SubCategoryId = 8, UserId = 15, Title = "ONLINE: Seattle --Saturday Free Guided Meditation. Experience the joy!" },
                new Event { SubCategoryId = 15, UserId = 12, Title = "Introduction to the Commitment to Educational Equity" },
                new Event { SubCategoryId = 6, UserId = 4, Title = "Introduction to Projects & Grants" },
                new Event { SubCategoryId = 14, UserId = 5, Title = "Real Estate Investing for Entrepreneurs - Seattle Online" },
                new Event { SubCategoryId = 19, UserId = 6, Title = "Cathedral Yoga at Saint Marks" },
                new Event { SubCategoryId = 20, UserId = 15, Title = "Lighting Demo: Creative Lighting featuring Nanlite Pavotubes" },
                new Event { SubCategoryId = 11, UserId = 3, Title = "Seattle Climate Strike 2021" },
                new Event { SubCategoryId = 17, UserId =9, Title = "Meet Your Local Running Groups" },
                new Event { SubCategoryId = 4, UserId = 7, Title = "Alki Beach Clean Up" },
                new Event { SubCategoryId = 13, UserId = 4, Title = "Spiritual Happy Hour / Crystals" },
                new Event { SubCategoryId = 2, UserId = 21, Title = "New Homebuyer Workshop" },
                new Event { SubCategoryId = 5, UserId = 21, Title = "Maker Chat / Open House / Show & Tell" },
                new Event { SubCategoryId = 10, UserId = 8, Title = "SYML live @ St Mark's Cathedral, Seattle (Abbey Arts Presents)" },
                new Event { SubCategoryId = 9, UserId = 7, Title = "Shaina Shepherd w/ Maya Marie, Oh Rose, Charity Thielen & Matty Gervais" }
            };
        }
    }
}