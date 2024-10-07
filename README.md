#Desenvolvimento de um Microserviço em .NET Core (6 ou 7)

Crie um microserviço em .NET Core (versões 6 ou 7), seguindo as melhores práticas arquiteturais, para ser executado em um contêiner Linux na nuvem (AKS/EKS). O microserviço deve atender às seguintes funcionalidades:

Conexão ao WebSocket da Bitstamp:

Conecte-se ao WebSocket de Order Book público da Bitstamp, utilizando a WebSocket API v2.
Consulte as especificações para o Live Order Book e o mecanismo de subscrição pública em "Subscriptions > Public Channels". Não é necessário registro ou tokens.
Ingestão e Tratamento de Dados:

Mantenha a ingestão e tratamento de dados para dois instrumentos: BTC/USD e ETH/USD.
Persista os dados em um banco de dados NoSQL ou SQL para consultas futuras.
Atualizações Periódicas:

A cada 5 segundos, exiba no console (ou em uma interface web/Windows Forms, se possível):
Maior e menor preço de cada ativo.
Média de preço acumulada de cada ativo nos últimos 5 segundos.
Média de quantidade acumulada de cada ativo.
API de Simulação de Preço:

A API deve receber informações sobre a operação (compra ou venda), o instrumento e a quantidade.
Para uma compra de 100 BTCs:
Ordene os itens da coleção de "asks" do JSON da última atualização em ordem crescente de preço.
Calcule o valor correspondente a 100 BTCs, somando os valores até atingir a quantidade desejada. Se a primeira entrada atender à quantidade, retorne apenas o preço do item.
Para vendas, realize a mesma operação com a coleção de "bids", ordenando em ordem decrescente de preço.
Payload de Retorno:

O payload deve incluir:
Um ID único representando a cotação.
A coleção de itens utilizados no cálculo.
A quantidade solicitada.
O tipo de operação (compra/venda).
O resultado do cálculo.
Registre a memória do cálculo no banco de dados.
A API de simulação não deve interferir na ingestão de dados.