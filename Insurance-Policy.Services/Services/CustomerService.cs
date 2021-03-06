﻿using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Domain.Interfaces;
using Insurance_Policy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Services.Services
{
    public class CustomerService : ICustomerService<Customer>
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public bool Add(Customer entity)
        {
            try
            {
                this.repository.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(Customer entity)
        {
            this.repository.Delete(entity);
        }

        public Customer Get(Customer entity)
        {
            return this.repository.Get(x => x.Name == entity.Name);
        }

        public List<Customer> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public bool Update(Customer entity)
        {
            try
            {
                this.repository.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
