using b3digitas.WS.Extension;
using Newtonsoft.Json.Linq;


var subscribeMessage1 = new
{
    @event = "bts:subscribe",
    data = new
    {
        channel = "order_book_btcusd"
    }
};

var subscribeMessage2 = new
{
    @event = "bts:subscribe",
    data = new
    {
        channel = "order_book_ethusd"
    }
};

var webSocketClient1 = new ClientWebSocket();
var webSocketClient2 = new ClientWebSocket();
var formatData = new FormatData();

List<OrderModel> bidsList = new List<OrderModel>();
List<OrderModel> asksList = new List<OrderModel>();


string webSocketUrl = "wss://ws.bitstamp.net";
string endpointUri = "https://cosmosrgeastus1e529c05-4dc8-4faa-81fddb.documents.azure.com:443/";
string primaryKey = "2tkNSXEKSVoqBrO1iUCdTLlk3kDs2VVXZBCYuSvpdGry95RdKCMB4EOeRoCsEjTMnSonqfUK8GsBACDbwzHS5Q==";
string databaseId = "b3digitas";
string containerId = "Orders";
var cosmosDbService = new CosmosDbService(endpointUri, primaryKey, databaseId, containerId);


var task1 = webSocketClient1.ConnectAndSubscribe(webSocketUrl, subscribeMessage1, async (message) =>
{
    if (string.IsNullOrEmpty(message))
        return;

    JObject jsonMessage = JObject.Parse(message);
    JObject jsonData = (JObject)jsonMessage["data"];

    if (jsonData == null || !jsonData.ContainsKey("timestamp") || !jsonData.ContainsKey("bids") || !jsonData.ContainsKey("asks"))
        return;

    (bidsList, asksList) = await FormatData.Prepare(jsonData, "USD", "BTC");

    await cosmosDbService.BulkInsertAsync(bidsList);
    await cosmosDbService.BulkInsertAsync(asksList);

});

var task2 = webSocketClient1.ConnectAndSubscribe(webSocketUrl, subscribeMessage2, async (message) =>
{
    if (string.IsNullOrEmpty(message))
        return;

    JObject jsonMessage = JObject.Parse(message);
    JObject jsonData = (JObject)jsonMessage["data"];

    if (jsonData == null || !jsonData.ContainsKey("timestamp") || !jsonData.ContainsKey("bids") || !jsonData.ContainsKey("asks"))
        return;

    (bidsList, asksList) = await FormatData.Prepare(jsonData, "USD", "ETH");

    await cosmosDbService.BulkInsertAsync(bidsList);
    await cosmosDbService.BulkInsertAsync(asksList);

});

await Task.WhenAll(task1, task2);











