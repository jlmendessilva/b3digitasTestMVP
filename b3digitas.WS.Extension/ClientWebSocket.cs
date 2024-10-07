using System.Net.WebSockets;
using System.Text;
using System.Text.Json;


namespace b3digitas.WS.Extension
{
    public class ClientWebSocket
    {
        public async Task ConnectAndSubscribe(string url, object subscribeMessage, Action<string> onMessageReceived)
        {
            using var ws = new System.Net.WebSockets.ClientWebSocket();
            await ws.ConnectAsync(new Uri(url), CancellationToken.None);

            // Enviar mensagem de subscribe
            await SendMessage(ws, subscribeMessage);

            // Processar as mensagens recebidas
            await ReceiveMessages(ws, onMessageReceived);
        }

        private async Task SendMessage(System.Net.WebSockets.ClientWebSocket ws, object message)
        {
            var jsonMessage = JsonSerializer.Serialize(message);
            var bytes = Encoding.UTF8.GetBytes(jsonMessage);
            var buffer = new ArraySegment<byte>(bytes);

            await ws.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task ReceiveMessages(System.Net.WebSockets.ClientWebSocket ws, Action<string> onMessageReceived)
        {
            var buffer = new byte[1048576];

            while (ws.State == WebSocketState.Open)
            {
                var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                    break;
                }
                else
                {
                    var message = Encoding.ASCII.GetString(buffer, 0, result.Count);
                    onMessageReceived(message);
                }
            }
        }
    }

}
