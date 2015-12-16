# Stockfighter
My stab at a .NET stockfighter client. Based on the docs at https://starfighter.readme.io

## Installation
I'm using a pre-release version of the WebSocketSharp package. You may need to install it manually before installing the Stockfighter package:  
`Install-Package WebSocketSharp -Pre`

You should then be able to run:  
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

### Receive updated quotes for a stock in realtime
```c#
// You can omit the third parameter to receive updates for all stocks
var tape = new TickerTape("EXB123456", "TESTEX", "FOOBAR");
tape.QuoteReceived += (o, quote) => HandleNewQuote(quote);
tape.Start();

// Later...
tape.Stop(); // OR tape.Dispose();
```

### Receive realtime notifications of order fills
```c#
// You can omit the third parameter to receive updates for orders of any stock
var feed = new OrderFeed("EXB123456", "TESTEX", "FOOBAR");
feed.OrderReceived += (o, order) => HandleOrderUpdate(order);
feed.Start();

// Later...
feed.Stop(); // OR feed.Dispose();
```