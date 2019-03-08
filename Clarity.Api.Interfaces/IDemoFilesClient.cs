namespace Clarity.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDemoFilesClient
    {
        Task<Uri[]> GetDemoFileUris(CancellationToken token);
    }
}
