using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NBench;
using SocialMediaApp.Data;
using SocialMediaApp.DTOs;
using SocialMediaApp.Services;

namespace StressTests
{
    internal class CommentsStressTest
    {
        Counter testCounter;
        CommentService commentService;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DataContext>() 
                .AddAutoMapper(typeof(CommentsStressTest)) 
                .AddScoped<CommentService>() 
                .BuildServiceProvider();

            var dataContext = serviceProvider.GetService<DataContext>();
            var mapper = serviceProvider.GetService<IMapper>();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

            commentService = new CommentService(dataContext, mapper, httpClientFactory);

            testCounter = context.GetCounter("CommentsCounter");
        }

        [PerfBenchmark(NumberOfIterations = 5,
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 2000,
            TestMode = TestMode.Test)]
        [CounterThroughputAssertion("CommentsCounter", MustBe.GreaterThan, 10000)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void Comment_Test()
        {  
            commentService.GetComments();

            testCounter.Increment();
        }

    }
}
