using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;

namespace WebApplication1.Rp
{
    public class UnitOfWork : IDisposable
    {
        private CarsContext db = new CarsContext();
        private CarRepository carRepository;

        public CarRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        public object Car { get; internal set; }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}