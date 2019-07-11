using System.ComponentModel.DataAnnotations;

namespace AbpDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}