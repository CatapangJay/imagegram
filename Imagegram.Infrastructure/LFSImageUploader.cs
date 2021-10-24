using Imagegram.Application.Contracts.Infrastructure;
using Imagegram.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Infrastructure
{
    /// <summary>
    /// Provides implementaion for uploading image to the local file system (LFS)
    /// </summary>
    public class LFSImageUploader : IImageUploader
    {
        public async Task<string> UploadImage(ImageFileDetail fileDetail)
        {
            // Temporarily save to local directory
            string destinationPath = Directory.GetCurrentDirectory() + "\\uploaded_files";
            string fullFileName = $"{destinationPath}\\{fileDetail.FileName}";
            Directory.CreateDirectory(destinationPath);

            using var fileStream = new FileStream(fullFileName, FileMode.Create, FileAccess.Write);

            await fileDetail.FileStream.CopyToAsync(fileStream);

            return fullFileName;
        }
    }
}
