using AutoMapper;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocialMediaApp.Data;
using SocialMediaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StressTests
{
    [MemoryDiagnoser]
    [SimpleJob(iterationCount: 5, warmupCount: 2)]
    public class PostsServiceBenchmark
    {
        private readonly PostService _service;
        private readonly ILogger<PostsServiceBenchmark> _logger;

        public PostsServiceBenchmark()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddConsole())
                              .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger<PostsServiceBenchmark>();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "BenchmarkDB")
                .Options;
            var context = new DataContext(options);
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfiles())).CreateMapper();
            var postsLogger = loggerFactory.CreateLogger<PostService>();
            _service = new PostService(context, mapper, postsLogger);
        }


        [Benchmark]
        public async Task GetPostsBenchmark()
        {
            _logger.LogInformation("Starting GetPostsBenchmark");


            await _service.GetPosts();

            _logger.LogInformation("Completed AddEvidenceBenchmark");
        }
    }
}
