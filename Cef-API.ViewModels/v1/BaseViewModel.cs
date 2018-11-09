namespace Cef_API.ViewModels.v1
{
    using System;

    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}