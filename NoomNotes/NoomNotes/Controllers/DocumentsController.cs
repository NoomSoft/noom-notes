using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoomNotes.Models.Content
{
    public class DocumentsController : ApiController
    {
        public DocumentsController()
        {

        }

        // api/annotations/id
        public Document Get(string id)
        {
            return new Document(id);
        }
    }
}
