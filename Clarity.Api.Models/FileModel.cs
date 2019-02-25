namespace Clarity.Api
{
    using System;
    using Core;

    public class FileModel : Model
    {
        public Guid Id { get; set; }

        public string Uri { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }
    }
}
