using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Util;

namespace WebApplication1.Models
{
    public class HomeModel
    {
        public string LerPlanoConta()
        {
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable("select * from plano_contas");
            return dt.Rows[0][0].ToString();
        }
    }
}
