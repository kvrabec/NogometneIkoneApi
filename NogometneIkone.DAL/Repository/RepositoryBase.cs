using Microsoft.EntityFrameworkCore;
using NogometneIkone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NogometneIkone.DAL.Repository
{
    public abstract class RepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected NIManagerDbContext DbContext { get; }
        public RepositoryBase(NIManagerDbContext context)
        {
            this.DbContext = context;
        }

        public virtual TEntity Find(int id)
        {
            return this.DbContext.Set<TEntity>()
                .AsNoTracking()
                .Where(p => p.ID == id)
                .FirstOrDefault();
        }

        public void Save()
        {
            this.DbContext.SaveChanges();
        }

        public void Add(TEntity model, bool autoSave = false)
        {
            model.DateCreated = DateTime.Now;

            this.DbContext.Set<TEntity>().Add(model);

            if (autoSave)
                this.Save();
        }

        public void Update(TEntity model, bool autoSave = false)
        {
            model.DateModified = DateTime.Now;

            this.DbContext.Entry(model).State = EntityState.Modified;

            if (autoSave)
                this.Save();
        }

        public virtual void Delete(int id, bool autoSave = false)
        {
            var entity = this.DbContext.Set<TEntity>().Find(id);
            this.DbContext.Entry(entity).State = EntityState.Deleted;

            if (autoSave)
                this.Save();
        }

        public TEntity GetRandomEntity()
        {
            Random random = new Random();
            List<int> idList = this.DbContext.Set<TEntity>().Select(e => e.ID).ToList();
            int randomEntityID = idList[random.Next(idList.Count)];
            return this.DbContext.Set<TEntity>().Where(m => m.ID == randomEntityID).FirstOrDefault();
        }
    }
}
