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
                SaveCategoryData(context);

            }
            if (!context.SubCategories.Any())
            {

                SaveSubCategoryData(context);

            }

            if (!context.Formats.Any())
            {
                SaveFormatsData(context);
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
                SaveEventsData(context);
               
            }

            if (!context.TicketCategories.Any())
            {

                SaveTicketCategoryData(context);

            }
            if (!context.Tickets.Any())
            {

                SaveTicketData(context);

            }
        }


        private static void SaveCategoryData(EventCatalogContext context)
        {

            List<Category> CategoryData;

            CategoryData = new List<Category>
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

            foreach (var data in CategoryData)
            {
                context.Categories.Add(data);
                context.SaveChanges();
            }
        }


        private static void SaveSubCategoryData(EventCatalogContext context)
        {
            List<SubCategory> SubCategoryData;
            SubCategoryData = new List<SubCategory>
            {

                new SubCategory { SubCategoryName = "Career", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Real Estate", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Sales & Marketing", CategoryId = 1 },
                new SubCategory { SubCategoryName = "Education", CategoryId = 2 },
                new SubCategory { SubCategoryName = "Food", CategoryId = 3 },
                new SubCategory { SubCategoryName = "Medical", CategoryId = 4 },
                new SubCategory { SubCategoryName = "Classical", CategoryId = 5 },
                new SubCategory { SubCategoryName = "Robotics", CategoryId = 6 },
                new SubCategory { SubCategoryName = "Hiking", CategoryId = 7 },
                new SubCategory { SubCategoryName = "League", CategoryId = 7 },
                new SubCategory { SubCategoryName = "Travel", CategoryId = 8 }
            };
            foreach (var data in SubCategoryData)
            {
                context.SubCategories.Add(data);
                context.SaveChanges();
            }

        }


        private static void SaveFormatsData(EventCatalogContext context)
        {

            List<Format> EventFormat;

            EventFormat = new List<Format>
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

            foreach (var data in EventFormat)
            {
                context.Formats.Add(data);
                context.SaveChanges();
            }

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
                new Location { City = "Vancouver", State = "BC"},
            };
        }

       
        private static void SaveEventsData(EventCatalogContext context)
        {
            List< Event >  EventsData=new List<Event>
            {

                new Event { Title = "Diversity Career Group", Description = "Tech Career Fair", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,02,16,9,0,0), EndDate = new DateTime(2022,02,18,17,0,0) , IsPaidEvent = false ,
                    IsOnlineEvent = true, IsCancelled = false, EventLinkUrl = "http://google.com",  Address = null,
                    SubCategoryId = 1, UserId = 3, FormatId = 4 },

                new Event { Title = "Photowalk", Description = "Seattle Center with Nikon", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,01,31,10,30,0), EndDate = new DateTime(2022,02,01,2,30,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 3, Address = "1000 1st Ave",
                    SubCategoryId = 3, UserId = 3, FormatId = 9 },

                new Event { Title = "Dream House", Description = "New Homebuyer Workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3",
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2022,02,01,10,0,0), EndDate = new DateTime(2022,02,02,12,0,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 5, Address = "1000 1st Ave",
                    SubCategoryId = 2, UserId = 3, FormatId = 6 },

                new Event { Title = "Tech Carrier Fair ", Description = "Exclusive Tech Hiring", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,03,03,9,0,0), EndDate = new DateTime(2022,04,04,17,0,0) , IsPaidEvent = false ,
                    IsOnlineEvent = true, IsCancelled = false, EventLinkUrl = "http://google.com",  Address = null,
                    SubCategoryId = 1, UserId = 3, FormatId = 4 },

                new Event { Title = "Taste Maker", Description = "Cooking Classes", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,01,15,14,15,0), EndDate = new DateTime(2022,01,17,15,45,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = null, LocationId = 9, Address = "1800 12th Ave",
                    SubCategoryId = 5, UserId = 3, FormatId = 2 },

                new Event { Title = "The Market Experience", Description = "Classic Italian Cuisine", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6",
                    MaxOccupancy = 10, MaxTicketsPerUser = 4, StartDate = new DateTime(2022,03,03,10,30,0), EndDate = new DateTime(2022,03,03,18,0,0) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 11, Address = "8352 Marvon Dr.",
                    SubCategoryId = 5, UserId = 3, FormatId = 10 },
                
                new Event { Title = "Know your options", Description = "How to choose right insurance plan workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7",
                    MaxOccupancy = 10, MaxTicketsPerUser = 2, StartDate = new DateTime(2022,02,05,12,30,0), EndDate = new DateTime(2022,02,06,14,0,0) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = true, EventLinkUrl = null, LocationId = 13, Address = "8352 Marvon Dr.",
                    SubCategoryId = 6, UserId = 3, FormatId = 2 },

                new Event { Title = "Karaoke Event", Description = "A melodious night", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8",
                    MaxOccupancy = 40, MaxTicketsPerUser = 2, StartDate = new DateTime(2022,01,21,19,30,0), EndDate = new DateTime(2022,01,22,21,30,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 2, Address = "12 00 21st Ave",
                    SubCategoryId = 7, UserId = 3, FormatId = 7 },

                new Event { Title = "Harmony", Description = "A musical workshop", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9",
                    MaxOccupancy = 15, MaxTicketsPerUser = 2, StartDate = new DateTime(2022,01,22,14,30,0), EndDate = new DateTime(2022,01,23,16,0,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 4, Address = "8352 Marvon Dr.",
                    SubCategoryId = 4, UserId = 3, FormatId = 2 },
                
                new Event { Title = "Cruise Away", Description = "Exploring the sea together", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10",
                    MaxOccupancy = 150, MaxTicketsPerUser = 6, StartDate = new DateTime(2022,02,22,8,30,0), EndDate = new DateTime(2022,03,22,22,30,0) , IsPaidEvent = true,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 6, Address = "1000 1st Ave",
                    SubCategoryId = 11, UserId = 3, FormatId = 11 },

                new Event { Title = "Park & Hike Event", Description = "Hike in the woods", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11",
                    MaxOccupancy = 20, MaxTicketsPerUser = 4, StartDate = new DateTime(2022,01,14,5,30,0), EndDate = new DateTime(2022,02,14,9,30,0) , IsPaidEvent = true,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 1, Address = "8352 Marvon Dr.",
                    SubCategoryId = 9, UserId = 3, FormatId = 6 },

                new Event { Title = "Family.Life.Education", Description = "Learn-Grow-Fulfill your Potential", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12",
                    MaxOccupancy = 6, MaxTicketsPerUser = 4, StartDate = new DateTime(2022,01,11,11,15,0), EndDate = new DateTime(2022,01,14,12,45,0) , IsPaidEvent = false ,
                    IsOnlineEvent = true, IsCancelled = false, EventLinkUrl = "http://google.com", Address = null,
                    SubCategoryId = 4 , UserId = 3, FormatId = 3 },

                new Event { Title = "Education Foundation", Description = "Education for All", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13",
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,05,05,9,0,0), EndDate = new DateTime(2022,05,06,14,30,0) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 8, Address = "8352 Marvon Dr.",
                    SubCategoryId = 4, UserId = 3, FormatId = 3 },

                new Event { Title = "After School Enrichment Programs", Description = "S.T.E.M", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14",
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,01,12,3,50,0), EndDate = new DateTime(2022,04,12,6,0,0) , IsPaidEvent = false ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = "http://google.com", LocationId = 8, Address = "219 Madison Ave",
                    SubCategoryId = 8, UserId = 3, FormatId = 2 },

                new Event { Title = "Seattle Job Fair", Description = "Seattle Career Fair", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15",
                    MaxOccupancy = 30, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,2,2,9,0,0), EndDate = new DateTime(2022,2,3,17,0,0) , IsPaidEvent = true ,
                    IsOnlineEvent = true, IsCancelled = false, EventLinkUrl = "http://google.com", Address = null,
                    SubCategoryId = 1, UserId = 3, FormatId = 4 },

                new Event { Title = "Meet us at the sky", Description = "Hot Air Balloon adventure ride", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16",
                    MaxOccupancy = 25, MaxTicketsPerUser = 4, StartDate = new DateTime(2022,2,5,10,0,0), EndDate = new DateTime(2022,2,6,13,0,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 3, Address = "park",
                    SubCategoryId = 11, UserId = 3, FormatId = 11 },

                new Event { Title = "Vector Stock", Description = "A complete wellness guide", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/17",
                    MaxOccupancy = 10, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,2,5,12,0,0), EndDate = new DateTime(2022,2,5,15,0,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 1, Address = "219 Madison Ave",
                    SubCategoryId = 6, UserId = 3, FormatId = 3 },

                new Event { Title = "Pro Club", Description = "A complete sports league", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/18",
                    MaxOccupancy = 20, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,1,31,9,0,0), EndDate = new DateTime(2022,2,13,5,0,0) , IsPaidEvent = true ,
                    IsOnlineEvent = false, IsCancelled = false, EventLinkUrl = null, LocationId = 1, Address = "220 Madison Ave",
                    SubCategoryId = 10, UserId = 3, FormatId = 5 },

                new Event { Title = "Mind, Heart & Soul", Description = "A complete You!!", EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/19",
                    MaxOccupancy = 15, MaxTicketsPerUser = 1, StartDate = new DateTime(2022,1,31,19,0,0), EndDate = new DateTime(2022,2,2,20,0,0) , IsPaidEvent = false ,
                    IsOnlineEvent = true, IsCancelled = false, EventLinkUrl = "http://google.com",  Address = null,
                    SubCategoryId = 6, UserId = 3, FormatId = 8 }
            };

            foreach (var data in EventsData)
            {
                context.EventCatalog.Add(data);
                context.SaveChanges();
            }

        }


        private static void SaveTicketCategoryData(EventCatalogContext context)
        {
            List<TicketCategory> TicketCategoryData;
            TicketCategoryData = new List<TicketCategory>
            {
                new TicketCategory { TicketCategoryName = "Student" },
                new TicketCategory { TicketCategoryName = "General Admission" },
                new TicketCategory { TicketCategoryName = "Senior" },
                new TicketCategory { TicketCategoryName = "Child" },
                new TicketCategory { TicketCategoryName = "EarlyBird-Child" },
                new TicketCategory { TicketCategoryName = "EarlyBird-Adult" },
                new TicketCategory { TicketCategoryName = "EarlyBird-Senior"},
                new TicketCategory { TicketCategoryName = "Military" }
               
            };
            foreach (var data in TicketCategoryData)
            {
                context.TicketCategories.Add(data);
                context.SaveChanges();
            }

        }


        private static void SaveTicketData(EventCatalogContext context)
        {
            List<Ticket> TicketsData;
            TicketsData = new List<Ticket>
            {
                //Free Ticket Based on Event Data - Description = "Tech Career Fair"
                new Ticket { EventId=1, SalesStartDate= new DateTime(2021, 12, 6), SalesEndDate= new DateTime(2022, 1, 20), Price =0, TicketCategoryId = 2 ,Quantity=30},
                
               //Paid  Ticket Based on Event Data -Description = "Seattle Center with Nikon"
                new Ticket { EventId=2, SalesStartDate= new DateTime(2021, 12, 7), SalesEndDate= new DateTime(2021, 12, 17), Price =10, TicketCategoryId = 6 ,Quantity=3},
                new Ticket { EventId=2, SalesStartDate= new DateTime(2021, 12, 7), SalesEndDate= new DateTime(2021, 12, 20), Price =10, TicketCategoryId = 1 ,Quantity=3},
                new Ticket { EventId=2, SalesStartDate= new DateTime(2021, 12, 18), SalesEndDate= new DateTime(2021, 12, 31), Price =15, TicketCategoryId = 2 ,Quantity=4},
               
                //Paid  Ticket Based on Event Data - Description = "New Homebuyer Workshop"
                new Ticket { EventId=3, SalesStartDate= new DateTime(2021, 12, 16), SalesEndDate= new DateTime(2022, 1, 19), Price =15, TicketCategoryId = 2 ,Quantity=8},
                new Ticket { EventId=3, SalesStartDate= new DateTime(2021, 12, 16), SalesEndDate= new DateTime(2022, 1, 19), Price =5, TicketCategoryId = 8 ,Quantity=2},
             
                //Free Ticket Based on Event Data-Description = "Exclusive Tech Hiring"
                new Ticket { EventId=4 , SalesStartDate= new DateTime(2022, 1, 1), SalesEndDate= new DateTime(2022, 2, 20), Price =0, TicketCategoryId = 2 ,Quantity=30},

                //Paid-Cancelled  Ticket Based on Event Data - Description = "Cooking Classes"
                new Ticket { EventId=5, SalesStartDate= new DateTime(2021, 12, 7), SalesEndDate= new DateTime(2022, 1, 10), Price =10, TicketCategoryId = 2 ,Quantity=10},
               
                //Free Ticket Based on Event Data-"Classic Italian Cuisine"
                new Ticket { EventId=6, SalesStartDate= new DateTime(2022, 2, 01), SalesEndDate= new DateTime(2022, 2, 15), Price =0, TicketCategoryId = 2 ,Quantity=10},
               
                //Free-Cancelled  Ticket Based on Event Data-Description = "How to choose right insurance plan workshop"
                new Ticket { EventId=7, SalesStartDate= new DateTime(2022, 01, 10), SalesEndDate= new DateTime(2022, 01, 15), Price =0, TicketCategoryId = 2 ,Quantity=10},
 
                //Paid  Ticket Based on Event Data-  Description =A melodious night
                new Ticket { EventId=8, SalesStartDate= new DateTime(2021, 12, 7), SalesEndDate= new DateTime(2021, 12, 18), Price =20, TicketCategoryId = 2 ,Quantity=25},
                new Ticket { EventId=8, SalesStartDate= new DateTime(2021, 12, 15), SalesEndDate= new DateTime(2021, 12, 16), Price =12, TicketCategoryId = 6 ,Quantity=15},

                //Paid  Ticket Based on Event Data- Description = "A musical workshop"
                new Ticket { EventId=9, SalesStartDate= new DateTime(2022, 1, 1), SalesEndDate= new DateTime(2022, 1, 5), Price =30, TicketCategoryId = 6 ,Quantity=5},
                new Ticket { EventId=9, SalesStartDate= new DateTime(2022, 1, 6), SalesEndDate= new DateTime(2022, 1, 18), Price =50, TicketCategoryId = 2 ,Quantity=10},
                
                //Paid  Ticket Based on Event Data- Description = "A musical workshop"
                new Ticket { EventId=10, SalesStartDate= new DateTime(2021, 12, 15), SalesEndDate= new DateTime(2022, 1, 25), Price =80, TicketCategoryId = 5 ,Quantity=30},
                new Ticket { EventId=10, SalesStartDate= new DateTime(2021, 12, 15), SalesEndDate= new DateTime(2022, 1, 25), Price =120, TicketCategoryId = 6 ,Quantity=30},
                new Ticket { EventId=10, SalesStartDate= new DateTime(2022, 1, 26), SalesEndDate= new DateTime(2022, 2, 26), Price =120, TicketCategoryId = 4 ,Quantity=30},
                new Ticket { EventId=10, SalesStartDate= new DateTime(2022, 1, 26), SalesEndDate= new DateTime(2022, 2, 26), Price =160, TicketCategoryId = 2 ,Quantity=60},

                //Paid  Ticket Based on Event Data- Description = "Hike in the woods"
                new Ticket { EventId=11, SalesStartDate= new DateTime(2022, 1, 1), SalesEndDate= new DateTime(2022, 1, 13), Price =10, TicketCategoryId = 4 ,Quantity=10},
                new Ticket { EventId=11, SalesStartDate= new DateTime(2022, 1, 1), SalesEndDate= new DateTime(2022, 1, 13), Price =20, TicketCategoryId = 2 ,Quantity=10},

                //Paid  Ticket Based on Event Data- Description = "Learn-Grow-Fulfill your Potential"
                new Ticket { EventId=12, SalesStartDate= new DateTime(2022, 1, 6), SalesEndDate= new DateTime(2022, 1, 10), Price =20, TicketCategoryId = 2 ,Quantity=6},


                //Paid  Ticket Based on Event Data- Description = "Learn-Grow-Fulfill your Potential"
                new Ticket { EventId=13, SalesStartDate= new DateTime(2021, 12, 1), SalesEndDate= new DateTime(2022, 4, 26), Price =0, TicketCategoryId = 2 ,Quantity=14},
                new Ticket { EventId=13, SalesStartDate= new DateTime(2022, 4, 19), SalesEndDate= new DateTime(2022, 4, 22), Price =0, TicketCategoryId = 6 ,Quantity=6},


                 //Paid  Ticket Based on Event Data- Description = "S.T.E.M"
                new Ticket { EventId=14, SalesStartDate= new DateTime(2021, 12, 10), SalesEndDate= new DateTime(2022, 3, 12), Price =0, TicketCategoryId = 1 ,Quantity=15},
               
                //Paid  Ticket Based on Event Data- Description = "Seattle Career Fair"
                new Ticket { EventId=15, SalesStartDate= new DateTime(2022, 1, 22), SalesEndDate= new DateTime(2022, 1, 26), Price =22, TicketCategoryId = 2 ,Quantity=25},
                new Ticket { EventId=15, SalesStartDate= new DateTime(2022, 1, 19), SalesEndDate= new DateTime(2022, 1, 22), Price =15, TicketCategoryId = 6 ,Quantity=15},

                //Paid  Ticket Based on Event Data- Description =  "Hot Air Balloon adventure ride"
                new Ticket { EventId=16, SalesStartDate= new DateTime(2021, 12, 7), SalesEndDate= new DateTime(2022, 1, 10), Price =80, TicketCategoryId = 5 ,Quantity=5},
                new Ticket { EventId=16, SalesStartDate= new DateTime(2021, 12, 7), SalesEndDate= new DateTime(2022, 1, 10), Price =120, TicketCategoryId = 6 ,Quantity=5},
                new Ticket { EventId=16, SalesStartDate= new DateTime(2022, 1, 20), SalesEndDate= new DateTime(2022, 1, 29), Price =120, TicketCategoryId = 4 ,Quantity=7},
                new Ticket { EventId=16, SalesStartDate= new DateTime(2022, 1, 20), SalesEndDate= new DateTime(2022, 1, 29), Price =160, TicketCategoryId = 2 ,Quantity=8},


                 //Paid  Ticket Based on Event Data- Description = "A complete wellness guide"
                new Ticket { EventId=17, SalesStartDate= new DateTime(2022, 1, 22), SalesEndDate= new DateTime(2022, 1, 26), Price =30, TicketCategoryId = 2 ,Quantity=5},
                new Ticket { EventId=17, SalesStartDate= new DateTime(2021, 12, 7), SalesEndDate= new DateTime(2022, 1, 22), Price =15, TicketCategoryId = 6 ,Quantity=5},

 
               //Paid  Ticket Based on Event Data- Description = "A complete sports league"
                new Ticket { EventId=18, SalesStartDate= new DateTime(2022, 1, 15), SalesEndDate= new DateTime(2022, 1, 17), Price =80, TicketCategoryId = 2 ,Quantity=13},
                new Ticket { EventId=18, SalesStartDate= new DateTime(2021, 12, 1), SalesEndDate= new DateTime(2022, 1, 14), Price =50, TicketCategoryId = 6 ,Quantity=7},

                //Paid  Ticket Based on Event Data- Description = "A complete You!!"
                new Ticket { EventId=19, SalesStartDate= new DateTime(2022, 1, 15), SalesEndDate= new DateTime(2022, 1, 17), Price =50, TicketCategoryId = 2 ,Quantity=10},
                new Ticket { EventId=19, SalesStartDate= new DateTime(2021, 12, 5), SalesEndDate= new DateTime(2022, 1, 14), Price =35, TicketCategoryId = 6 ,Quantity=5}
             };
            foreach (var data in TicketsData)
            {
                context.Tickets.Add(data);
                context.SaveChanges();
            }

        }
    }
}