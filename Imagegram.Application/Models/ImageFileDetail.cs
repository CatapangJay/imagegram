using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Imagegram.Application.Models
{
    public class ImageFileDetail
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string SourceIp { get; set; }
        public Stream FileStream { get; set; }
    }
}
