using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_First
    {
        /*
        * IMPORTANT NOTE:
        * This Test Class covers .First() 
        * which throws an exception if there is not an item that matches the condition
        * and returns the first occurance of an item that matches the condition if there is one
        * And .FirstOrDefault()
        * which returns null if there is not an item that matches condition
        * but still returns the first occurance of an item that matched the condition if there 
        * is one
       */
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
        public void GetFirstCohortWherePrimaryInstructorIsKate()
        {
            var ActualCohort = PracticeData.First(c => c.PrimaryInstructor.FirstName == "Kate")/*FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(ActualCohort, CohortBuilder.Cohort4);
        }


        [TestMethod]
        public void GetFirstCohortWithThreeJuniorInstructors()
        {
            var ActualCohort = PracticeData.First(c => c.JuniorInstructors.Count() == 3)/*FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(ActualCohort, CohortBuilder.Cohort3);
        }

        [TestMethod]
        public void GetFirstCohortThatIsFullTimeAndPrimaryInstructorBirthdayInTheFuture()
        {
            var ActualCohort = PracticeData.First(c => c.FullTime = true && c.PrimaryInstructor.Birthday.Year > 2017)/*FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(ActualCohort, CohortBuilder.Cohort2);
        }

        [TestMethod]
        public void GetFirstCohortWithInstructorNamedZeldaOrNull()
        {
            var cohort1 = PracticeData.First(c => c.Name == "Evening Five");
            var cohort2 = PracticeData.First(c => c.Name == "Cohort of the Future");
            var cohort3 = PracticeData.First(c => c.Name == "Evening Ninja Warriors");
            var cohort4 = PracticeData.First(c => c.Name == "Day Backgammon Geeks");
            var ActualCohort1 = cohort1.JuniorInstructors.FirstOrDefault(i => i.FirstName == "Zelda");
            var ActualCohort2 = cohort2.JuniorInstructors.FirstOrDefault(i => i.FirstName == "Zelda");
            var ActualCohort3 = cohort3.JuniorInstructors.FirstOrDefault(i => i.FirstName == "Zelda");
            var ActualCohort4 = cohort4.JuniorInstructors.FirstOrDefault(i => i.FirstName == "Zelda");
            var ActualCohort = PracticeData.FirstOrDefault(c => c.PrimaryInstructor.FirstName == "Zelda")/*FILL IN LINQ EXPRESSION*/;
            Assert.IsNull(ActualCohort);
            Assert.IsNull(ActualCohort1);
            Assert.IsNull(ActualCohort2);
            Assert.IsNull(ActualCohort3);
            Assert.IsNull(ActualCohort4);

        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void GetFirstCohortThatIsBothNotActiveAndNotFullTimeOrThrowException()
        {
            var shouldThrowException = PracticeData.First(c => c.Active == false && c.FullTime == false)/*FILL IN LINQ EXPRESSION*/;
        }

        [TestMethod]
        public void GetFirstCohortWith2JuniorInstructors()
        {
            var ActualCohort = PracticeData.First(c => c.JuniorInstructors.Count() == 2)/*FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(ActualCohort, CohortBuilder.Cohort1);
        }


    }
}
