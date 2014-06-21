using System;

namespace Botfair.Web2.ApiEntities
{
    public class Configuration
    {
       
        public int Id { get; set; }

        public int NewMarketsPeriod { get; set; }

        public int HotMarketsSeconds { get; set; }

        public double RiskValue { get; set; }

        public double Percentage { get; set; }


    }
}