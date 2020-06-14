using System;
using Microsoft.Azure.Documents;
using He.BSF.Core.Interfaces;
using He.BSF.Core.Models;
using He.BSF.Infrastructure.Data;


namespace He.BSF.Infrastructure.Data
{
    public class DocumentItemRepository : CosmosDbRepository<DocumentItem> , IDocumentItemRepository
    {
        public DocumentItemRepository(ICosmosDbClientFactory factory) : base(factory) { }

        public override string CollectionName { get; } = "DocumentItems";
        public override string GenerateId(DocumentItem entity) => $"{entity.Category}:{Guid.NewGuid()}";
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId);
    }
}
