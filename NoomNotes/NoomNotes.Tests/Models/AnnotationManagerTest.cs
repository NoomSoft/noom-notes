using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoomNotes.Models;
using NoomNotes.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoomNotes.Tests.Models
{
    [TestClass()]
    public class AnnotationManagerTest
    {
        private AnnotationManager annotationManager = null;
        private List<Annotation> testAnnotationList = null;

        [TestInitialize()]
        public void Initialize()
        {
            this.testAnnotationList = new List<Annotation>();
            this.annotationManager = new AnnotationManager(testAnnotationList);
        }

        [TestMethod()]
        public void TestAddAnnotation()
        {
            Annotation anno1 = new Annotation();
            Annotation anno2 = new Annotation();

            this.annotationManager.AddAnnotation(anno1);
            this.annotationManager.AddAnnotation(anno2);

            Assert.IsTrue(testAnnotationList.Contains(anno1), "List does not contain expected annotation.");
            Assert.IsTrue(testAnnotationList.Contains(anno2), "List does not contain expected annotation.");

        }

        [TestMethod()]
        [ExpectedException(typeof(ModelException))]
        public void TestAddAnnotation___NullValue_ThrowException()
        {
            this.annotationManager.AddAnnotation(null);
        }

        [TestMethod()]
        public void TestTryGetAnnotationAt()
        {
            Annotation anno1 = new Annotation();
            Annotation anno2 = new Annotation();
            Annotation anno3 = new Annotation();
            
            this.annotationManager.AddAnnotations(new Annotation[]{anno1, anno2, anno3});

            Annotation result1;
            bool returnResult1 = this.annotationManager.TryGetAnnotationAt(0, out result1);
            Annotation result2;
            bool returnResult2 = this.annotationManager.TryGetAnnotationAt(2, out result2);

            Assert.AreSame(anno1, result1, "Returned object should be same as expected.");
            Assert.AreSame(anno3, result2, "Returned object should be same as expected.");
            Assert.IsTrue(returnResult1, "Should have returned as true.");
            Assert.IsTrue(returnResult2, "Should have returned as true.");
        }

        [TestMethod()]
        public void TestTryGetAnnotationAt___OutOfIndex_ReturnFalse()
        {
            Annotation anno1 = new Annotation();
            Annotation anno2 = new Annotation();
            Annotation anno3 = new Annotation();

            this.annotationManager.AddAnnotations(new Annotation[] { anno1, anno2, anno3 });

            Annotation result1;
            bool returnResult1 = this.annotationManager.TryGetAnnotationAt(4, out result1);

            Assert.IsFalse(returnResult1, "Should have returned as false.");
        }

        [TestMethod()]
        public void TestGetAllAnnotations()
        {
            Annotation anno1 = new Annotation();
            Annotation anno2 = new Annotation();
            Annotation anno3 = new Annotation();
            Annotation[] expectedAnnotations = new Annotation[] { anno1, anno2, anno3 };

            this.annotationManager.AddAnnotations(expectedAnnotations);

            Annotation[] resultAnnotations = this.annotationManager.GetAllAnnotations();

            Assert.IsTrue(resultAnnotations.SequenceEqual(expectedAnnotations), "Returned annotations should be the same.");
        }
    }
}
