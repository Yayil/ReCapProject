using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Abstract
{
    public interface IFileHelper
    {
        IDataResult<string> UploadFile(IFormFile file);
        IDataResult<string> UploadFileUpdate(IFormFile file);
    }
}
