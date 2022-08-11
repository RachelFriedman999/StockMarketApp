using StockMarketApp.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApp.BL.Interface
{
    public interface IStocksManager
    {
        List<Stock> Stocks { get; set; }
        List<Stock> GetStocks(DateTime? fromDate = null);
    }
}
