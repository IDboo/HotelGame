using Microsoft.AspNetCore.Http;

public interface IFileHelper
{
    void DeleteFile(string imageUrl);
    string UploadFile(IFormFile file);

}
