using b3digitas.WS.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.WebSockets;


var subscribeMessage2 = new
{
    @event = "bts:subscribe",
    data = new
    {
        channel = "order_book_ethusd"
    }
};


var webSocketClient2 = new b3digitas.WS.Extension.ClientWebSocket();
var formatData = new FormatData();
var SqlBulk = new SQLBulkCopySqlServer();

List<OrderModel> bidsList = new List<OrderModel>();
List<OrderModel> asksList = new List<OrderModel>();

// Definir a URL do WebSocket e da API
string webSocketUrl = "wss://ws.bitstamp.net";

var task2 = webSocketClient2.ConnectAndSubscribe(webSocketUrl, subscribeMessage2, async (message) =>
{
    if (string.IsNullOrEmpty(message))
        return;

    JObject jsonMessage = JObject.Parse(message);
    JObject jsonData = (JObject)jsonMessage["data"];

    if (jsonData == null || !jsonData.ContainsKey("timestamp") || !jsonData.ContainsKey("bids") || !jsonData.ContainsKey("asks"))
        return;

    (bidsList, asksList) = await FormatData.Prepare(jsonData, "USD", "ETH");

    //await SqlBulk.Send(bidsList, asksList);
    //await SendToApi(bidsList, asksList);

});

await Task.WhenAll(task2);







