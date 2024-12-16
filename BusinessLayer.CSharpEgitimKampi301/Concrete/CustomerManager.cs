﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_CSharpEgitimKampi301.Concrete;
using BusinessLayer.CSharpEgitimKampi301.Abstract;
using DataAccessLayer.CSharpEgitimKampi301.Abstract;

namespace BusinessLayer.CSharpEgitimKampi301.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
           _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerName.Length >=3  && entity.CustomerCity != null &&
                entity.CustomerSurname !=""&& entity.CustomerName.Length <= 30) 
            {
                _customerDal.Insert(entity);
            }
            else
            {

            }
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}