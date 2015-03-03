using DataModel;
using FFC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FFC.Controllers
{
    public class WishBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            String id = controllerContext.RequestContext.HttpContext.Request["Wish.ID"];
            if (id == null)
            {
                return new Wish()
                {
                    Item = controllerContext.RequestContext.HttpContext.Request["Wish.Item"],
                    Note = controllerContext.RequestContext.HttpContext.Request["Wish.Note"]
                };
            }
            else
            {
                return new Wish(int.Parse(id))
                {
                    Item = controllerContext.RequestContext.HttpContext.Request["Wish.Item"],
                    Note = controllerContext.RequestContext.HttpContext.Request["Wish.Note"]
                };
            }
        }
    }
}
