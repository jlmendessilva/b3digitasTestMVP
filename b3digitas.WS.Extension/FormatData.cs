using Newtonsoft.Json.Linq;


namespace b3digitas.WS.Extension
{
    public class FormatData
    {
        public async static Task<(List<OrderModel> bidsList, List<OrderModel> asksList)> Prepare(JObject data, string money, string symbol)
        {
            List<OrderModel> bidsList = new List<OrderModel>();
            List<OrderModel> asksList = new List<OrderModel>();

            try
            {

                JArray bids = (JArray)data["bids"];
                JArray asks = (JArray)data["asks"];

                //for (int i = 0; i < Math.Min(bids.Count, asks.Count); i++)
                for (int i = 0; i < 10; i++)
                {
                    string price_bid = (string)bids[i][0];  // Preço do Bid
                    string amount_bid = (string)bids[i][1]; // Quantidade do Bid

                    string price_ask = (string)asks[i][0];  // Preço do Ask
                    string amount_ask = (string)asks[i][1]; // Quantidade do Ask

                    DateTime dateTime = DateTime.Now;
                    string formattedDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                    // Criando o order para Bid
                    var bidOrder = new OrderModel
                    {
                        Id = Guid.NewGuid(),
                        OrderId = Guid.NewGuid(),
                        CreatedDate = DateTime.Parse(formattedDate),
                        Money = money,
                        Symbol = symbol,
                        Type = "B", // Tipo B para Bid
                        Price = price_bid,
                        Quantity = amount_bid
                    };

                    // Criando o order para Ask
                    var askOrder = new OrderModel
                    {
                        Id = Guid.NewGuid(),
                        OrderId = Guid.NewGuid(),
                        CreatedDate = DateTime.Parse(formattedDate),
                        Money = money,
                        Symbol = symbol,
                        Type = "A", // Tipo A para Ask
                        Price = price_ask,
                        Quantity = amount_ask
                    };

                    // Adicionando à lista
                    bidsList.Add(bidOrder);
                    asksList.Add(askOrder);

                    Console.WriteLine($"Bids: {amount_bid} {symbol} @ {price_bid} {money}\t\t Asks:{amount_ask} {symbol} @ {price_ask} {money}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }

            return (bidsList, asksList);
        }
    }
}
