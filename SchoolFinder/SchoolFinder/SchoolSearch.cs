using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinder
{
    /// <summary>
    /// 학교검색을 위한 함수와 그 결과로 나오는 속성을 제공합니다.
    /// </summary>
    public class SchoolSearch
    {
        /// <summary>
        /// 매개변수로 받은 검색단어로 학교를 검색하여 검색어와 유사한 학교들을 리턴합니다.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="region">검색할 학교의 관할지역</param>
        /// <param name="searchWord"></param>
        /// <returns>검색결과</returns>
        public List<SchoolInfo> SearchSchool(SchoolTypes type, Regions region, string searchWord)
        {
            var infos = new FindSchool().SearchSchoolInfo(type, region, searchWord);
            var codes = new FindSchoolCode().SearchSchoolCode(region, searchWord);

            foreach (var item in infos)
            {
                item.Code = codes.Find(x => x.Name == item.Name).Code;
            }
            infos.RemoveAll(x => x.Code == null);

            return infos;
        }
    }

    /// <summary>
    /// 검색할 학교의 종류를 열거합니다.
    /// </summary>
    public enum SchoolTypes
    {
        /// <summary>
        /// 초등학교
        /// </summary>
        Elementary,
        /// <summary>
        /// 중학교
        /// </summary>
        Middle,
        /// <summary>
        /// 고등학교
        /// </summary>
        High

    }

    /// <summary>
    /// 검색할 학교의 관할지역을 열거합니다.
    /// </summary>
    public enum Regions
    {
        /// <summary>
        /// 서울특별시
        /// </summary>
        Seoul,
        /// <summary>
        /// 인천광역시
        /// </summary>
        Incheon,
        /// <summary>
        /// 부산광역시
        /// </summary>
        Busan,
        /// <summary>
        /// 광주광역시
        /// </summary>
        Gwangju,
        /// <summary>
        /// 대전광역시
        /// </summary>
        Daejeon,
        /// <summary>
        /// 대구광역시
        /// </summary>
        Daegu,
        /// <summary>
        /// 세종특별자치시
        /// </summary>
        Sejong,
        /// <summary>
        /// 울산광역시
        /// </summary>
        Ulsan,
        /// <summary>
        /// 경기도
        /// </summary>
        Gyeonggi,
        /// <summary>
        /// 강원도
        /// </summary>
        Kangwon,
        /// <summary>
        /// 충청북도
        /// </summary>
        Chungbuk,
        /// <summary>
        /// 충청남도
        /// </summary>
        Chungnam,
        /// <summary>
        /// 경상북도
        /// </summary>
        Gyeongbuk,
        /// <summary>
        /// 경상남도
        /// </summary>
        Gyeongnam,
        /// <summary>
        /// 전라북도
        /// </summary>
        Jeonbuk,
        /// <summary>
        /// 전라남도
        /// </summary>
        Jeonnam,
        /// <summary>
        /// 제주특별자치도
        /// </summary>
        Jeju
    }
}
