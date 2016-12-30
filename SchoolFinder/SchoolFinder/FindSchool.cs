using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SchoolFinder
{
    [Serializable]
    internal class FindSchool
    {
        // [ NOTICE ] apiKey는 SchoolFinder만의 API 키입니다. 부디 다른 용도로 사용하지 말아주세요. ㅠㅠ
        const string defaultUrl = "http://www.career.go.kr/cnet/openapi/getOpenApi?apiKey=c64eb70b0ff5578f6f20f9af89e1bb52&svcType=api&svcCode=SCHOOL&contentType=json";
        
        public List<SchoolInfo> SearchSchoolInfo(SchoolTypes type, Regions region, string searchWord)
        {
            var url = defaultUrl;
            url += "&gubun=" + SchoolTypesToString(type);
            url += "&region=" + RegionsToString(region);
            url += "&searchSchulNm=" + searchWord;

            var json = Util.GetJsonFromUrl(url);
            var result = SchoolJsonParser(json);

            result.ForEach(x => { x.Region = region; x.SchoolType = type; });

            return result;
        }

        private List<SchoolInfo> SchoolJsonParser(string json)
        {
            JObject obj = JObject.Parse(json);
            JArray arr = (JArray)obj["dataSearch"]["content"];

            List<SchoolInfo> infos = arr.Select(p => new SchoolInfo
            {
                Name = (string)p["schoolName"],
                Adress = (string)p["adres"]
            }).ToList();

            return infos;
        }

        private string SchoolTypesToString(SchoolTypes type)
        {
            string result = string.Empty;
            switch (type)
            {
                case SchoolTypes.Elementary:
                    result = "elem_list";
                    break;
                case SchoolTypes.Middle:
                    result = "midd_list";
                    break;
                case SchoolTypes.High:
                    result = "high_list";
                    break;
                default:
                    break;
            }

            return result;
        }

        private string RegionsToString(Regions region)
        {
            string result = string.Empty;
            switch (region)
            {
                case Regions.Seoul:
                    result = "100260";
                    break;
                case Regions.Incheon:
                    result = "100269";
                    break;
                case Regions.Busan:
                    result = "100267";
                    break;
                case Regions.Gwangju:
                    result = "100275";
                    break;
                case Regions.Daejeon:
                    result = "100271";
                    break;
                case Regions.Daegu:
                    result = "100272";
                    break;
                case Regions.Sejong:
                    result = "100704";
                    break;
                case Regions.Ulsan:
                    result = "100273";
                    break;
                case Regions.Gyeonggi:
                    result = "100276";
                    break;
                case Regions.Kangwon:
                    result = "100278";
                    break;
                case Regions.Chungbuk:
                    result = "100280";
                    break;
                case Regions.Chungnam:
                    result = "100281";
                    break;
                case Regions.Gyeongbuk:
                    result = "100285";
                    break;
                case Regions.Gyeongnam:
                    result = "100291";
                    break;
                case Regions.Jeonbuk:
                    result = "100282";
                    break;
                case Regions.Jeonnam:
                    result = "100283";
                    break;
                case Regions.Jeju:
                    result = "100292";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
