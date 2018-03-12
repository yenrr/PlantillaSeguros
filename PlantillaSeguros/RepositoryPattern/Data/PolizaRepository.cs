using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityLibrary;


namespace RepositoryPattern.Data
{
    public class PolizaRepository : IPolizaRepository, IDisposable
    {
        //Context
        private SegurosEntities _context = new SegurosEntities();

        public PolizaRepository(SegurosEntities context)
        {
           this._context = context;
        }

        public void Add(Poliza poliza)
        {
            _context.Poliza.Add(poliza);
        }

        public void Delete(long? Id_poliza)
        {
            Poliza student = _context.Poliza.Find(Id_poliza);
            _context.Poliza.Remove(student);
        }

        public void Edit(Poliza poliza)
        {
            _context.Entry(poliza).State = EntityState.Modified;
        }
        

        public IEnumerable<Poliza> GetAll()
        {
            return _context.Poliza.ToList();
        }

        public Poliza GetPolizaByID(long? Id_Poliza)
        {
            return _context.Poliza.Find(Id_Poliza);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}



