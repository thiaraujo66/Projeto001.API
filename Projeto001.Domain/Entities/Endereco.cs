﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projeto001.Domain.Entities;

public partial class Endereco
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("CEP")]
    [StringLength(9)]
    [Unicode(false)]
    public string Cep { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Logradouro { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Bairro { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Numero { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Cidade { get; set; }

    [Column("UF")]
    [StringLength(2)]
    [Unicode(false)]
    public string Uf { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Complemento { get; set; }

    [Column("Id_Pessoa")]
    public int? IdPessoa { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCadastro { get; set; }

    public int? UsuarioCadastro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataAlteracao { get; set; }

    public int? UsuarioAlteracao { get; set; }

    [ForeignKey("IdPessoa")]
    [InverseProperty("Enderecos")]
    public virtual Pessoa IdPessoaNavigation { get; set; }
}