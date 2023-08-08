using HtmlAgilityPack;
using System.Net;
using System.Text;

namespace _90minutWrapper
{
    public class DataMain
    {
        public static List<string> GetData(int clubNumber = 8711)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var iso88592 = Encoding.GetEncoding(28592);
            var url = $"http://www.90minut.pl/skarb.php?id_klub={clubNumber}";
            var web = new HtmlWeb();
            web.OverrideEncoding = iso88592;
            var doc = web.Load(url);
            //var doc = new HtmlDocument();
            //var filePath = @"C:\Users\Radek\Downloads\Skarb - Kolektyw Radwanice.html";
            //doc.Load(filePath, iso88592);

            var nodes = doc.DocumentNode.SelectNodes("//tr");
            var count = 0;
            var strList = new List<string>();
            if (nodes != null)
            {
                foreach (var trNode in nodes)
                {

                    var tdNodes = trNode.SelectNodes("./td"); // Select td elements within each tr element

                    if (tdNodes != null)
                    {
                        foreach (var tdNode in tdNodes)
                        {
                            var result = WebUtility.HtmlDecode(tdNode.InnerText.Trim());
                            if (result.Length == 0 || count < 16)
                            {
                                count++;
                                continue;
                            }
                            strList.Add(result);
                            count++;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Nothing was found!.");
            }
            return strList;
        }
    }
}