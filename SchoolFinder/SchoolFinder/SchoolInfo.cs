using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinder
{
    /// <summary>
    /// 학교 정보에 대한 속성들을 제공합니다.
    /// </summary>
    public class SchoolInfo
    {
        /// <summary>
        /// 학교의 이름을 제공합니다.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 학교의 주소를 제공합니다.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// 학교의 고유코드를 제공합니다.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 학교의 관할지역을 제공합니다.
        /// </summary>
        public Regions Region { get; set; }

        /// <summary>
        /// 학교의 종류를 제공합니다.
        /// </summary>
        public SchoolTypes SchoolType { get; set; }
    }
}
