using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;
using NuretaNeko.AppModel.Services.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Services.Services.Storage
{
    public class CloudStorageService : ICloudStorageService
    {
        private readonly IAmazonS3 _client;


        private static readonly string _bucket = "hacaton";

        public CloudStorageService(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task<bool> CheckBucket(string name, CancellationToken cancellationToken)
        {

            return await _client.DoesS3BucketExistAsync(name);
        }


        public async Task CreateBucket(string name, CancellationToken cancellationToken)
        {
            try
            {
                bool found = await _client.DoesS3BucketExistAsync(name);
                if (!found)
                {
                    await _client.PutBucketAsync(name, cancellationToken);
                    Console.WriteLine("mybucket is created successfully");
                }
            }
            catch (MinioException e)
            {
                Console.WriteLine("Error occurred: " + e);
            }
        }


        public async Task<string?> GetFileURL(string fileName, CancellationToken cancellationToken)
        {
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
            {
                BucketName = _bucket,
                Key = fileName,
                Expires = DateTime.Now.AddDays(1)
            };

            return _client.GetPreSignedURL(request);
        }


        public async Task<HttpStatusCode> UploadFile(IFormFile file, string fileName, string path, CancellationToken cancellationToken)
        {
            MemoryStream fileStream = new();
            file.CopyTo(fileStream);
            fileStream.Position = 0;


            PutObjectRequest request = new()
            {
                BucketName = _bucket,
                Key = fileName,
                InputStream = fileStream
            };

            var response = await _client.PutObjectAsync(request);
            return response.HttpStatusCode;
        }
    }
}
