using NoomNotes.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoomNotes.Models
{
    public class AnnotationManager
    {
        private List<Annotation> loadedAnnotations = null;

        public AnnotationManager()
        {
            this.loadedAnnotations = new List<Annotation>();
        }

        public AnnotationManager(Annotation[] annotations)
        {
            this.loadedAnnotations = new List<Annotation>();
            this.loadedAnnotations.AddRange(annotations);
        }

        public AnnotationManager(List<Annotation> AnnotationList)
        {
            this.loadedAnnotations = AnnotationList;
        }

        public bool TryGetAnnotationAt(int index, out Annotation annotation)
        {
            if (loadedAnnotations.Count > index)
            {
                annotation = this.loadedAnnotations.ElementAt<Annotation>(index);
                return true;
            }
            annotation = null;
            return false;
        }

        public Annotation[] GetAllAnnotations()
        {
            return loadedAnnotations.ToArray<Annotation>();
        }

        public void AddAnnotation(Annotation newAnnotation) 
        {
            if (newAnnotation == null)
                throw new ModelException("Unable to add null annotation.");
            this.loadedAnnotations.Add(newAnnotation);
        }

        public void AddAnnotations(Annotation[] annotations)
        {
            if (annotations == null)
                throw new ModelException("Unable to add null annotations.");
            this.loadedAnnotations.AddRange(annotations);
        }
    }
}