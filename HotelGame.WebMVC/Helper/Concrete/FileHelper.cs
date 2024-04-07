using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

public class FileHelper : IFileHelper
{
    //IWebHostEnvironment interface bizim için dosya alıp verme işlemleri gerçeklestirmektedir. bu interface sadece .core tarafında mevcuttur klasik .net frameworkta yoktur...
    private IWebHostEnvironment _env;

    public FileHelper(IWebHostEnvironment env)
    {
        _env = env;
    }
    private string GenerateFileName(string fileName)
    {
        string[] strName = fileName.Split('.');
        string strFileName = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THmmssfff") + "." + strName[strName.Length - 1];
        return strFileName;
    }

    public void DeleteFile(string imageUrl)
    {
        //delete
        if (File.Exists(_env.WebRootPath + imageUrl))
        {
            File.Delete(_env.WebRootPath + imageUrl);
        }
    }

    public string UploadFile(IFormFile file)
    {
        var uploads = Path.Combine(_env.WebRootPath);
        bool exists = Directory.Exists(uploads);
        if (!exists)
            Directory.CreateDirectory(uploads);

        var fileName = GenerateFileName(file.FileName);
        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/uploadImage/", fileName);
        var fileStream = new FileStream(location, FileMode.Create);
        file.CopyToAsync(fileStream);
        return "/img/uploadImage/" + fileName;

    }
}
