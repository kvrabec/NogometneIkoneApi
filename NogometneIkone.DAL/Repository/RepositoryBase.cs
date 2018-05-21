using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NogometneIkone.Model;

namespace NogometneIkone.DAL.Repository
{
    public abstract class RepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        public RepositoryBase(NIManagerDbContext context)
        {
            DbContext = context;
        }

        protected NIManagerDbContext DbContext { get; }

        public virtual TEntity Find(int id)
        {
            return DbContext
                .Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(p => p.ID == id);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public void Add(TEntity model, bool autoSave = false)
        {
            model.DateCreated = DateTime.Now;

            DbContext.Set<TEntity>().Add(model);

            if (autoSave)
                Save();
        }

        public void Update(TEntity model, bool autoSave = false)
        { 
            DbContext.Entry(model).State = EntityState.Modified;

            if (autoSave)
                Save();
        }

        public virtual void Delete(int id, bool autoSave = false)
        {
            var entity = DbContext.Set<TEntity>().Find(id);
            DbContext.Entry(entity).State = EntityState.Deleted;

            if (autoSave)
                Save();
        }

        public TEntity GetRandomEntity()
        {
            var random = new Random();
            var idList = DbContext.Set<TEntity>().Select(e => e.ID).ToList();
            var randomEntityId = idList[random.Next(idList.Count)];
            return DbContext.Set<TEntity>().FirstOrDefault(m => m.ID == randomEntityId);
        }
    }
}