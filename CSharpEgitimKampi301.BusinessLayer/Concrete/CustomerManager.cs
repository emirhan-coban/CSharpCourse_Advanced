using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerService)
        {
            _customerDal = customerService;
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
            if (entity.CustomerName != "" && entity.CustomerName.Length >= 3 && entity.CustomerCity != null && entity.CustomerSurname != "" && entity.CustomerName.Length <= 30)
            {
                _customerDal.Insert(entity);
            }
            else
            {
                throw new Exception("Müşteri eklenemedi. Lütfen bilgileri kontrol ediniz.");
            }
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
