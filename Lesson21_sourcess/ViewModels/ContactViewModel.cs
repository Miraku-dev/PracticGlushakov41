using System.ComponentModel.DataAnnotations;

namespace PhoneBook.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "ФИО обязательно")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Телефон обязателен")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}