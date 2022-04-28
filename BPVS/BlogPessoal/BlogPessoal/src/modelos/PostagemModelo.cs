﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPessoal.src.modelos
{
    [Table("tb_postagens")]
    public class PostagemModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [ForeignKey("fk_usuario")]
        public UsuarioModelo Criador { get; set; }
        
        [ForeignKey("fk_tema")]
        public TemaModelo Tema { get; set; }
    }
   }
