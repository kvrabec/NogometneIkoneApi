using System;
using System.Collections.Generic;
using System.Text;

namespace NogometneIkone.DAL.Repository.IRepository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        List<TEntity> GetList();
        TEntity Find(int id);
        void Save();
        void Add(TEntity model, bool autoSave = false);
        void Update(TEntity model, bool autoSave = false);
        void Delete(int id, bool autoSave = false);
    }
}
