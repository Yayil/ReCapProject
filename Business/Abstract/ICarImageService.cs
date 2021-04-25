using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CarImageDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(AddCarImageDto carImage);
        IResult Update(UpdateCarImageDto carImage);
        IResult Delete(CarImage image);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImageByCarId(int id);
        IResult CheckImageCount(int id);
        IDataResult<string> UploadImage(IFormFile File);
    }
}
