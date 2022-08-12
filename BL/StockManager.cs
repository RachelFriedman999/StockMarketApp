using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockMarketApp.BL.Interface;
using StockMarketApp.DataEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockMarketApp.BL
{
    public class StocksManager : IStocksManager
    {
        private readonly ILogger<StocksManager> _logger;
        public List<Stock> Stocks { get; set; }

        public StocksManager(ILogger<StocksManager> logger)
        {
            _logger = logger;
            InitStocks();
        }

        public void InitStocks()
        {
            Stocks = ReadFromFile<Stock>("Stocks.json");
        }

        public List<T> ReadFromFile<T>(string filePath) where T : new()
        {
            string jsonData = string.Empty;
            var res = new List<T>();
            try
            {
                if (File.Exists(filePath))
                {
                    using StreamReader r = new StreamReader(filePath);
                    jsonData = r.ReadToEnd();
                    res = JsonConvert.DeserializeObject<List<T>>(jsonData);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "failed in StocksManager.ReadFromFile:" + ex.ToString());
                throw ex;
            }
            return res;
        }
        //ASYNC LOADING

        //public async Task initStocks()
        //{
        //    this.Stocks = await ReadFromFile<Stock>("Stocks.json");
        //}

        //public async static task<list<t>> readfromfile<t>(string filepath) where t : new()
        //{
        //    string jsondata = string.empty;
        //    var res = new list<t>();
        //    try
        //    {
        //        if (file.exists(filepath))
        //        {
        //            using streamreader r = new streamreader(filepath);
        //            jsondata = await r.readtoendasync();
        //            res = jsonconvert.deserializeobject<list<t>>(jsondata);
        //        }
        //    }
        //    catch (exception ex)
        //    {
        //_logger.Log(LogLevel.Error, ex.ToString());
        //        throw ex;
        //    }
        //    return res;
        //}

        public List<Stock> GetStocks(DateTime? fromDate = null)
        {
            var res = Stocks;
            try
            {
                if (fromDate != null)
                {
                    res = Stocks?.Where(stock => stock.LastUpdate > fromDate)?.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "failed in StocksManager.GetStocks:" + ex.ToString());
                throw;
            }
            return res;
        }
    }
}