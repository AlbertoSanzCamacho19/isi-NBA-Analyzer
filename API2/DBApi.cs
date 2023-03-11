using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net;
using System.Web;



namespace NBA_Analyzer.API
{
    public  class DBApi 
    {
        /*/public dynamic Post(string url, string json, string autorizacion = null)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.Post);
            request.AddHeader("Content-Type", "aplication/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            if (autorizacion != null)
            {
                request.AddParameter("Authorization",autorizacion)
            }

        }/*/

    }
}
