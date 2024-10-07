using Microsoft.Azure.Cosmos;


public class CosmosDbService
{
    private CosmosClient _cosmosClient;
    private Container _container;
    private string _endendpointUri, _primaryKey, _databaseId, _containerId;
    public CosmosDbService(string endpointUri, string primaryKey, string databaseId, string containerId)
    {
        CosmosClientOptions options = new()
        {
            AllowBulkExecution = true
        };

        _cosmosClient = new CosmosClient(endpointUri, primaryKey);
        _container = _cosmosClient.GetContainer(databaseId, containerId);

        _endendpointUri = endpointUri;
        _primaryKey = primaryKey;
        _databaseId = databaseId;
        _containerId = containerId;
    }

    public async Task BulkInsertAsync<T>(List<T> items) where T : class
    {
        var tasks = new List<Task>();

        foreach (var item in items)
        {
            try
            {
                var idProperty = item.GetType().GetProperty("OrderId");

                if (idProperty == null)
                {
                    throw new ArgumentException("O item não contém uma propriedade 'OrderId'");
                }

                var idValue = idProperty.GetValue(item, null);
                if (idValue == null)
                {
                    throw new ArgumentException("O valor da propriedade 'OrderId' é nulo");
                }

                var partitionKey = new PartitionKey(idValue.ToString());

                tasks.Add(_container.CreateItemAsync(item, partitionKey));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir item: {ex.Message}");
            }
        }
        
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao aguardar inserções: {ex.Message}");
        }
    }

    public async Task DeleteAllItemsAsync(int batchSize = 1000)
    {
        _cosmosClient = new CosmosClient(_endendpointUri, _primaryKey);

        var queryDefinition = new QueryDefinition("SELECT * FROM c");
        FeedIterator<Item> queryResultSetIterator = _container.GetItemQueryIterator<Item>(queryDefinition);

        while (queryResultSetIterator.HasMoreResults)
        {
            try
            {
                var itemsToDelete = new List<Item>();
                FeedResponse<Item> currentResultSet = await queryResultSetIterator.ReadNextAsync();

                foreach (var item in currentResultSet)
                {
                    itemsToDelete.Add(item);
                    if (itemsToDelete.Count >= batchSize)
                    {
                        break;
                    }
                }

                foreach (var item in itemsToDelete)
                {
                    await _container.DeleteItemAsync<Item>(item.id.ToString(), new PartitionKey(item.partitionKey.ToString()));
                }
            }
            catch (CosmosException cosmosEx)
            {
                Console.WriteLine($"Erro CosmosDB: {cosmosEx.StatusCode} - {cosmosEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral: {ex.Message}");
            }
        }
    }

}

public class Item
{
    public string id { get; set; }
    public string partitionKey { get; set; }
    // Outras propriedades aqui, conforme necessário
}
