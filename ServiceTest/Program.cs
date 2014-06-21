using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ServiceTest.BFExchange;
using ServiceTest.BFGlobal;

namespace ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = DateTime.Now;
            var to = DateTime.Now.AddMinutes(60);

            ServiceTest.BFExchange.APIRequestHeader exchangeHeader=null;
            ServiceTest.BFGlobal.APIRequestHeader globalHeader=null;

            var globalService = new BFGlobalServiceClient();
            var loginRequest = new LoginReq()
            {

                username = "Abrakadabra",
                password = "rolling123",
                productId = 82
            };


            var response = globalService.login(loginRequest);

            if (response.errorCode == LoginErrorEnum.OK)
            {
                exchangeHeader = new ServiceTest.BFExchange.APIRequestHeader() { sessionToken = response.header.sessionToken };
                globalHeader = new ServiceTest.BFGlobal.APIRequestHeader() { sessionToken = response.header.sessionToken };
            }

            BFExchangeServiceClient service = new BFExchangeServiceClient();
            var markets = service.getAllMarkets(new GetAllMarketsReq()
            {
                header = exchangeHeader,
                fromDate = DateTime.Parse(from.ToString()),
                toDate = DateTime.Parse(to.ToString()),//

                countries = new[] { "GBR" },
                eventTypeIds = new int?[] { 7 },
                locale = "de"

            });

            string[] foundMarkets = markets.marketData.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            List<Market> results = new List<Market>();
           
            foreach (string s in foundMarkets)
            {
                string[] data = s.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                var m = new Market();
                MapNewMarket(m,7, data);
                results.Add(m);
            }
        }

        public static void MapNewMarket(Market row,int eventType, string[] data)
        {
            int id = Convert.ToInt32(data[0]);

            row.id= id;
            row.name= data[1];
         
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            double timeToAdd = Convert.ToDouble(data[4]);

            if (timeToAdd > 0)
            {
                row.eventData = unixEpoch.AddMilliseconds(timeToAdd).AddHours(1);//.AddHours(1);
                //row.eventDate = row.eventDate.Subtract(TimeSpan.FromHours(1)); //GMT+2
            }
        }
    }

    class Market
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime eventData { get; set; }
    }
}
