namespace crgolden.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDemoFilesClient
    {
        Task<(Uri, long)[]> GetDemoFileUrisAndSizes(CancellationToken token);
    }
}
