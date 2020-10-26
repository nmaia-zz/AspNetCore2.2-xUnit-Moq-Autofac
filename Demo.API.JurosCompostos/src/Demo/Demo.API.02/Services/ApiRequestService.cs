using Demo.API._02.Contracts;
using RestSharp;
using System;
using System.Globalization;

namespace Demo.API._02.Services
{
    public class ApiRequestService
        : IApi01Request
    {
        private readonly RestClient _restClient;
        private readonly RestRequest _restResquest;

        public ApiRequestService()
        {
            _restClient = new RestClient("https://localhost:44392");
            _restResquest = new RestRequest("taxaJuros");
        }

        public decimal GetTaxaDeJuros()
        {
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = new CultureInfo("en-US");

            var taxaDeJuros = Decimal.Parse(_restClient.Get(_restResquest).Content, style, provider);

            return taxaDeJuros;
        }
    }
}
