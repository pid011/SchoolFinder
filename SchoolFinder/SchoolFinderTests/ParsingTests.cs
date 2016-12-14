using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolFinder;
using System.Collections.Generic;
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
            var result = finder.SearchSchool(SchoolTypes.Middle, Regions.Gyeonggi, "¼¼Á¾");
            var infos = result;

            foreach (var item in infos)
            {
                Debug.WriteLine("Name: " + item.Name);
                Debug.WriteLine("Code: " + item.Code);
                Debug.WriteLine("----------------------------------");
            }
        }
    }
}
