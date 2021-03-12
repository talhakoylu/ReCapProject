using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailsDto(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Customers
                    join user in context.Users on c.UserId equals user.Id
                    select new CustomerDetailDto()
                    {
                        UserId = c.UserId,
                        CompanyName = c.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email
                    };
                return result.ToList();
            }
        }
    }
}
