using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoomNotes.Models.Content
{
    public class Document : IAnnotatable
    {
        public string DocumentID {get; set;}

        public Document()
        {
            this.DocumentID = System.Guid.NewGuid().ToString();
        }

        public Document(string documentID)
        {
            this.DocumentID = documentID;
        }

        public string GetAnnotatableID()
        {
            return DocumentID;
        }
    }
}