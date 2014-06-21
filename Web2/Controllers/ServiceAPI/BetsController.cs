using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Botfair.Web2.Controllers.ServiceAPI
{
    public class BetsController : ApiController
    {
        [Queryable]
        public IQueryable<ApiEntities.Bet> Get()
        {

            using (var context = new botfairEntities())
            {
                var query =
                   from item in
                       context.V_Bets.ToList()
                   select new ApiEntities.Bet()
                   {
                       MarketId = item.fk_market,
                       MoneyPosted = (double)item.sizePosted,
                       PricePosted = (double)item.pricePosted,
                       MarketName = item.name,
                       SelectionName = item.selectionName,
                       SelectionId = item.fk_selection,
                       DatePosted = (DateTime)item.datePosted,
                       Type = item.isLay ? "Lay" : "Back",
                       EventDate = (DateTime)item.eventDate,
                       Win = GetMarketResults(item.fk_market)
                   };


                return query.ToList().AsQueryable();

            }

        }

        private double GetMarketResults(int marketId)
        {
            double result = 0;
            using (var context = new botfairEntities())
            {
                var marketBets = context.V_Bets.Where(item => item.fk_market == marketId).ToList();
                var backBet = marketBets.FirstOrDefault(item => item.isLay == false);
                if (backBet != null)
                {

                    double backPrizePosted = backBet.pricePosted == null ? 0 : (double)backBet.pricePosted;
                    double backSizePosted = backBet.sizePosted == null ? 0 : (double)backBet.sizePosted;

                    double backWin = backPrizePosted * backSizePosted - backSizePosted;
                    var layBet = marketBets.FirstOrDefault(item => item.isLay == true);
                    if (layBet != null)
                    {
                        double layPrizePosted = layBet.pricePosted == null ? 0 : (double)layBet.pricePosted;
                        double laySizePosted = layBet.sizePosted == null ? 0 : (double)layBet.sizePosted;

                        var layLoss = laySizePosted * layPrizePosted - laySizePosted;

                        result = backWin - layLoss;
                        result = Math.Round(result,2);
                    }
                }
            }

            return result;
        }




    }
}