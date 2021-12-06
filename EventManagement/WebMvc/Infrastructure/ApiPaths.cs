using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class Event
        {
            public static string  GetAllFormat(string baseUri)
            {
                return $"{baseUri}Format/Format";          
            }

            public static string GetAllCategory(string baseUri)
            {
                return $"{baseUri}Category/Category";
            }


            public static string GetAllLocation(string baseUri)
            {
                return $"{baseUri}Location/Locations";
            }

            public static string GetAllTicketsForEvent(string baseUri, int eventId, DateTime selectedDateTicket)
            {
                return $"{baseUri}Ticket/TicketsForEvent?eventId={eventId}&dateSelected={selectedDateTicket}";
            }

            public static string GetEventByID(string baseUri, int eventId)
            {
                return $"{baseUri}Event/EventDetailById?eventId={eventId}";
            }

            public static string GetAllEvent(string baseUri , int PageIndex, int PageSize,
                                              DateTime? startDate,
                                              DateTime? endDate,
                                              int? locationId,
                                              int? formatId,
                                              int? categoryId,
                                              bool? ispaid,
                                              bool? isonline)
            {
                var filterQs = string.Empty;
              
                if (locationId.HasValue)
                    {
                        filterQs = $"&locationid={locationId}";
                    }

                if (formatId.HasValue)
                    {
                        filterQs = filterQs + $"&Formatid={formatId}";
                    }
                if (categoryId.HasValue)
                    {
                        filterQs = filterQs + $"&Categoryid={categoryId}";
                    }
                if (ispaid.HasValue)
                    {
                        filterQs = filterQs + $"&ispaid={ispaid}";
                    }
                if (isonline.HasValue)
                    {
                        filterQs = filterQs + $"&isonline={isonline}";
                    }
                if (startDate.HasValue)
                {
                    filterQs = filterQs + $"&startDate={startDate}";
                }
                if (endDate.HasValue)
                {
                    filterQs = filterQs + $"&endDate={endDate}";
                }

                return $"{baseUri}Event/Events?"+ $"pageindex={PageIndex}&PageSize={PageSize}"+ filterQs;
            }
        }


    }
}
