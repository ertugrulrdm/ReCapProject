using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Color> _color;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=300, ModelYear=2020, Description = "2020 model beyaz Renault Clio."},
                new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=500, ModelYear=2015, Description = "2015 model siyah Audi A3."},
                new Car{CarId=3, BrandId=2, ColorId=3, DailyPrice=650, ModelYear=2020, Description = "2018 model bordo Audi A4."},
                new Car{CarId=4, BrandId=3, ColorId=1, DailyPrice=100, ModelYear=2020, Description = "2010 model beyaz Toyota Corolla."},
                new Car{CarId=5, BrandId=4, ColorId=2, DailyPrice=800, ModelYear=2020, Description = "2021 model siyah BMW 320i."},
            };

            _color = new List<Color>
            {
                new Color{ColorId=1, ColorName="Beyaz"},
                new Color{ColorId=2, ColorName="Siyah"},
                new Color{ColorId=3, ColorName="Bordo"},
                new Color{ColorId=4, ColorName="Mavi"},
                new Color{ColorId=5, ColorName="Gri"},
                new Color{ColorId=6, ColorName="Kırmızı"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public Car GetById(int carId)
        {
            Car carToGet = _cars.SingleOrDefault(c => c.CarId == carId);
            return carToGet;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
