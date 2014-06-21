using System;

namespace Botfair.Web2.ApiEntities
{
    public class Bet
    {
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public DateTime EventDate { get; set; }
        public int SelectionId { get; set; }
        public string SelectionName { get; set; }
        public double MoneyPosted { get; set; }
        public double PricePosted { get; set; }
        public DateTime DatePosted { get; set; }
        public string Type { get; set; }
        public double  Win { get; set; }
    }
}