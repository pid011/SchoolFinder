using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace SchoolFinder
{
    internal class FindSchoolCode
    {
        public List<SchoolCodeInfo> SearchSchoolCode(Regions region, string searchWord)
        {
            string url = RegionsToUrl(region) + searchWord;
            string json = Util.GetJsonFromUrl(url);
            var result = SchoolCodeJsonParser(json);

            return result;
        }

        private List<SchoolCodeInfo> SchoolCodeJsonParser(string json)
        {
            JObject obj = JObject.Parse(json);
            JArray arr = (JArray)obj["resultSVO"]["data"]["orgDVOList"];
            List<SchoolCodeInfo> codes = arr.Select(p => new SchoolCodeInfo
            {
                Name = (string)p["kraOrgNm"],
                Code = (string)p["orgCode"]
            }).ToList();

            return codes;
        }

        private string RegionsToUrl(Regions region)
        {
            string url = string.Empty;
            switch (region)
            {
                case Regions.Seoul:
                    url = "http://par.sen.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Incheon:
                    url = "http://par.ice.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Busan:
                    url = "http://par.pen.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Gwangju:
                    url = "http://par.gen.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Daejeon:
                    url = "http://par.dje.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Daegu:
                    url = "http://par.dge.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Sejong:
                    url = "http://par.sje.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Ulsan:
                    url = "http://par.use.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Gyeonggi:
                    url = "http://par.goe.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Kangwon:
                    url = "http://par.kwe.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Chungbuk:
                    url = "http://par.cbe.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Chungnam:
                    url = "http://par.cne.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Gyeongbuk:
                    url = "http://par.gbe.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Gyeongnam:
                    url = "http://par.gne.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Jeonbuk:
                    url = "http://par.jbe.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Jeonnam:
                    url = "http://par.jne.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                case Regions.Jeju:
                    url = "http://par.jje.go.kr/spr_ccm_cm01_100.do?kraOrgNm=";
                    break;
                default:
                    break;
            }

            return url;
        }

    }

    internal class SchoolCodeInfo
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
