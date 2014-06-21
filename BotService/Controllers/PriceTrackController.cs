using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace BotService.Controllers
{
    public class TrackData
    {
        public string Year { get; set; }
        public int Sales { get; set; }
        public int Expenses { get; set; }
    }

    public class TrackDataFormatter : BufferedMediaTypeFormatter
    {
        public TrackDataFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {

            {
  //cols: [{id: 'A', label: 'NEW A', type: 'string'},
  //       {id: 'B', label: 'B-label', type: 'number'},
  //       {id: 'C', label: 'C-label', type: 'date'}
  //      ],
  //rows: [{c:[{v: 'a'}, {v: 1.0, f: 'One'}, {v: new Date(2008, 1, 28, 0, 31, 26), f: '2/28/08 12:31 AM'}]},
  //       {c:[{v: 'b'}, {v: 2.0, f: 'Two'}, {v: new Date(2008, 2, 30, 0, 31, 26), f: '3/30/08 12:31 AM'}]},
  //       {c:[{v: 'c'}, {v: 3.0, f: 'Three'}, {v: new Date(2008, 3, 30, 0, 31, 26), f: '4/30/08 12:31 AM'}]}
  //      ],
  //p: {foo: 'hello', bar: 'world!'}
}

            using (var writer = new StreamWriter(writeStream))
            {

                writer.Write("[");
                writer.Write("['Year', 'Sales', 'Expenses'],");
                var products = value as IEnumerable<TrackData>;
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        WriteItem(product, writer);
                    }
                }
                else
                {
                    var singleProduct = value as TrackData;
                    if (singleProduct == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    WriteItem(singleProduct, writer);
                }

                writer.Write("]");
            }
            writeStream.Close();

        }

        // Helper methods for serializing Products to CSV format. 
        private void WriteItem(TrackData product, StreamWriter writer)
        {
            writer.Write("['{0}',{1},{2}]", Escape(product.Year), Escape(product.Sales), Escape(product.Expenses));
        }

        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };

        private string Escape(object o)
        {
            if (o == null)
            {
                return "";
            }
            string field = o.ToString();
            if (field.IndexOfAny(_specialChars) != -1)
            {
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            }
            else return field;
        }
    }

    
    public class PriceTrackController : ApiController
    {
        public PriceTrackController()
        {
          

        }
        public List<TrackData> GetData()
        {
            //    [
            //  ['Year', 'Sales', 'Expenses'],
            //  ['2004',  1000,      400],
            //  ['2005',  1170,      460],
            //  ['2006',  660,       1120],
            //  ['2007',  1030,      540]
            //]

           // [{"Year":"2007","Sales":20,"Expenses":25}]
            List<TrackData> list = new List<TrackData>();

            var data = new TrackData();
            data.Year = "2007";
            data.Sales = 20;
            data.Expenses = 25;

            list.Add(data);

            return list;
            //System.Data.DataTable dt = new System.Data.DataTable("Work Day");
            //dt.Columns.Add("Year");
            //dt.Columns.Add("Sales");
            //dt.Columns.Add("Expenses");
            //var row = dt.NewRow();
            //row["Year"] = "2004";
            //row["Sales"] = 1000;
            //row["Expenses"] = 400;
            //dt.Rows.Add(row);

            //row = dt.NewRow();
            //row["Year"] = "2005";
            //row["Sales"] = 1010;
            //row["Expenses"] = 400;
            //dt.Rows.Add(row);

            //row = dt.NewRow();
            //row["Year"] = "2006";
            //row["Sales"] = 1170;
            //row["Expenses"] = 540;
            //dt.Rows.Add(row);


            //return new Bortosky.Google.Visualization.GoogleDataTable(dt). GetJson();


        }

      


    }
}
