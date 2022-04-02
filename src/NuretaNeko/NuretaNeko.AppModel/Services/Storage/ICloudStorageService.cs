using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Storage
{
    public interface ICloudStorageService
    {
        Task CreateBucket(string name, CancellationToken cancellationToken);

        Task<HttpStatusCode> UploadFile(IFormFile file, string fileName, string path, CancellationToken cancellationToken);

        Task<string?> GetFileURL(string fileName, CancellationToken cancellationToken);

        Task<bool> CheckBucket(string name, CancellationToken cancellationToken);
    }
}
