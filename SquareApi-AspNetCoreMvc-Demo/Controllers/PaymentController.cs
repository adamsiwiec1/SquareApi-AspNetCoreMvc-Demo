using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Square;
using Square.Apis;
using Square.Exceptions;
using Square.Models;
using SquareApi_AspNetCoreMvc_Demo.Models;
using System;

namespace SquareApi_AspNetCoreMvc_Demo.Controllers
{
    public class PaymentController : Controller
    {
        private Microsoft.Extensions.Configuration.IConfiguration iConfig;

        public PaymentController(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            iConfig = configuration;

            // Get environment
            Square.Environment environment = configuration["AppSettings:Environment"] == "sandbox" ?
                Square.Environment.Sandbox : Square.Environment.Production;

            // Build base client
            client = new SquareClient.Builder()
                .Environment(environment)
                .AccessToken(configuration["AppSettings:AccessToken"])
                .Build();

            //locationId = configuration["AppSettings:LocationId"];
        }

        // Square Instance Variables
        private SquareClient client;
        //private string locationId;
        public string ResultMessage { get; set; }

        public IActionResult SquarePayment()
        {
            SquareModel square = new SquareModel(iConfig);

            return View(square);
        }

        public IActionResult MakePayment()
        {

            return View();

        }

        private static string NewIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }

        public IActionResult ProcessPayment()
        {

            string nonce = Request.Form["nonce"];
            IPaymentsApi PaymentsApi = client.PaymentsApi;
            // Every payment you process with the SDK must have a unique idempotency key.
            // If you're unsure whether a particular payment succeeded, you can reattempt
            // it with the same idempotency key without worrying about double charging
            // the buyer.
            string uuid = NewIdempotencyKey();
            ViewData["TransactionID"] = uuid;
            //// Get the currency for the location
            //RetrieveLocationResponse locationResponse = await client.LocationsApi.RetrieveLocationAsync(locationId: locationId);
            //string currency = locationResponse.Location.Currency;

            // Monetary amounts are specified in the smallest unit of the applicable currency.
            // This amount is in cents. It's also hard-coded for $1.00,
            // which isn't very useful.
            Money amount = new Money.Builder()
                .Amount(500L)
                .Currency("USD")
                .Build();

            // To learn more about splitting payments with additional recipients,
            // see the Payments API documentation on our [developer site]
            // (https://developer.squareup.com/docs/payments-api/overview).
            CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest.Builder(nonce, uuid, amount)
                .Note("From Square Sample Csharp App")
                .Build();

            try
            {
                CreatePaymentResponse response = PaymentsApi.CreatePayment(createPaymentRequest);
                ViewData["ResultMessage"] = "Payment complete! " + response.Payment.Note;
            }
            catch (ApiException e)
            {
                ResultMessage = e.Message;
            }


            return View();

        }
    }
}
