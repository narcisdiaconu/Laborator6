using System;
using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer
{
    public interface IRepository
    {
        void Create(Poi poi);
        void Update(Poi poi);
        void Delete(Guid id);
        Poi GetById(Guid id);
        IReadOnlyList<Poi> GetAll();
    }
}
