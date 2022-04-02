using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Storage
{
    public interface IStorageService
    {
        Task<string?> SaveCandidatePhoto(IFormFile photo, CancellationToken cancellationToken);
        Task<string?> GetPhotoURL(string fileName, CancellationToken cancellationToken);
    }
}
