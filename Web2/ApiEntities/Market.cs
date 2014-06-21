using System;

namespace Botfair.Web2.ApiEntities
{
    public class Market
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

        public bool IsHot { get; set; }

   
    }
}