using System;
using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace TestGoogleSearch
{
    public class GoogleSearch
    {
        //API Key
        private static string API_KEY = "AIzaSyCyqAm432caVHD6ycUEWTbCNtg4rD_ao8Y";

        //The custom search engine identifier
        private static string cx = "015598178761323117960:sbbkk2__0lo";

        public static CustomsearchService Service = new CustomsearchService(
            new BaseClientService.Initializer
        {
            ApplicationName = "ISBNBookCsutomSearch",
            ApiKey = API_KEY,
        });

        public static IList<Result> Search(string searchText, string fileType = "", int topResult = 10)
        {
            Console.WriteLine("Executing google custom search for: {0} ...", searchText);

            Search search;
            List<Result> lstResult = new List<Result>();
            CseResource.ListRequest listRequest = Service.Cse.List(searchText);
            listRequest.Cx = cx;
            listRequest.Num = 10;
            if (!string.IsNullOrEmpty(fileType))
            {
                listRequest.FileType = fileType;
            }

            int net = topResult / 10;
            int odd = topResult % 10;
            for (int i = 1; i <= net; i++)
            {
                search = listRequest.Execute();
                lstResult.AddRange(search.Items);
                listRequest.Start = i*10;
            }

            if (odd > 0)
            {
                listRequest.Num = odd;
                search = listRequest.Execute();
                lstResult.AddRange(search.Items);
            }

            return lstResult;
        }
    }
}
