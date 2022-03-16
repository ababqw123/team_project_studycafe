using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _220309_RegexHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("url를 찾고 싶은 문자열을 입력하십시오.");
            string inputURL = Console.ReadLine();
            string resultURL = GetUrl(inputURL);


            if (resultURL.Length == 0)
            {
                Console.WriteLine("해당 문자열 내 URL 패턴이 없습니다.");
            }
            else
            {
                Console.WriteLine(resultURL);
            }
            string GetUrl(string input)
            {
                Regex r;
                Match m;
                //프로토콜부분 - 있을수도 없을수도
                string ptProtocol = "(?:(ftp|https?|mailto|telnet):\\/\\/)?";
                //domain의 기본 골격은 daum.net
                string domain = @"[a-zA-Z]\w+\.[a-zA-Z]\w+(\.\w+)?(\.\w+)?";
                //도메인 뒤에 추가로 붙는 서브url 및 파라미터들
                string adds = "([:?=&/%.-]+\\w+)*";
                //string adds2 = "(.+?)?\\s";
                string result = "";

                r = new Regex(ptProtocol + domain + adds, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                m = r.Match(inputURL);
                while (m.Success)
                {
                    result += "URL=[" + m.Value + "]" + Environment.NewLine;
                    m = m.NextMatch();
                }
                return result;
            }
        }
        
    }
}
