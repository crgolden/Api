namespace Clarity.Api.Files
{
    using System;
    using System.Collections.Generic;
    using Core;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class FileUploadNotification : INotification
    {
        public EventIds EventId { get; set; }

        public ICollection<IFormFile> Files { get; set; }

        public FileModel[] Models { get; set; }

        public Exception Exception { get; set; }
    }
}
