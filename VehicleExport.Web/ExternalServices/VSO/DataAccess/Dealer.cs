using Microsoft.Data.SqlClient;
using System.Collections;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using VehicleExport.Web.ExternalServices.VSO.Models;
using System.Linq;

namespace VehicleExport.Web.ExternalServices.VSO.DataAccess
{
    public class DealerData
    {

        private string _ConnectionString { get; set; }

        public DealerData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        public DealerData()
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["TWD_VSOConnectionString"].ConnectionString;
        }

        public Dealer GetDealer(int DealerId)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                return connection.QueryFirst<Dealer>(
                    $@"
                        select * from VS_Dealer where dealerId = {DealerId}
                    "
                    );
            }
        }

        public ICollection<Dealer> GetDealers()
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                return connection.Query<Dealer>(
                    $@"
                        select * from VS_Dealer
                    "
                    ).ToList();
            }
        }
    }
}
