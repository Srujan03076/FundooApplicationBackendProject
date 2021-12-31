using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ResponseModel
{
    class NotesResponse
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Remainder { get; set; }
        public string Colour { get; set; }
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }
        public long Id { get; set; }
    }
}
