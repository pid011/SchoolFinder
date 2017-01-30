using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolFinder;
using System.Diagnostics;

namespace SchoolFinderTests
{
    [TestClass]
    public class ParsingTests
    {
        [TestMethod]
        public void SchoolCodeParsingTestAsync()
        {
            SchoolSearch finder = new SchoolSearch();
            var result = finder.SearchSchool(SchoolTypes.Middle, Regions.Gyeonggi, "¿©");

            foreach (var item in result)
            {
                Debug.WriteLine("Name: " + item.Name);
                Debug.WriteLine("Adress: " + item.Adress);
                Debug.WriteLine("Code: " + item.Code);
                Debug.WriteLine("----------------------------------");
            }
        }
    }
}
