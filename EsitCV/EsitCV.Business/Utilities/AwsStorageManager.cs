using EsitCV.Business.AbstractUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using EsitCV.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;

namespace EsitCV.Business.Utilities
{
    public  class AwsStorageManager : IAwsStorageService
    {
        private readonly AmazonS3Client amazonS3Client;


        public AwsStorageManager(IConfiguration config)
        {
            string accessKey = config["AwsConfiguration:AWSAccessKey"];
            string secretKey = config["AwsConfiguration:AWSSecretKey"];

            //var cred = new AwsCredentials()
            //{
            //    AwsKey = _config["AwsConfiguration:AWSAccessKey"],
            //    AwsSecretKey = _config["AwsConfiguration:AWSSecretKey"]
            //};
            // Adding AWS credentials
            var credentials = new BasicAWSCredentials(accessKey, secretKey);

            // Specify the region
            var amazonConfig = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUWest1
            };

            amazonS3Client = new AmazonS3Client(credentials, amazonConfig);
        }

        public  async Task<IDataResult> UploadFileAsync(IFormFile file)
        {
            try
            {
                await using var memoryStr = new MemoryStream();
                await file.CopyToAsync(memoryStr);

                var fileExt = Path.GetExtension(file.FileName);
                var objName = $"{file.FileName}";

                var objectRequest = new PutObjectRequest()
                {
                    BucketName = "esitcvbackend",
                    Key = objName,
                    InputStream = memoryStr,
                    AutoCloseStream = false

                };


                await amazonS3Client.PutObjectAsync(objectRequest);

                var url = GetFileUrl(objName);

                return new DataResult(ResultStatus.Success, new {FileName=objName,FileUrl=url });

            }
            catch (AmazonS3Exception ex)
            {
                return new DataResult(ResultStatus.Success, ex.Message, ex.StatusCode);

            }
            catch (Exception ex)
            {
                return new DataResult(ResultStatus.Error, ex.Message);

            }


        }


        public string GetFileUrl(string fileName)
        {
            var expiryUrlRequest = new GetPreSignedUrlRequest()
            {
                BucketName = "esitcvbackend",
                Key = fileName,
                Expires = DateTime.Now.AddDays(10)
            };

            string url = amazonS3Client.GetPreSignedURL(expiryUrlRequest);
            return url;
        }

        public void DeleteFile(string fileName)
        {
            var deleteObject = new DeleteObjectRequest()
            {
                Key = fileName,
                BucketName = "esitcvbackend"
            };
            amazonS3Client.DeleteObjectAsync(deleteObject);
        }

        public async Task<IDataResult> UploadCVFileAsync(IFormFile file)
        {

            try
            {
                await using var memoryStr = new MemoryStream();
                await file.CopyToAsync(memoryStr);

                var fileExt = Path.GetExtension(file.FileName);
                var objName = $"{file.FileName}";

                var objectRequest = new PutObjectRequest()
                {
                    BucketName = "esitcvbackend-cvfiles",
                    Key = objName,
                    InputStream = memoryStr,
                    AutoCloseStream = false
                };

                await amazonS3Client.PutObjectAsync(objectRequest);
                var url = GetCVFileUrl(objName);

                return new DataResult(ResultStatus.Success, url,objName);


            }
            catch (AmazonS3Exception ex)
            {
                return new DataResult(ResultStatus.Error, ex.Message, ex.StatusCode);

            }
            catch (Exception ex)
            {
                return new DataResult(ResultStatus.Error, ex.Message);

            }
        }

        public string GetCVFileUrl(string bucketFilePath)
        {
            var expiryUrlRequest = new GetPreSignedUrlRequest()
            {
                BucketName = "esitcvbackend-cvfiles",
                Key = bucketFilePath,
                Expires = DateTime.Now.AddDays(10)
            };

            string url = amazonS3Client.GetPreSignedURL(expiryUrlRequest);
            return url;
        }

        public void DeleteCVFile(string fileName)
        {
            var deleteObject = new DeleteObjectRequest()
            {
                Key = fileName,
                BucketName = "esitcvbackend-cvfiles"
            };
            amazonS3Client.DeleteObjectAsync(deleteObject);
        }
    }
}
