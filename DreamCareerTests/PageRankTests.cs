using Microsoft.VisualStudio.TestTools.UnitTesting;
using DreamCareer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCareer.Tests
{
    [TestClass()]
    public class PageRankTests
    {
        [TestMethod()]
        public void RankProfilesTest()
        {
            PageRank.RankProfiles(10);

            /*
            double OneNorm = v.OneNorm();
            Assert.IsTrue(Math.Abs(OneNorm - 1) < 0.00000001);

            int i;
            for (i = 0; i < v.Rows; i++)
            {
                Assert.IsTrue(v.GetValue(i) >= 0);
                Assert.IsTrue(v.GetValue(i) < 1);
            }
            */
        }

    }
}