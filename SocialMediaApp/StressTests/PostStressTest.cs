using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NBench;
using SocialMediaApp.Data;
using SocialMediaApp.DTOs;
using SocialMediaApp.Services;


namespace StressTests
{
    internal class PostStressTest
    {
        Counter testCounter; 
        PostService postService;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
           
            // Initialize the postService instance
            var serviceProvider = new ServiceCollection()
                .AddAutoMapper(typeof(PostStressTest))
                .AddHttpClient()
                .BuildServiceProvider();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

            var dataContext = serviceProvider.GetService<DataContext>();
            var mapper = serviceProvider.GetService<IMapper>();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            var postsLogger = loggerFactory.CreateLogger<PostService>();
            postService = new PostService(dataContext, mapper, postsLogger);

            testCounter = context.GetCounter("PostsCounter");
        }


        [PerfBenchmark(NumberOfIterations = 5,
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 2000,
            TestMode =TestMode.Test)]

        [CounterThroughputAssertion("PostsCounter", MustBe.GreaterThan, 90000)]

        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void  Post_Test()
        {

            postService.AddPost(
                   new PostDTO(
                    "dc8130bc-0d20-4e61-ba50-946082b49c40",
                    "Test content",
                    "text",
                    null,
                    DateTime.UtcNow) 
             );
        
            testCounter.Increment();
        }

          
    }
}
