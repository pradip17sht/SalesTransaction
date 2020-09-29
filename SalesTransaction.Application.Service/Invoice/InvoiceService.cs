using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SalesTransaction.Application.DataAccess;
using SalesTransaction.Application.Model.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SalesTransaction.Application.Service.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private DataAccessHelper _dah; 
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        //private readonly string _commandTimeout;
        private readonly int _commandTimeout;

        public InvoiceService(IConfiguration configuration)
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


        public dynamic GetAllInvoice()
        {
            using (var con = _dah.GetConnection())
            {
                using (var cmd = new SqlCommand("SpAllInvoiceSel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = _commandTimeout;
                    using (var reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (reader.HasRows)
                            {
                                return _dah.GetJson(reader);
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


        public bool GenerateInvoice(IEnumerable<MvGenerateInvoice> salesTransaction)
        {
            var jsonNew = JsonConvert.SerializeObject(salesTransaction);
            using (var con = _dah.GetConnection())
            {
                using (var cmd = new SqlCommand("SpAltInvoiceSalesTransactionTsk", con))
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

        public dynamic GetInvoiceDetail(MvInvoice invoice)
        {
            var jsonNew = JsonConvert.SerializeObject(invoice);
            using (var con = _dah.GetConnection())
            {
                using (var cmd = new SqlCommand("SpInvoiceDetailSel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Json", SqlDbType.NChar).Value = jsonNew;
                    cmd.CommandTimeout = _commandTimeout;
                    using (var reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (reader.HasRows)
                            {
                                return _dah.GetJson(reader);
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
