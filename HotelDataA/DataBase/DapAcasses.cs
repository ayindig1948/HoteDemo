using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HotelDataA.DataBase
{
    public class DapAcasses : IDapAcasses
    {
        private readonly IConfiguration _confi;

        public DapAcasses(IConfiguration config)
        {
            _confi = config;
        }

        public List<T> loedData<T, P>(string sql, P parm, string csName, bool IsProcedure = false)
        {

            string cs = _confi.GetConnectionString(csName);
            CommandType type = CommandType.Text;
            if (IsProcedure == true)
            {
                type = CommandType.StoredProcedure;

            }
            using (var conctein = new SqlConnection(cs))
            {
                var rooms = conctein.Query<T>(sql, parm, commandType: type).ToList<T>();
                return rooms;
            }
        }


        public void Save<T>(string sql, T parm, string csName, bool IsProcedure= false)
        {
            string cs = _confi.GetConnectionString(csName);
            CommandType type = CommandType.Text;
            if (IsProcedure == true)
            {
                type = CommandType.StoredProcedure;

            }
            using (var conctein = new SqlConnection(cs))
            {
                conctein.Execute(sql, parm, commandType: type);

            }


        }

    }
}
