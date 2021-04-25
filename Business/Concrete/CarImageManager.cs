using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(AddCarImageDto carImageDto)
        {
            var result = BusinessRules.Run(CheckImageCount(carImageDto.CarId));
            if (result != null)
            {
                return result;
            }
            else
            {
                var imagepath = UploadImage(carImageDto.File);
                if (imagepath.Success)
                {
                    CarImage carImage = new CarImage
                    {
                        CarId = carImageDto.CarId,
                        ImagePath = imagepath.Data
                    };
                    _carImageDal.Add(carImage);
                    return new SuccessResult();
                }
            }
            return new ErrorResult();
        }

        public IResult CheckImageCount(int id)
        {
            var result = _carImageDal.GetAll(x => x.CarImageId == id).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {
            _carImageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());

        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x=>x.CarId==id));
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x=>x.CarId==id));
        }

        public IResult Update(UpdateCarImageDto carImageDto)
        {

                CarImage carImage = new CarImage
                {
                    CarImageId = carImageDto.Id,
                    CarId = carImageDto.CarId
                };

                var fileOperation = _fileHelper.UploadFileUpdate(carImageDto.File);
                if (fileOperation.Success)
                {
                    carImage.ImagePath = fileOperation.Data;
                    _carImageDal.Update(carImage);
                    return new SuccessResult();
                }
                return new ErrorResult(fileOperation.Message);
            
        }

        public IDataResult<string> UploadImage(IFormFile File)
        {
            return _fileHelper.UploadFile(File);
        }
    }
}
