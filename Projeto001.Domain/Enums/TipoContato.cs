using System.ComponentModel.DataAnnotations;

namespace Projeto001.Domain.Enums
{
    public enum TipoContato
    {
        [Display(Name = "Telefone Fixo")]
        Fixo = 0,

        [Display(Name = "Celular")]
        Celular = 1,

        [Display(Name = "E-mail")]
        Email = 2,

        [Display(Name = "WhatsApp")]
        WhatsApp = 3,

        [Display(Name = "Telegram")]
        Telegram = 4,

        [Display(Name = "Skype")]
        Skype = 5,

        [Display(Name = "LinkedIn")]
        LinkedIn = 6,

        [Display(Name = "Instagram")]
        Instagram = 7,

        [Display(Name = "Facebook")]
        Facebook = 8,

        [Display(Name = "Outro")]
        Outro = 9
    }
}
