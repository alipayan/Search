using Elastic.Clients.Elasticsearch;
using Mapster;
using MassTransit;
using Search.Infrasctructor.Consumers.IntegrationEvents;
using Search.Models;

namespace Search.Infrasctructor.Consumers
{
    public class CatalogItemAddedEventConsumer(ElasticsearchClient elasticsearchClient) : IConsumer<CatalogItemAddedEvent>
    {
        private readonly ElasticsearchClient _elasticsearchClient = elasticsearchClient;
        public async Task Consume(ConsumeContext<CatalogItemAddedEvent> context)
        {
            var message = context.Message;

            if (message is null)
                return;

            var catalog = message.Adapt<CatalogItemIndex>();

            //exist index
            var result = await _elasticsearchClient.Indices.ExistsAsync(CatalogItemIndex.IndexName);

            if (!result.Exists)
            {
                await _elasticsearchClient.Indices.CreateAsync<CatalogItemIndex>(index: CatalogItemIndex.IndexName);
            }

            var response = await _elasticsearchClient.IndexAsync(catalog, index: CatalogItemIndex.IndexName);

            if (response.IsValidResponse)
            {
                Console.WriteLine("");
            }
        }
    }


}
