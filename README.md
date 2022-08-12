# StockMarketApp

<!-- ABOUT THE PROJECT -->
## About The Project

This is an application that simulates a website to display stocks in real time. Every 60 seconds the service randomly updates the price of a stock. 
The app also allows you to filter by date.



### Built With:

NOTE: This project runs on .NetCore 3

<!-- GETTING STARTED -->
## Getting Started

To get started:
1. Clone the repo from https://github.com/RachelFriedman999/StockMarketApp.git
2. Open Visual Studio and run the app with IIS EXPRESS.
3. To filter stocks by date, add the date parameter to the url in the format yyyy-MM-dd'T'HH:mm:ss. 
   e.g. //localhost:38948/api/Stocks?fromDate=2022-08-11T18:32
4. To see logs in run time, open output window and on the top left dropdown select the project StockMarketApp.


### TODO
change first data load to asynchronous initialization (move initialization to startup or to startAsync method)
