using Microsoft.Extensions.Configuration;
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
            throw new NotImplementedException();
        }

        public bool EditSalesTransaction(MvEditSalesTransaction salesTransaction)
        {
            throw new NotImplementedException();
        }

        public dynamic GetAllSalesTransactionDetail()
        {
            using (var connection = _dah.GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SpAllSalesTransactionSel";
                command.CommandTimeout = _commandTimeout;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        if (reader.HasRows)
                        {
                            return _dah.GetJson(reader);
                        }
                        else
                        {
                            return null;
                        }
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
