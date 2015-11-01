using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoomNotes.Models.Content
{
    public class Annotation
    {
        public string ID { get; set; }
        
        public IAnnotatable Attached { get; set; }
        public string AnnotationContent { get; set; }

        public Annotation()
        {
            this.ID = System.Guid.NewGuid().ToString();
        }

    }
}