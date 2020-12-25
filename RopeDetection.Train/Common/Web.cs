﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RopeDetection.Train.Common
{
    public class Web
    {
        public static bool Download(string url, string destDir, string destFileName)
        {
            if (destFileName == null)
                destFileName = url.Split(Path.DirectorySeparatorChar).Last();

            Directory.CreateDirectory(destDir);

            string relativeFilePath = Path.Combine(destDir, destFileName);

            if (File.Exists(relativeFilePath))
            {
                Console.WriteLine($"{relativeFilePath} already exists.");
                return false;
            }

            var wc = new WebClient();
            Console.WriteLine($"Downloading {relativeFilePath}");
            var download = Task.Run(() => wc.DownloadFile(url, relativeFilePath));
            while (!download.IsCompleted)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine("");
            Console.WriteLine($"Downloaded {relativeFilePath}");

            return true;
        }

        private static async Task<bool> UploadFile()
        {
            //if (ufile != null && ufile.Length > 0)
            //{
            //    var fileName = Path.GetFileName(ufile.FileName);
            //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await ufile.CopyToAsync(fileStream);
            //    }
            //    return true;
            //}
            return false;
        }
    }
}
