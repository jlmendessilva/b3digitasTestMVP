using b3digitas.WS.Extension;

string webSocketUrl = "wss://ws.bitstamp.net";
string endpointUri = "https://cosmosrgeastus1e529c05-4dc8-4faa-81fddb.documents.azure.com:443/";
string primaryKey = "2tkNSXEKSVoqBrO1iUCdTLlk3kDs2VVXZBCYuSvpdGry95RdKCMB4EOeRoCsEjTMnSonqfUK8GsBACDbwzHS5Q==";
string databaseId = "b3digitas";
string containerId = "Orders";
var cosmosDbService = new CosmosDbService(endpointUri, primaryKey, databaseId, containerId);

cosmosDbService.DeleteAllItemsAsync();