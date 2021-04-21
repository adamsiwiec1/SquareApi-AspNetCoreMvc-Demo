using Square;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquareApi_AspNetCoreMvc_Demo.Models
{
    public class ProcessPaymentModel
    {
        private SquareClient client;
        private string locationId;

        public string ResultMessage { get; set; }

        public ProcessPaymentModel(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            // Get environment
            Square.Environment environment = configuration["AppSettings:Environment"] == "sandbox" ?
                Square.Environment.Sandbox : Square.Environment.Production;

            // Build base client
            client = new SquareClient.Builder()
                .Environment(environment)
                .AccessToken(configuration["AppSettings:AccessToken"])
                .Build();

            locationId = configuration["AppSettings:LocationId"];
        }

    }
}
