using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public static class ImageHelper
    {
        
        
        private static string _appRoot => Directory.GetCurrentDirectory();
        private static string _webRoot => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private static string _imageDirectory => "images";

        private static string _imageFullDirectory => Path.Combine(_appRoot,_webRoot,_imageDirectory);

        /// <summary>
        /// Adds image file to default image directory with unique image name.
        /// </summary>
        /// <param name="image">Image to add to default directory</param>
        /// <returns>Unique file name which in the default directory</returns>
        public static IDataResult<string> AddImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName).ToLower();

            var uniqueImageName = String.Concat(Guid.NewGuid().ToString(), extension);

            if (!Directory.Exists(_imageFullDirectory))
            {
                Directory.CreateDirectory(_imageFullDirectory);
            }

            var imageFullPath = Path.Combine(_imageFullDirectory, uniqueImageName);
            using (FileStream fileStream = File.Create(imageFullPath))
            {
                image.CopyTo(fileStream);
                fileStream.Flush();
            }

            return new SuccessDataResult<string>(uniqueImageName);

        }

        public static IResult Delete(string imageName)
        {
            if (!File.Exists(Path.Combine(_imageFullDirectory,imageName)))
            {
                return new ErrorResult("Image Not Found");
            }

            File.Delete(Path.Combine(_imageFullDirectory, imageName));
            return new SuccessResult("Image Deleted");
        }

        /// <summary>
        /// Updates image at default directory and file name at the database
        /// </summary>
        /// <param name="image">New image to replace old image</param>
        /// <param name="oldImageName">Old image file name which will be deleted from image directory</param>
        /// <returns></returns>
        public static IDataResult<string> Update(IFormFile image, string oldImageName)
        {
            var oldImageFullPath = Path.Combine(_imageFullDirectory, oldImageName);

            if (!File.Exists(oldImageFullPath))
            {
                return new ErrorDataResult<string>("Image Not Found");
            }

            Delete(oldImageFullPath);

            var result = AddImage(image);
            if (!result.IsSuccess)
            {
                return new ErrorDataResult<string>("New Image Could Not Added");
            }

            var newImageName = result.Data;
            return new SuccessDataResult<string>(newImageName);

        }

        public static string GetImageRelativePath(string fileName) => Path.Combine(_imageDirectory, fileName).Replace("\\","/");

    }
}
