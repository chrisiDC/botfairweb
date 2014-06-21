

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Botfair.Web2.ApiEntities;
using Botfair.Web2.Filters;
using Newtonsoft.Json.Linq;

namespace Botfair.Web2.Controllers.ServiceAPI
{
    public class Person
    {
        public string Name { get; set; }
    }
    public class ConfigurationController : ApiController
    {
        [Queryable]
        public IQueryable<ApiEntities.Configuration> Get()
        {

            using (var context = new botfairEntities())
            {
                var query =
                   from item in
                       context.Configurations.ToList()
                   select new ApiEntities.Configuration()
                   {

                       Id = item.id,
                       HotMarketsSeconds = item.hotMarketsSeconds,
                       NewMarketsPeriod = item.newMarketsPeriod,
                       Percentage = item.percentage,
                       RiskValue = item.riskValue
                   };


                return query.ToList().AsQueryable();

            }

        }

        //[HttpPost]
        //[ValidationActionFilter]
        //public ApiResponse Post([FromBody]List<ApiEntities.Configuration> configs)
        //{   
        //    using (var context = new botfairEntities())
        //    {
        //        foreach (var config in configs)
        //        {
        //            var dbConfig = context.Configurations.FirstOrDefault(item => item.id == config.Id);
        //            Mapper.Map(config,dbConfig);
                    
        //        }

        //        context.SaveChanges();
        //    }
        //    return new ApiResponse();
        //}
        [HttpPost]
        [ValidationActionFilter]
        public ApiResponse Post([FromBody]List<ApiEntities.Configuration> configs)
        {
            using (var context = new botfairEntities())
            {
                foreach (var config in configs)
                {
                    var dbConfig = context.Configurations.FirstOrDefault(item => item.id == config.Id);
                    Mapper.Map(config, dbConfig);

                }

                context.SaveChanges();
            }
            return new ApiResponse();
        }




    }
}

