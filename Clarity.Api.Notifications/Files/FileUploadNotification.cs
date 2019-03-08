namespace Clarity.Api.Files
{
    using System;
    using Core;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class FileUploadNotification : INotification
    {
        public EventIds EventId { get; set; }

        public IFormFileCollection Files { get; set; }

        public FileModel[] Models { get; set; }

        public Exception Exception { get; set; }
    }
}
