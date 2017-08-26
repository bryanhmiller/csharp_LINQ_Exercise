using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_All
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
        public void DoAllCohortsHaveTwoOrMoreJuniorInstructors()
        {
            bool doAll = PracticeData.All(c => c.JuniorInstructors.Count() >= 2)/*FILL IN LINQ EXPRESSION*/;
            Assert.IsTrue(doAll); //<-- change false to doAll
        }

        [TestMethod]
        public void DoAllCohortsHaveFiveOrMoreStudents()
        {
            bool doAll = PracticeData.All(c => c.Students.Count() >= 5)/*FILL IN LINQ EXPRESSION*/;
            Assert.IsTrue(doAll); //<-- change false to doAll
        }

        [TestMethod]
        public void DoAllCohortsHavePrimaryInstructorsBornIn1980s()
        {
            var doAll = PracticeData.All(i => i.PrimaryInstructor.Birthday.Year > 1979 && i.PrimaryInstructor.Birthday.Year < 1990 )/*FILL IN LINQ EXPRESSION*/;
            Assert.IsFalse(doAll); //<-- change true to doAll
        }

        [TestMethod]
        public void DoAllCohortsHaveActivePrimaryInstructors()
        {
            var doAll = PracticeData.All(i => i.PrimaryInstructor.Active == true )/*FILL IN LINQ EXPRESSION*/;
            Assert.IsTrue(doAll); //<-- change true to doAll
        }

        [TestMethod]
        public void DoAllStudentsInCohort1HaveFirstNamesThatContainTheLetterE()
        {
            var cohort1 = PracticeData.First(c => c.Name == "Evening Five");
            var doAll = cohort1.Students.All(s => s.FirstName.Contains("e"))
                /*FILL IN LINQ EXPRESSION*/; //Hint: Cohort1 would be PracticeData[0]
            Assert.IsTrue(doAll); //<-- change false to doAll
        }

        [TestMethod]
        public void DoAllActiveCohortsHavePrimaryInstructorsWithFirstNamesThatContainTheLetterA()
        {
            var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/;
            Assert.IsFalse(false); //<-- change false to doAll
        }
    }
}
