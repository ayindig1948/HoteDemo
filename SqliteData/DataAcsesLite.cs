using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace SqliteData;

public class DataAcsesLite : IDataAcsesLite
{
    private readonly IConfiguration _config;

    public DataAcsesLite(IConfiguration config)
    {
        _config=config;
    }
    public List<T> LoadData<T, P>(string sql, P par, string cStringName)
    {
        string cString=_config.GetConnectionString(cStringName);
        using (var connection = new SqliteConnection(cString))
        {
            var roes = connection.Query<T>(sql, par);
            return roes.ToList();
        }
    }
    public void Save<T>(string sql, T data, string cStringName)
    {
        string cString = _config.GetConnectionString(cStringName);
        using (var connection = new SqliteConnection(cString))
        {
            connection.Execute(sql, data);

        }


    }
}