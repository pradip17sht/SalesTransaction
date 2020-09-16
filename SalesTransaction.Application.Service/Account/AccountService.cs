using Microsoft.Extensions.Configuration;
using SalesTransaction.Application.DataAccess.Account;
using SalesTransaction.Application.Model;
using SalesTransaction.Application.Service.Account;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SalesTransaction.Application.Service.Account
{
    public class AccountService : IAccountService
    {
        private DataAccessHelper _da;
        private readonly int _commandTimeOut;
        private readonly string _connectionString;
        private IConfiguration _configuration;
        public AccountService(IConfiguration configuration)
        {
            _configuration = configuration;

            dynamic connectionString = _configuration.GetSection("ConnectionString");
            _connectionString = connectionString["DefaultConnection"];

            if (_connectionString != null)
            {
                _da = new DataAccessHelper(_connectionString);
            }
            _commandTimeOut = Convert.ToInt32(connectionString["CommandTimeOut"]);
        }

        public dynamic GetLogin(Login login)
        {
            using (var con = _da.GetConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SpUserSel";
                //cmd.Parameters.Add("@Json", SqlDbType.NChar).Value = login;

                using SqlDataReader rdr = cmd.ExecuteReader();
                {
                    try
                    {
                        if (rdr.HasRows)
                        {
                            return _da.GetJson(rdr);
                        }
                        else
                        {
                            return null;
                        }
                    }catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        public dynamic GetUserDetail(string json)
        {
            using (var con = _da.GetConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SpUserSel";
                //cmd.Parameters.Add("@Json", SqlDbType.NChar).Value = login;

                using SqlDataReader rdr = cmd.ExecuteReader();
                {
                    try
                    {
                        if (rdr.HasRows)
                        {
                            return _da.GetJson(rdr);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
