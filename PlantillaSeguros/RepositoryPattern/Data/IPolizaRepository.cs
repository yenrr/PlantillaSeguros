using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EntityLibrary;

namespace RepositoryPattern.Data
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IPolizaRepository : IDisposable
    {
        IEnumerable<Poliza> GetAll();
        Poliza GetPolizaByID(long? Id_Poliza);
        void Add(Poliza poliza);
        void Delete(long? Id_Poliza);
        void Edit(Poliza poliza);
        void Save();
    }
}
