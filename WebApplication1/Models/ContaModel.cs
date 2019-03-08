using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Util;

namespace WebApplication1.Models
{
    public class ContaModel
    {
        public int id { get; set; }
        public String Nome { get; set; }
        public Double Saldo { get; set; }
        public int Usuario_Id { get; set; }

        private IHttpContextAccessor HttpContextAccessor;

        public ContaModel()
        {

        }

        public ContaModel(IHttpContextAccessor paramHttpContextAccessor)
        {
            HttpContextAccessor = paramHttpContextAccessor;
        }

        public List<ContaModel> ListaConta()
        {

            List<ContaModel> lista = new List<ContaModel>();
            ContaModel item;
            
            string strsql = "select * from conta where usuario_id = " + HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            DAL oblDal = new DAL();
            DataTable dt = oblDal.RetDataTable(strsql);
            int i;

            for (i=0; i<= dt.Rows.Count-1; i++)
            {
                item = new ContaModel();
                item.id = int.Parse(dt.Rows[i]["id"].ToString());
                item.Nome = dt.Rows[i]["Nome"].ToString();
                item.Usuario_Id = int.Parse(dt.Rows[i]["Usuario_Id"].ToString());
                item.Saldo = double.Parse(dt.Rows[i]["Saldo"].ToString());
                lista.Add(item);
            }

            return lista;

        }
    }
}
