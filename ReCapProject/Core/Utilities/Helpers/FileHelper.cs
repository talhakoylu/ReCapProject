using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        //old codes will be refactoring.
        //public static string Add(IFormFile file)
        //{
        //    var sourcepath = Path.GetTempFileName();
        //    if (file.Length > 0)
        //    {
        //        using (var stream = new FileStream(sourcepath, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //    }
        //    var result = NewPath(file).Replace("\\","/");
        //    File.Move(sourcepath, result);
        //    return result;
        //}
        //public static IResult Delete(string path)
        //{
        //    try
        //    {
        //        File.Delete(path);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorResult(exception.Message);
        //    }

        //    return new SuccessResult();
        //}
        //public static string Update(string sourcePath, IFormFile file)
        //{
        //    var result = NewPath(file);
        //    if (sourcePath.Length > 0)
        //    {+
        //        using (var stream = new FileStream(result, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //    }
        //    File.Delete(sourcePath);
        //    return result;
        //}
        //public static string NewPath(IFormFile file)
        //{
        //    FileInfo ff = new FileInfo(file.FileName);
        //    string fileExtension = ff.Extension;

        //    string path = Directory.GetCurrentDirectory() + @"\wwwroot\uploads\images";
        //    var newPath = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "-" + Guid.NewGuid().ToString()+ fileExtension;

        //    string result = $@"{path}\{newPath}";
        //    return result;
        //}

        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\uploads\";
        static string path = @"images\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFileName = Guid.NewGuid().ToString("N") + extension;
            if (!Directory.Exists(directory + path))
            {
                Directory.CreateDirectory(directory + path);
            }
            using (FileStream fileStream = File.Create(directory + path + newFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (path + newFileName).Replace("\\", "/");
        }

        public static string Update(IFormFile file, string OldImagePath)
        {
            Delete(OldImagePath);
            return Add(file);
        }

        public static void Delete(string ImagePath)
        {
            if (File.Exists(directory + ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "default.png")
            {
                File.Delete(directory + ImagePath.Replace("/", "\\"));
            }
        }


    }
}
