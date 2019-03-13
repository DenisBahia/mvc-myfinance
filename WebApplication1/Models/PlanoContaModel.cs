using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Util;

namespace WebApplication1.Models
{
    public class PlanoContaModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do plano de conta")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Informe o tipo do plano de conta")]
        public String Tipo { get; set; }

        public int Usuario_Id { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public PlanoContaModel()
        {

        }

        public PlanoContaModel(IHttpContextAccessor paramHttpContextAccessor)
        {
            HttpContextAccessor = paramHttpContextAccessor;
        }

        public List<PlanoContaModel> ListaPlanoConta()
        {

            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            PlanoContaModel item;
            
            string strsql = "select * from plano_contas where usuario_id = " + HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            DAL oblDal = new DAL();
            DataTable dt = oblDal.RetDataTable(strsql);
            int i;

            for (i=0; i<= dt.Rows.Count-1; i++)
            {
                item = new PlanoContaModel();
                item.id = int.Parse(dt.Rows[i]["id"].ToString());
                item.Descricao = dt.Rows[i]["Descricao"].ToString();
                item.Usuario_Id = int.Parse(dt.Rows[i]["Usuario_Id"].ToString());
                item.Tipo = dt.Rows[i]["Tipo"].ToString();
                lista.Add(item);
            }

            return lista;

        }

        public void Insert()
        {
            string strSQL;
            if (this.id == 0)
            {
                strSQL = "insert plano_contas (descricao, tipo, usuario_id) values ('" + Descricao + "', '" + Tipo + "', " + HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado") + ")";
            }
            else
            {
                strSQL = "update plano_contas set tipo = '" + Tipo + "', descricao = '" + Descricao + "' where id = " + this.id;
            }
            
            DAL oblDal = new DAL();
            oblDal.ExecutarComandoSQL(strSQL);
        }

        public void Delete(int id)
        {
            string strSQL = "delete from plano_contas where id = " + id;
            DAL oblDal = new DAL();
            oblDal.ExecutarComandoSQL(strSQL);
        }

        public PlanoContaModel SelecionarPorId(int? id)
        {

            string strSQL = "select * from plano_contas where id = " + id;
            DAL oblDal = new DAL();
            DataTable dt;

            dt = oblDal.RetDataTable(strSQL);

            PlanoContaModel item = new PlanoContaModel();

            item.id = int.Parse(dt.Rows[0]["id"].ToString());
            item.Descricao = dt.Rows[0]["Descricao"].ToString();
            item.Usuario_Id = int.Parse(dt.Rows[0]["Usuario_Id"].ToString());
            item.Tipo = dt.Rows[0]["Tipo"].ToString();

            return item;

        }

    }
}
