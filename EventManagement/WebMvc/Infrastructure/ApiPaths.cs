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

            public static string GetAllEvent(string baseUri , int PageIndex, int PageSize,
                                              DateTime? startDate,
                                              DateTime? endDate,
                                             string city, 
                                             string state,
                                             int? formatId,
                                             int? categoryId,
                                             bool? ispaid,
                                             bool? isonline)
            {
                var filterQs = string.Empty;
              
                if (!string.IsNullOrEmpty(city))
                    {
                        filterQs = $"&city={city}";
                    }
                if (!string.IsNullOrEmpty(state))
                    {
                        filterQs = filterQs + $"&state={state}";
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
