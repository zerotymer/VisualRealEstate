using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using APIQueryLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConn = @"Data Source=" + System.Environment.CurrentDirectory + @"\db.db";

            Console.WriteLine(strConn);

            //APIQueryLibrary.QueryRequest.SuccessExceptionReturn = true;

            Console.Write("법정동코드: ");
            AptListService(Console.ReadLine());


            Console.WriteLine("------------------------------------------------------------------");
            Console.Write("아파트코드: ");
            APtBasisInfoService(Console.ReadLine());
        }

        private static void AptListService(string code = "2638010100")
        {
            APIQueryLibrary.PublicData.AptListService.AptListRequestByLegalDong req = new APIQueryLibrary.PublicData.AptListService.AptListRequestByLegalDong()
            {
                ServiceKey = "7igNF5yqqotAgGcOBzsQVTZQcvT22fbX0cpGpDofB4pXzWPwiVQAiiJiToTNa2q%2FnfnbeRZGLq%2Fe43QKNn1NYw%3D%3D",
                LegalCode = uint.Parse(code), //2638010100
                PageNo = 1,
                NumberOfRows = 100
            };

            APIQueryLibrary.PublicData.PublicDataResponse<APIQueryLibrary.PublicData.AptListService.AptListResponseItem> res = req.GetXmlRequest();

            Console.WriteLine("ResultCode: " + res.Header.ResultCode);
            Console.WriteLine("ResultMessage: " + res.Header.ResultMessage);
            Console.WriteLine("NumberOfRows: " + res.Body.NumberOfRows);
            Console.WriteLine("PageNumber: " + res.Body.PageNumber);
            Console.WriteLine();

            foreach (APIQueryLibrary.PublicData.AptListService.AptListResponseItem item in res.Body.Items)
            {
                Console.WriteLine(item.AptCode + " | " + item.AptName);
            }
        }

        private static void APtBasisInfoService(string code = "A10027875")
        {
            APIQueryLibrary.PublicData.AptBasisInfoService.AptBasisInformationRequest req = new APIQueryLibrary.PublicData.AptBasisInfoService.AptBasisInformationRequest()
            {
                ServiceKey = "7igNF5yqqotAgGcOBzsQVTZQcvT22fbX0cpGpDofB4pXzWPwiVQAiiJiToTNa2q%2FnfnbeRZGLq%2Fe43QKNn1NYw%3D%3D",
                AptCode = code
            };
            APIQueryLibrary.PublicData.PublicDataResponse<APIQueryLibrary.PublicData.AptBasisInfoService.AptBasisInfoResponseItem> res = req.GetXmlRequest();

            Console.WriteLine("ResultCode: " + res.Header.ResultCode);
            Console.WriteLine("ResultMessage: " + res.Header.ResultMessage);
            Console.WriteLine("NumberOfRows: " + res.Body.NumberOfRows);
            Console.WriteLine("PageNumber: " + res.Body.PageNumber);
            Console.WriteLine();
            Console.WriteLine(res.Body.Item.AptCode + " | " + res.Body.Item.AptName + " | " + res.Body.Item.AptAddress + " | " + res.Body.Item.BuildingsCount);
        }
    }
}
