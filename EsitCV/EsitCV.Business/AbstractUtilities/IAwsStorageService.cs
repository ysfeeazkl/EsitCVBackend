using EsitCV.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AbstractUtilities
{
    public interface IAwsStorageService
    {
        Task<IDataResult> UploadFileAsync(IFormFile file);
        Task<IDataResult> UploadCVFileAsync(IFormFile file);
        public string GetFileUrl(string bucketFilePath);
        public string  GetCVFileUrl(string bucketFilePath);
        void DeleteFile(string fileName);
        void DeleteCVFile(string fileName);
    }
}
