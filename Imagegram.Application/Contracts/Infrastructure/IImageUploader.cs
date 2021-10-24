using Imagegram.Application.DTOs;
using Imagegram.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Contracts.Infrastructure
{
    public interface IImageUploader
    {
        /// <summary>
        /// Uploads image to the inheriting classes' storage system.
        /// </summary>
        /// <returns>The path in which the file was uploaded to.</returns>
        public Task<string> UploadImage(ImageFileDetail fileDetail);
    }
}
