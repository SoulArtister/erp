using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.Data
{
    public class DosContext
    {
        public static readonly DbSession dosContext = new DbSession(DatabaseType.SqlServer9, ConfigurationManager.ConnectionStrings["ApiDbConfig"].ConnectionString);

        //public static readonly DbSession dosContext = new DbSession(0, @"Server=SC-201609011026\MSSQL08R2SERVER;Initial Catalog=ERPDataForErp;User ID=sa;Password=sql2008");
    }
}
