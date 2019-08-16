using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TesteBack.Model.Model
{
    public class Livro : IEntity
    {
        #region property
        public int? Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório Titulo")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório Genero")]
        public String Genero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório DataPublicacao")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório Pagina")]
        public String Pagina { get; set; }

        public String Autor { get; set; }

        public String Editora { get; set; }

        public String Descricao { get; set; }

        public String CapaURL { get; set; }

        public string LinkURL { get; set; } 
        #endregion

    }
}

