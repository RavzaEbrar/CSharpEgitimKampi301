﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_CSharpEgitimKampi301.EntityLayer.Concrete;
using DataAccessLayer.CSharpEgitimKampi301.Abstract;
using DataAccessLayer.CSharpEgitimKampi301.Repositories;

namespace DataAccessLayer.CSharpEgitimKampi301.EntityFramework
{
    public class EfAdminDal:GenericRepository<Admin>,IAdminDal
    {
    }
}