﻿using System.ComponentModel.DataAnnotations;

namespace Projeto001.Models.Request.UsuarioRequest
{
    public class LoginModel
    {
        [Required]
        [MaxLength(80, ErrorMessage = "O campo Usuário deve ter no máximo 80 caracteres.")]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
