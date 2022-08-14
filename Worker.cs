using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockMarketApp.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockMarketApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IStocksManager _stocksManager;

        private static Random rnd = new Random();

        public Worker(ILogger<Worker> logger, IStocksManager stockManager)
        {
            _logger = logger;
            _stocksManager = stockManager;
        }

      protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int indx, actionType, updatePrice;
            try {
                var stocks = _stocksManager.Stocks;
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    if (stocks != null && stocks.Count > 0) 
                    {
                        indx = rnd.Next(stocks.Count - 1);
                        actionType = rnd.Next(0, 1);
                        updatePrice = rnd.Next(1, 3);

                        if (actionType == 0)
                        {
                            stocks[indx].Price -= updatePrice;
                        }
                        else
                        {
                            stocks[indx].Price += updatePrice;
                        }

                        stocks[indx].LastUpdate = DateTime.Now;

                        _logger.LogInformation("Updated Stock {name}: old price {oldPrice}, new price {newPrice}", stocks[indx].Name, actionType == 0 ? stocks[indx].Price + updatePrice : stocks[indx].Price - updatePrice, stocks[indx].Price);

                    }

                    await Task.Delay(60000, stoppingToken);
                }
            } catch (Exception ex) {
                _logger.Log(LogLevel.Error, ex.ToString());
                throw ex;
            }
        }
    }
}
