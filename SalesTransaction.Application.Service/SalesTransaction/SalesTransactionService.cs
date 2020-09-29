using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SalesTransaction.Application.DataAccess;
using SalesTransaction.Application.Model.SalesTransaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SalesTransaction.Application.Service.SalesTransaction
{
    public class SalesTransactionService : ISalesTransactionService
    {
        private DataAccessHelper _dah;
        private readonly string _connectionString;
        private readonly int _commandTimeout;
        private IConfiguration _configuration;

        public SalesTransactionService(IConfiguration configuration)
        {
            _configuration = configuration;
            dynamic connectionString = _configuration.GetSection("ConnectionString");
            _connectionString = connectionString["DefaultConnection"];

            if (_connectionString != null)
            {
                _dah = new DataAccessHelper(_connectionString);
            }

            _commandTimeout = Convert.ToInt32(connectionString["CommandTimeout"]);
        }

        public bool AddSalesTransaction(MvSalesTransaction salesTransaction)
        {
            var jsonNew = JsonConvert.SerializeObject(salesTransaction);
            using (var con = _dah.GetConnection())
            {
                using (var cmd = new SqlCommand("SpSalesTransactionIns_Json", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@json", SqlDbType.NVarChar).Value = jsonNew;
                    cmd.CommandTimeout = _commandTimeout;

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        public bool EditSalesTransaction(MvEditSalesTransaction salesTransaction)
        {
            var jsonNew = JsonConvert.SerializeObject(salesTransaction);
            using (var con = _dah.GetConnection())
            {
                using (var cmd = new SqlCommand("SpSalesTransactionUpd_Json", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Json", SqlDbType.NChar).Value = jsonNew;
                    cmd.CommandTimeout = _commandTimeout;

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        
        public dynamic GetAllSalesTransactionDetail()
        {
            using (var con = _dah.GetConnection())
            {
                using (var cmd = new SqlCommand("SpAllSalesTransactionSel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = _commandTimeout;
                    using (var sqlrdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (sqlrdr.HasRows)
                            {
                                return _dah.GetJson(sqlrdr);
                            }
                            return null;
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
            }
                
        }
    }
}
