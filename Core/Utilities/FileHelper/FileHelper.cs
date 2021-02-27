using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Core.Utilities.Results;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public  static string AddAsnyc(IFormFile file)
        {
            var result = newPath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length>0)
                {
                    using (var fileStream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    File.Move(sourcePath, result.newPath);
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return result.Path2;
        }
        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = newPath(file);

            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Delete(sourcePath);
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

            return result.Path2;
        }

        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString()
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;

          

            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{creatingUniqueFilename}";

            return (result, $"\\Images\\{creatingUniqueFilename}");
        }

    }
}
