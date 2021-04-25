using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal 
    {
        private readonly List<Car> _carDal;
        public InMemoryCarDal()
        {
            _carDal = new List<Car> {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=150,Description="FIAT LINEA",ModelYear=2020},
                new Car{CarId=2,BrandId=2,ColorId=3,DailyPrice=200,Description="AUDI A6",ModelYear=2019},
                new Car{CarId=3,BrandId=2,ColorId=2,DailyPrice=180,Description="FORD FIESTA",ModelYear=2020},
                new Car{CarId=4,BrandId=1,ColorId=1,DailyPrice=210,Description="BMW 320",ModelYear=2020}
                };
        }
        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _carDal.SingleOrDefault(c => c.CarId == car.CarId);
            _carDal.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _carDal;
        }

        public Car GetById(int id)
        {
            return _carDal.SingleOrDefault(x => x.CarId == id);
        }

        public void Update(Car car)
        {
            var carToUpdate = _carDal.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
