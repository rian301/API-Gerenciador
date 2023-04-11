using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class ProductController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IProductApp _app;
        private readonly ICustomerProductApp _customerProductapp;
        private readonly ISubscriptionApp _subscriptionApp;
        #endregion

        #region Constructors
        public ProductController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IProductApp app, ICustomerProductApp customerProductapp, ISubscriptionApp subscriptionApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
            _customerProductapp = customerProductapp;
            _subscriptionApp = subscriptionApp;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.PRODUCT_VIEW })]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAll()
        {
            var list = _app.GetAll();
            var listVM = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            foreach (var item in listVM)
            {
                var qtdS = await _subscriptionApp.GetAllByProduct(item.Id.Value);
                var qtd = await _customerProductapp.GetAllProductByCustomer(item.Id.Value);
                item.QuantityCustomers = qtd.Count() + qtdS.Count();
            }

            return ResolveReturn(listVM);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PRODUCT_VIEW })]
        public async Task<ActionResult<ProductViewModel>> GetById(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<ProductViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.PRODUCT_ADD })]
        public async Task<ActionResult<ProductViewModel>> Post([FromBody] ProductViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Product>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PRODUCT_ADD })]
        public async Task<ActionResult<ProductViewModel>> Put(int id, [FromBody] ProductViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            //var dto = _mapper.Map<LaunchDTO>(model);
            var obj = _mapper.Map<Product>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);
            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.PRODUCT_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<ProductViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
