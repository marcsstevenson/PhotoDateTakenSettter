using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.Processing;

namespace PhotoDateTakenSettter.Console
{
    class Program
    {
        const string dateTimeFormat = "yyyy:MM:dd HH:mm:ss";

        static void Main(string[] args)
        {
            var startingDate = new DateTime(1994, 4, 28);
            var runningDate = startingDate;
            var timeSpanBetweenPhotos = new TimeSpan(days: 25, hours: 0, minutes: 0, seconds: 0);
            var targetDirectory = "D:\\Photos\\Vol 00 - Albums\\Album 4";

            // Get all files in targetDirectory
            var directoryInfo = new DirectoryInfo(targetDirectory);
            var files = directoryInfo.GetFiles();

            foreach (var imageInfo in files)
            {
                SetDateTaken(imageInfo, runningDate);
                runningDate = runningDate.Add(timeSpanBetweenPhotos);
            }
        }

        private static void SetDateTaken(FileInfo fileInfo, DateTime dateTimeOriginal)
        {
            using (Image image = Image.Load(fileInfo.FullName))
            {
                // Set the DateTimeOriginal EXIF value on the file
                var dateTimeOriginalString = dateTimeOriginal.ToString(dateTimeFormat);

                if (image.Metadata.ExifProfile == null)
                    image.Metadata.ExifProfile = new ExifProfile();

                image.Metadata.ExifProfile.SetValue(ExifTag.DateTimeOriginal, dateTimeOriginalString);

                image.Save(fileInfo.FullName);
            }
        }
    }
}
