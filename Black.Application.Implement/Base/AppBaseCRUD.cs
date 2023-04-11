using Black.Application.Base;
using Black.Domain.Core.Models;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement.Base
{
    public class AppBaseCRUD<TEntity, TKey> : AppBase<TEntity, TKey>, IAppBaseCRUD<TEntity, TKey> where TEntity : Entity<TEntity, TKey>
    {
        #region Properties
        private readonly IServiceBaseCRUD<TEntity, TKey> _service;
        protected readonly IUnitOfWork _uow;
        #endregion

        #region Construtores
        public AppBaseCRUD(IServiceBaseCRUD<TEntity, TKey> service, INotificationHandler<DomainNotification> notification, IUser user, IUnitOfWork uow) : base(service, notification, user)
        {
            _service = service;
            _uow = uow;
        }
        #endregion

        #region Methods
        public virtual Task<bool> UpdateAsync(TEntity obj)
        {
            _service.Update(obj);
            return _uow.SaveAsync();
        }

        public virtual Task<bool> AddAsync(TEntity obj)
        {
            _service.Add(obj);
            return _uow.SaveAsync();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public virtual Task<bool> DeleteAsync(TKey id)
        {
            _service.Delete(id);
            return _uow.SaveAsync();
        }

        public virtual Task<bool> DeleteAllAsync()
        {
            _service.DeleteAllAsync();
            return _uow.SaveAsync();
        }

        public virtual bool Save()
        {
            return _uow.Save();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _service.GetByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        #endregion
    }
}
