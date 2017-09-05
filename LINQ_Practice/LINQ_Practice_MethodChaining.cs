using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_MethodChaining
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
        public void GetAllCohortsWithZacharyZohanAsPrimaryOrJuniorInstructor()
        {
            var ActualCohorts = PracticeData.Where( c => (c.PrimaryInstructor.FirstName == "Zachary" 
                                                    && c.PrimaryInstructor.LastName == "Zohan") 
                                                    || c.JuniorInstructors
                                                        .Any(ji => ji.FirstName == "Zachary" 
                                                        && ji.LastName == "Zohan")
                                                   ).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort2, CohortBuilder.Cohort3 });
        }

        [TestMethod]
        public void GetAllCohortsWhereFullTimeIsFalseAndAllInstructorsAreActive()
        {
            var ActualCohorts = PracticeData.Where( c => (!c.FullTime) 
                                                    && (c.PrimaryInstructor.Active) 
                                                    && (c.JuniorInstructors.All(ji => ji.Active))
                                                  ).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1 });
        }

        [TestMethod]
        public void GetAllCohortsWhereAStudentOrInstructorFirstNameIsKate()
        {
            var ActualCohorts = PracticeData.Where(c => (c.PrimaryInstructor.FirstName == "Kate")
                                                   || (c.JuniorInstructors
                                                        .Any(ji => ji.FirstName == "Kate"))
                                                   || (c.Students
                                                        .Any(s => s.FirstName == "Kate"))
                                                  ).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1, CohortBuilder.Cohort3, CohortBuilder.Cohort4 });
        }

        [TestMethod]
        public void GetOldestStudent()
        {
            var student = PracticeData/*.Where(c => c.Students.Min(s => s.Birthday)) FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(student, CohortBuilder.Student18);
        }

        [TestMethod]
        public void GetYoungestStudent()
        {
            var student = PracticeData/*FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(student, CohortBuilder.Student3);
        }

        [TestMethod]
        public void GetAllInactiveStudentsByLastName()
        {
            var ActualStudents = PracticeData.Where(c => c.Students.All(s => s.Active == false))/*FILL IN LINQ EXPRESSION*/.ToList();
            CollectionAssert.AreEqual(ActualStudents, new List<Student> { CohortBuilder.Student2, CohortBuilder.Student11, CohortBuilder.Student12, CohortBuilder.Student17 });
        }
    }
}
