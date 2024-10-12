# Teste Prático B3 Digitas

## Descrição
Este repositório contém três projetos relacionados ao teste prático da B3 Digitas:

1. **b3digitas.API**: API responsável por fornecer cotações.
2. **b3digitas.Panel**: Exibe estatísticas das criptomoedas BTC e ETH. (necessário o projeto b3digitas.WebService.BulkInsert está rodando)
3. **b3digitas.WebService.BulkInsert**: Programa para inserção de dados capturados via websocket.

## Requisitos
- Visual Studio 2022 ou superior
- .NET 6.0 ou superior

## Como Executar
1. Baixe o repositório e abra o projeto no Visual Studio.
2. Execute o projeto para iniciar os três componentes mencionados.

## Utilização da API
### Endpoints
- **Operation**: Informe "A" (ask) ou "B" (bid).
- **Coin**: Informe "BTC" ou "ETH".
- **Quantity**: Informe um valor decimal.

### Exemplo de Resposta
A resposta da API inclui a propriedade `QuantityAvailable`, que representa a soma aproximada de todas as quantidades disponíveis na base de dados.

```json
{
  "id": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb",
  "dateCreated": "2024-10-12T11:26:28.579476-03:00",
  "operation": "A",
  "coin": "BTC",
  "quantity": "2",
  "quantityAvailable": "1,99995163",
  "totalValue": 125776.84204567,
  "usedOrders": [
    {
      "order": "4b48ffe7-297e-48de-bc0f-6cebcfb90ba1",
      "quantity": "0.29899900",
      "price": "62885",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "8f75ff81-8ddc-4c27-afa1-b06bba4d1f17",
      "quantity": "0.29899900",
      "price": "62885",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "fefc3ce1-0010-492e-8e64-7968da68fef4",
      "quantity": "0.13359300",
      "price": "62886",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "a21114a5-4683-45d6-9e25-f99e1d76a284",
      "quantity": "0.13359300",
      "price": "62886",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "d2a35f27-1720-4692-945a-4dd545a5fcaa",
      "quantity": "0.19081684",
      "price": "62888",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "e617ac43-62c0-4db6-8fee-3945ed3934a9",
      "quantity": "0.15905407",
      "price": "62890",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "b6eab70b-0d1e-43d2-902d-9ffb3a535355",
      "quantity": "0.15905407",
      "price": "62890",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "e8d8f79c-9d8a-449e-9001-8bd30d0885f6",
      "quantity": "0.23850248",
      "price": "62893",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "5ff826f9-c011-44c0-9280-d40ea116cd8e",
      "quantity": "0.23850248",
      "price": "62893",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "9e3d412e-7837-4850-b5f5-17ca93568c73",
      "quantity": "0.00032000",
      "price": "62901",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "b5e20b7f-ed1b-4aa0-ac33-703115f9e38f",
      "quantity": "0.00032000",
      "price": "62901",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "10b548d5-9f90-4adc-bb94-81a0b8529d49",
      "quantity": "0.00362129",
      "price": "62906",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "abbcc909-94d1-4f9d-953c-0673813a902b",
      "quantity": "0.00362129",
      "price": "62906",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "f78de1a6-95e2-4967-a3bc-8b933c1ff297",
      "quantity": "0.06360602",
      "price": "62907",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "ef658612-2cea-4247-95d0-5eec423e9be9",
      "quantity": "0.06360602",
      "price": "62907",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "8984f155-c256-482c-92a7-95e1e363d837",
      "quantity": "0.00753837",
      "price": "62923",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "fbe10c9c-d3e3-4e0f-afa1-f06601040407",
      "quantity": "0.00025900",
      "price": "62945",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "2abdaeea-00cf-4a5a-a659-443ebc0cdff6",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "d6be5038-9815-49c9-9ff0-1c49bdc78a83",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "d74ef9cd-a686-4b7c-bf45-9457ab402248",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "0a85d9a3-ae85-4d79-a36e-cf792add57fe",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "93c94403-04eb-42a4-b813-4fe4b02b570a",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "dbd27fbf-d34d-4958-842f-ac6248cfce78",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "576bd1e4-849b-44bc-acaf-9eaaf4e25903",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "b0946e29-2e6a-4de3-9a07-2df131686150",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "97e2e9ce-65c7-428f-8dd0-c3c613ed5eb4",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    },
    {
      "order": "66ad63ca-9ff5-4715-8eb8-1cf32a15362e",
      "quantity": "0.00059457",
      "price": "62948",
      "quoteId": "3c40d50b-bb8c-42e9-b779-fa9e67ad8cfb"
    }
  ]
}