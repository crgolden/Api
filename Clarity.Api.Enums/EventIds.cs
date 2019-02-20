namespace Clarity.Api
{
    public enum EventIds
    {
        IndexStart = Core.EventIds.IndexStart,
        IndexEnd = Core.EventIds.IndexEnd,
        IndexError = Core.EventIds.IndexError,
        DetailsStart = Core.EventIds.DetailsStart,
        DetailsNotFound = Core.EventIds.DetailsNotFound,
        DetailsEnd = Core.EventIds.DetailsEnd,
        DetailsError = Core.EventIds.DetailsError,
        CreateStart = Core.EventIds.CreateStart,
        CreateEnd = Core.EventIds.CreateEnd,
        CreateError = Core.EventIds.CreateError,
        CreateRangeStart = Core.EventIds.CreateRangeStart,
        CreateRangeEnd = Core.EventIds.CreateRangeEnd,
        CreateRangeError = Core.EventIds.CreateRangeError,
        EditStart = Core.EventIds.EditStart,
        EditEnd = Core.EventIds.EditEnd,
        EditError = Core.EventIds.EditError,
        EditRangeStart = Core.EventIds.EditRangeStart,
        EditRangeEnd = Core.EventIds.EditRangeEnd,
        EditRangeError = Core.EventIds.EditRangeError,
        DeleteStart = Core.EventIds.DeleteStart,
        DeleteEnd = Core.EventIds.DeleteEnd,
        DeleteError = Core.EventIds.DeleteError,
        UploadStart,
        UploadEnd,
        UploadError,
        ValidateStart,
        ValidateEnd,
        ValidateError
    }
}
