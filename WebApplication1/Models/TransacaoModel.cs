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
    public class TransacaoModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe a data da transação")]
        public string Data { get; set; }
        [Required(ErrorMessage = "Informe o tipo da transação")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Informe o valor da transação")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "Informe a descrição da transação")]
        public string Descricao { get; set; }

        public int Usuario_Id { get; set; }

        public int Conta_Id { get; set; }
        public string Conta_Nome { get; set; }
        public int Plano_Contas_Id { get; set; }
        public string Plano_Contas_Nome { get; set; }

        //filtro
        public string DataFinal { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        private int idUsuarioLogado()
        {
            return int.Parse(HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado"));
        }

        public TransacaoModel()
        {

        }

        public TransacaoModel(IHttpContextAccessor paramHttpContextAccessor)
        {
            HttpContextAccessor = paramHttpContextAccessor;
        }

        public double SelecionarTransacoesSaldoInicial()
        {

            double dblSaldo = 0;

            string strSQL;
            DAL objDAL = new DAL();

            string strFiltros = "";

            if (Data != null)
            {
                strFiltros += $" and data< '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' ";
            }
            else
            {
                strFiltros += " and data < '1900/01/01' ";
            }
            if (Conta_Id != 0)
            {
                strFiltros += $" and conta_id = {Conta_Id} ";
            }

            /*
            if (Tipo != "*" && Tipo != null)
            {
                strFiltros += $" and t.tipo = '{Tipo}' ";
            }
            */

            strSQL = "select " +
                "    sum(valor) saldo " +
                "from " +
                "    transacao t " +
                "inner join " +
                "    plano_contas pc " +
                "on " +
                "    pc.id = t.Plano_Contas_Id " +
                "inner join " +
                "    conta c " +
                "on " +
                "    c.id = t.conta_id " +
                "where " +
                $"    pc.usuario_id = {idUsuarioLogado()} {strFiltros}";

            DataTable dt = objDAL.RetDataTable(strSQL);

            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["saldo"].ToString() != "")
                {
                    dblSaldo = double.Parse(dt.Rows[0]["saldo"].ToString());
                }
                else
                {
                    dblSaldo = 0;
                }
            }
            else
            {
                dblSaldo = 0;
            }

            return dblSaldo;

        }

        public List<TransacaoModel> SelecionarTransacoes()
        {

            List<TransacaoModel> lista = new List<TransacaoModel>();
            TransacaoModel item;

            string strSQL;
            DAL objDAL = new DAL();

            string strFiltros = "";

            if (Data != null)
            {
                strFiltros += $" and data>= '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' ";
            }
            if (DataFinal != null)
            {
                strFiltros += $" and data<= '{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}' ";
            }
            if (Conta_Id != 0)
            {
                strFiltros += $" and conta_id = {Conta_Id} ";
            }
            if (Tipo != "*" && Tipo != null)
            {
                strFiltros += $" and t.tipo = '{Tipo}' ";
            }

            strSQL = "select " +
                "    t.*, " +
                "    c.nome, " +
                "    pc.usuario_id, " +
                "    pc.descricao descricao_pc " +
                "from " +
                "    transacao t " +
                "inner join " +
                "    plano_contas pc " +
                "on " +
                "    pc.id = t.Plano_Contas_Id " +
                "inner join " +
                "    conta c " +
                "on " +
                "    c.id = t.conta_id " +
                "where " +
                $"    pc.usuario_id = {idUsuarioLogado()} {strFiltros}" +
                "order by  " +
                "    t.data desc limit 10 ";

            DataTable dt = objDAL.RetDataTable(strSQL);
            int i;

            for (i = 0; i < dt.Rows.Count; i++)
            {
                item = new TransacaoModel();
                item.id = int.Parse(dt.Rows[i]["id"].ToString());
                item.Usuario_Id = int.Parse(dt.Rows[i]["Usuario_Id"].ToString());
                item.Conta_Id = int.Parse(dt.Rows[i]["conta_id"].ToString());
                item.Plano_Contas_Id = int.Parse(dt.Rows[i]["Plano_Contas_Id"].ToString());
                item.Conta_Nome = dt.Rows[i]["nome"].ToString();
                item.Plano_Contas_Nome = dt.Rows[i]["descricao_pc"].ToString();
                item.Data = DateTime.Parse(dt.Rows[i]["data"].ToString()).ToString("dd/MM/yyyy");
                item.Descricao = dt.Rows[i]["Descricao"].ToString();
                item.Valor = double.Parse(dt.Rows[i]["valor"].ToString());
                item.Tipo = dt.Rows[i]["tipo"].ToString();
                lista.Add(item);
            }

            return lista;

        }

        public void insert()
        {

            string strSQL;
            DAL objDAL = new DAL();

            if (id > 0)
            {
                strSQL = " update transacao set " +
                $" 	Data = '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}'," +
                $" 	Tipo = '{Tipo}', " +
                $" 	Valor = {Valor}, " +
                $" 	Descricao = '{Descricao}', " +
                $" 	Conta_Id = {Conta_Id}, " +
                $" 	Plano_Contas_Id = {Plano_Contas_Id} " +
                $" where id = {id}";
            }
            else
            {
                strSQL = " INSERT transacao " +
                " 	(Data, " +
                " 	Tipo, " +
                " 	Valor, " +
                " 	Descricao, " +
                " 	Conta_Id, " +
                " 	Plano_Contas_Id)" +
                " VALUES (" +
                $"'{DateTime.Parse(Data).ToString("yyyy/MM/dd")}', " +
                $"'{Tipo}', " +
                $"{Valor}, " +
                $"'{Descricao}', " +
                $"{Conta_Id}, " +
                $"{Plano_Contas_Id})";
            }

            objDAL.ExecutarComandoSQL(strSQL);

        }

        public void Delete(int id)
        {
            string strSQL = "delete from transacao where id = " + id;
            DAL oblDal = new DAL();
            oblDal.ExecutarComandoSQL(strSQL);
        }

        public TransacaoModel select(int? id)
        {

            string strSQL;
            DAL objDAL = new DAL();

            strSQL = "select " +
                "    t.*, " +
                "    c.nome, " +
                "    pc.usuario_id, " +
                "    pc.descricao " +
                "from " +
                "    transacao t " +
                "inner join " +
                "    plano_contas pc " +
                "on " +
                "    pc.id = t.Plano_Contas_Id " +
                "inner join " +
                "    conta c " +
                "on " +
                "    c.id = t.conta_id " +
                "where " +
                $"    t.id = {id} ";

            DataTable dt = objDAL.RetDataTable(strSQL);
            int i = 0;

            TransacaoModel item = new TransacaoModel();
            item.id = int.Parse(dt.Rows[i]["id"].ToString());
            item.Usuario_Id = int.Parse(dt.Rows[i]["Usuario_Id"].ToString());
            item.Conta_Id = int.Parse(dt.Rows[i]["conta_id"].ToString());
            item.Plano_Contas_Id = int.Parse(dt.Rows[i]["Plano_Contas_Id"].ToString());
            item.Conta_Nome = dt.Rows[i]["nome"].ToString();
            item.Plano_Contas_Nome = dt.Rows[i]["descricao"].ToString();
            item.Data = DateTime.Parse(dt.Rows[i]["data"].ToString()).ToString("dd/MM/yyyy");
            item.Descricao = dt.Rows[i]["Descricao"].ToString();
            item.Valor = double.Parse(dt.Rows[i]["valor"].ToString());
            item.Tipo = dt.Rows[i]["tipo"].ToString();

            return item;

        }

    }

    public class Dashboard
    {

        public string Descricao { get; set; }
        public double Valor { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public Dashboard()
        {

        }

        public Dashboard(IHttpContextAccessor paramHttpContextAccessor)
        {
            HttpContextAccessor = paramHttpContextAccessor;
        }

        public List<Dashboard> ObterDashboard()
        {

            List<Dashboard> lista = new List<Dashboard>();

            int intIdUsuario = int.Parse(HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado"));

            string strSQL;
            DAL objDAL = new DAL();

            strSQL = "select " +
                "    pc.descricao, " +
                "    sum(t.valor) valor " +
                "from " +
                "    transacao t " +
                "inner join " +
                "    plano_contas pc " +
                "on " +
                "    pc.id = t.Plano_Contas_Id " +
                "where t.tipo = 'D' and " +
                $"    pc.Usuario_Id = {intIdUsuario} " +
                "group by " +
                "    pc.descricao ";

            DataTable dt = objDAL.RetDataTable(strSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dashboard item = new Dashboard();
                item.Descricao = dt.Rows[i]["descricao"].ToString();
                item.Valor = double.Parse(dt.Rows[i]["valor"].ToString());
                lista.Add(item);
            }

            return lista;

        }

    }

}
