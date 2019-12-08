﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionResults.Core.Infrastructure;
using ElectionResults.Core.Infrastructure.CsvModels;
using ElectionResults.Core.Models;
using ElectionResults.Core.Services.CsvProcessing;
using ElectionResults.Core.Storage;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace ElectionResults.Tests.CandidatesResultsParserTests
{
    public class TestableCandidatesResultsParser: CandidatesResultsParser
    {
        public TestableCandidatesResultsParser(IOptions<AppConfig> config) : base(config, Substitute.For<IElectionConfigurationSource>())
        {

        }
        public TestableCandidatesResultsParser(IOptions<AppConfig> config, IElectionConfigurationSource electionConfigurationSource) : base(config, electionConfigurationSource)
        {

        }
        protected override Task PopulateCandidatesListWithVotes(string csvContent, ElectionResultsData electionResultsData, ElectionResultsFile file)
        {
            return Task.CompletedTask;
        }

        public List<CandidateConfig> ParsedCandidates { get; set; }
    }
}