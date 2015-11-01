using NoomNotes.Models;
using NoomNotes.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoomNotes.Controllers
{
    public class AnnotationsController : ApiController
    {
        private AnnotationManager annotationManager = null; 

        public AnnotationsController()
        {
            //TODO Remove - this was just to test output when hitting API
            Annotation a = new Annotation();
            annotationManager = new AnnotationManager();
            annotationManager.AddAnnotation(a);
        }
        
        // api/annotations
        public Annotation[] Get()
        {
            return annotationManager.GetAllAnnotations();
        }
    }
}
