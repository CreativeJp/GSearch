using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Customsearch.v1.Data;
using System.Net;

namespace TestGoogleSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Seach Text for PDF: ");
            string searchText = Convert.ToString(Console.ReadLine());

            Console.Write("\nHow many result(s): ");
            int top = Convert.ToInt32(Console.ReadLine());

           
            var results = GoogleSearch.Search(searchText, "pdf", top);
            Console.WriteLine(string.Format("\n---------------- Top {0} Results ------------------\n", top));
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine("({1})   Title: {0}", results[i].Title,i+1);
                Console.WriteLine("      Link: {0} \n", results[i].Link);
                //if (result.Mime == "application/pdf")
                //{
                //    SaveFile(result.FormattedUrl, result.FormattedUrl.Split('/').LastOrDefault().Replace("%20", "-"));
                //}
            }
            Console.WriteLine("----------------- END ------------------");
            Console.ReadKey();
        }

        private static bool SaveFile(string url, string fileName)
        {
            try
            {
                string targetFolder = @"C:\Users\jayp\Desktop\admindll\";
                WebClient Client = new WebClient();
                Client.DownloadFile(url, targetFolder + fileName);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
