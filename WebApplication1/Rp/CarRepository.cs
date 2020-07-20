using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Data;

namespace WebApplication1.Rp
{
    public class CarRepository : IRepository<Car>
    {
        private CarsContext db;

        public CarRepository(CarsContext db)
        {
            this.db = db;
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars;
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public void Create(Car car)
        {
            db.Cars.Add(car);
        }

        public void Update(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
                db.Cars.Remove(car);
        }

        internal object Get(int? id)
        {
            throw new NotImplementedException();
        }

        internal void Edit(Car car)
        {
            throw new NotImplementedException();
        }
    }
}