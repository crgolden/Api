namespace Cef_API.ViewModels.v1.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeletePersonalDataViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RequirePassword { get; set; }
    }
}
