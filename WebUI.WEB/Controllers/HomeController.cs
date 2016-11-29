using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.BLL.Interface;
using WebUI.BLL.DTO;
using WebUI.WEB.Models;
using AutoMapper;
using WebUI.BLL.Infrastructure;

namespace WebUI.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<PhoneDTO> phoneDtos = orderService.GetPhones();
            Mapper.Initialize(cfg => cfg.CreateMap<PhoneDTO, PhoneViewModel>());
            var phones = Mapper.Map<IEnumerable<PhoneDTO>, List<PhoneViewModel>>(phoneDtos);
            return View(phones);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                PhoneDTO phone = orderService.GetPhone(id);
                Mapper.Initialize(cfg => cfg.CreateMap<PhoneDTO, OrderViewModel>()
                    .ForMember("PhoneId", opt => opt.MapFrom(src => src.Id)));
                var order = Mapper.Map<PhoneDTO, OrderViewModel>(phone);
                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}