using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_Any
    {
        public List<Cohort> PracticeData { get; set; }
        public CohortBuilder CohortBuilder { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            CohortBuilder = new CohortBuilder();
            PracticeData = CohortBuilder.GenerateCohorts();
        }

        [TestCleanup]
        public void TearDown()
        {
            CohortBuilder = null;
            PracticeData = null;
        }


        [TestMethod]
        public void DoAnyCohortsHavePrimaryInstructorsBornIn1980s()
        {
            var doAny = PracticeData.Any(i => i.PrimaryInstructor.Birthday.Year > 1979 && i.PrimaryInstructor.Birthday.Year < 1990)/*FILL IN LINQ EXPRESSION*/;
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void DoAnyCohortsHaveActivePrimaryInstructors()
        {
            var doAny = PracticeData.Any(i => i.PrimaryInstructor.Active == true)/*FILL IN LINQ EXPRESSION*/;
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void DoAnyActiveCohortsHave3JuniorInstructors()
        {
            var doAny = PracticeData.Any(c => c.JuniorInstructors.Count() > 2)/*FILL IN LINQ EXPRESSION*/;
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void AreAnyCohortsBothFullTimeAndNotActive()
        {
            var doAny = PracticeData.Any( c => c.Active == false && c.FullTime == true)/*FILL IN LINQ EXPRESSION*/;
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void AreAnyStudentsInCohort3NotActiveAndBornInOctober()
        {
            var cohort3 = PracticeData.First(c => c.Name == "Evening Ninja Warriors");
            bool doAny = cohort3.Students.Any(s => s.Active == false && s.Birthday.Month == 10 )
            /*FILL IN LINQ EXPRESSION*/;  //HINT: Cohort3 is PracticeData[2]
            Assert.IsFalse(doAny); //<-- change true to doAny
        }

        [TestMethod]
        public void AreAnyJuniorInstructorsInCohort4NotActive()
        {
            var cohort4 = PracticeData.First(c => c.Name == "Day Backgammon Geeks");
            var doAny = cohort4.JuniorInstructors.Any(ji => ji.Active == false)/*FILL IN LINQ EXPRESSION*/;  //HINT: Cohort4 is PracticeData[3]
            Assert.IsFalse(doAny); //<-- change true to doAny
        }
    }
}
