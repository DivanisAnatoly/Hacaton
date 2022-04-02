using Microsoft.AspNetCore.Http;
using NuretaNeko.AppModel.Services.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Services.Services.Storage
{
    public class StorageService : IStorageService
    {
        readonly ICloudStorageService _cloudStorageService;

        public StorageService(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;

        }

        public async Task<string?> GetPhotoURL(string fileName, CancellationToken cancellationToken)
        {
            bool found = await _cloudStorageService.CheckBucket("hacaton", cancellationToken);
            if (!found) return null;

            return await _cloudStorageService.GetFileURL(fileName, cancellationToken);
        }

        public async Task<string?> SaveCandidatePhoto(IFormFile photo, CancellationToken cancellationToken)
        {
            bool found = await _cloudStorageService.CheckBucket("hacaton", cancellationToken);
            if (!found) await _cloudStorageService.CreateBucket("hacaton", cancellationToken);

            string fileName = $"candidate_{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";
            var status = await _cloudStorageService.UploadFile(photo, fileName, "candidates/", cancellationToken);

            if (status == System.Net.HttpStatusCode.OK) return fileName;
            return null;
        }

    }
}
