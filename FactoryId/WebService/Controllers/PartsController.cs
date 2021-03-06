﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackEnd;
using WebService.Models;

namespace WebService.Controllers
{
    public class PartsController : ApiController
    {
        public PartModel Get(string id)
        {
            return new PartModel(new PartsManipulator().GetPart(id));
        }

        public class NewPart
        {
            public string Factory { get; set; }
            public string Category { get; set; }
        }

        public string Post(NewPart param)
        {
            var part = new PartsManipulator().GenerateNewPart(param.Factory, param.Category);
            return new PartModel(part).Name;
        }

        public void Delete(string id)
        {
            new PartsManipulator().DeletePart(id);
        }
    }
}
