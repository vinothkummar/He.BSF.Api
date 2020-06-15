using He.BSF.Core.Interface;
using He.BSF.Core.Interfaces;
using He.BSF.Core.Model;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace He.BSF.Infrastructure.Data
{
    public class ApplicantRepository : CosmosDbRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ICosmosDbClientFactory factory) : base(factory) { }

        public override string CollectionName { get; } = "BsfItems";
        public override string GenerateId(Applicant entity) => $"{Guid.NewGuid()}";
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId);

    }
}