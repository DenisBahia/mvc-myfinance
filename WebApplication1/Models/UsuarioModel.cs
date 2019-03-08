using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Util;

namespace WebApplication1.Models
{
    public class UsuarioModel
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Preencha o Nome!")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Email!")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Preencha a Senha!")]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Preencha a Data de Nascimento!")]
        public String Data_Nascimento { get; set; }

        public bool ValidarLogin()
        {
            string strSQL = "select * from usuario where email = '" + Email + "' and senha = '" + Senha + "'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(strSQL);
            if ( dt.Rows.Count > 0)
            {
                id = int.Parse(dt.Rows[0]["id"].ToString());
                Nome = dt.Rows[0]["nome"].ToString();
                Data_Nascimento = dt.Rows[0]["Data_Nascimento"].ToString();
                return true;
            }
            return false;
        }

        public void RegistrarUsuario()
        {
            string strDataNascimento = DateTime.Parse( Data_Nascimento).ToString("yyyy/MM/dd");
            string strSQL = "insert into usuario (nome, email, senha, data_nascimento) values ('" + Nome + "', '" + Email + "', '" + Senha + "', '" + strDataNascimento + "')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(strSQL);

        }

    }
}
