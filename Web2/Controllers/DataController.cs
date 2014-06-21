using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Net;

using System.Web.Http;
using Botfair.Web2.ApiEntities.LineChart;

namespace Botfair.Web2.Controllers
{
    public class DataController : ApiController
    {
        public LineChartDataResponse GetLineChartData(int marketId, int selectionId, int itemFrom, int itemTo)
        {

            //DateTime toDate = DateTime.MaxValue;
            //var fromDate = DateTime.Parse(fromDateS, CultureInfo.CreateSpecificCulture("de"));
            //if (!String.IsNullOrEmpty(toDateS)) toDate = DateTime.Parse(toDateS, CultureInfo.CreateSpecificCulture("de"));

            var response = new LineChartDataResponse();

            var result = new seriesList();
            result.label = "Selection: " + selectionId;
            result.legendEntry = "bääää";
            result.data = new Data();
            result.data.x = new List<string>();
            //result.data.x = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
            //        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            result.data.y = new List<double>();

            response.seriesList = new List<seriesList>() { result };

            using (botfairEntities context = new botfairEntities())
            {

                var results = (from pt in context.PriceTracks
                               where
                                   pt.fk_selection == selectionId
                                   && pt.fk_market == marketId
                                   && pt.isLay == false
                               orderby pt.priceDate ascending
                               select pt).Skip(itemFrom).Take(itemTo - itemFrom);// Take(100);

                foreach (var price in results)
                {
                    result.data.x.Add(price.priceDate.ToLongTimeString());
                    result.data.y.Add(price.price);
                }
            }



            return response;
        }

        public string GetCurrentPriceTime(int marketId, int selectionId)
        {
            string result = null;
            using (botfairEntities context = new botfairEntities())
            {

                var results = (from pt in context.PriceTracks
                               where
                               pt.fk_selection == selectionId
                               && pt.fk_market == marketId
                               && pt.isLay == false
                               orderby pt.priceDate descending
                               select pt).Take(1);

                result = results.First().priceDate.ToShortDateString() + " " + results.First().priceDate.ToLongTimeString();
            }

            return result;
        }

        [Queryable]
        public IQueryable<ApiEntities.Market> GetMarkets()
        {
            using (var context = new botfairEntities())
            {
                var markets = context.V_MarketsWithTracks;
                var query =
                    from item in
                        markets.ToList()
                    select new ApiEntities.Market()
                               {
                                   Name = item.name,
                                   Id = item.id,
                                   EventDate = item.eventdate == null ? DateTime.MinValue : (DateTime)item.eventdate, // ((DateTime) item.eventdate) ToString(""),
                                   IsHot = item.isHot
                               };



                return query.ToList().AsQueryable();

            }



        }

        [Queryable]
        public IEnumerable<ApiEntities.Market> GetAllMarkets(int dummy)
        {
            using (var context = new botfairEntities())
            {
              
                var markets = context.Markets;
                var query =
                    from item in
                        markets.ToList()
                    select new ApiEntities.Market()
                    {
                        Name = item.name,
                        Id = item.id,
                        EventDate = item.eventDate == null ? DateTime.MinValue : (DateTime)item.eventDate, // ((DateTime) item.eventdate) ToString(""),
                      
                    };

                var a = query.OrderByDescending(item => item.EventDate.Date).ThenBy(item => item.EventDate.TimeOfDay); ;


                return a;

            }



        }

        [Queryable]
        public IQueryable<ApiEntities.Selection> GetSelections(int marketId)
        {

            using (var context = new botfairEntities())
            {
                var selections = context.V_SelectionsWithTracks;
                var query = from item in selections
                            where (item.marketId == marketId)
                            select
                                new ApiEntities.Selection() { Name = item.name, MarketId = marketId, SelectionId = item.selectionId };
                ;

                return query.ToList().AsQueryable();

            }

        }

      

        //public string GetXXX()
        //{
        //    using (var context = new botfairEntities())
        //    {
        //        return "sss";// context.Configurations.AsQueryable();
        //    }

        //}
    }
}







