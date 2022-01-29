using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using FreeGamesConsume.Models;

namespace FreeGamesConsume.Utils
{
    public class MediaHelper
    {
        public string SaveMedia(string path, string media)
        {
            try {

            
                int index = media.IndexOf(",");

                media = media.Replace(media.Substring(0, index + 1), "");
                byte[] bytes = Convert.FromBase64String(media);

                string filePath;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    filePath = path + "/image_1.png";
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    FileInfo[] files = di.GetFiles();
                    int imageNum;
                    if (files.Length > 0)
                    {
                        FileInfo file = files[0];

                        var file_splitted = file.Name.Split('_');

                        if (file_splitted.Length > 1)
                        {
                            imageNum = Convert.ToInt32(file_splitted[1].Split('.')[0]);
                        }
                        else
                        {
                            imageNum = 0;
                        }

                        filePath = path + "/image_" + (imageNum + 1).ToString() + ".png";

                        file.Delete();
                    }
                    else
                    {
                        filePath = path + "/image_1.png";
                    }
                }

                using (FileStream stream = new System.IO.FileStream(filePath, FileMode.Create))
                {
                    Stream mstream = new MemoryStream(bytes);
                    mstream.CopyTo(stream);
                    stream.Close();
                }
                index = filePath.IndexOf("Upload");
                filePath = filePath.Substring(index);
                return filePath;
            }
            catch(Exception e) {
                return null;
            }
        }
    }
}