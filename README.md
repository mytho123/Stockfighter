# Stockfighter
My stab at a .NET stockfighter client. Based on the docs at https://starfighter.readme.io

## Installation
`Install-Package Stockfighter`

## Usage
I have tried to keep everything as simple as possible. Here are some examples:

### Get a venue's stocks
```c#
using Stockfighter;
// ...

var venue = new Venue("TESTEX");
var stocks = await venue.GetStocks();
```

### Get a stock's quote and orderbook
```c#
var stock = new Stock("TESTEX", "FOOBAR");

var quote = await stock.GetQuote();
var orderbook = await stock.GetOrderbook();
```

### Place a bid for 10 stocks of FOOBAR at 15$
```c#
var account = new Account("TESTEX", "EXB123456", "your-api-key");

// Defaults to a limit order. You can add a 4th parameter to specify the order type.
var order = await account.Buy("FOOBAR", 1500, 10);
```