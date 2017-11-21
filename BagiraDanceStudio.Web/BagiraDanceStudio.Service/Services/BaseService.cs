using BagiraDanceStudio.Service.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Service.Services
{
    public class BaseService
    {
        protected BaseService()
        {
            UserAutoMapper.Initi();
        }
    }
}
