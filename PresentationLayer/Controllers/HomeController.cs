using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTO;
using System.Linq;
using System.Web.Mvc;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Collections;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {    
        public ActionResult Index()
        {
            return View();
        }        
    }
}