using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult AddPayment(Payment payment)
        {
            payment.ProcessDate = DateTime.Now;
            _paymentDal.Add(payment);
            return new SuccessResult("Refactor edilecek başarılı payment mesajı");
        }
    }
}
