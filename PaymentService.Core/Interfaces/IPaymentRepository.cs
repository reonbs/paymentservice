using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PaymentService.Core.Entity;

namespace PaymentService.Core.Interfaces
{
    public interface IPaymentRepository
    {
        Task Create(Payment payment);
        void Update(Payment Payment);
        Task<Payment> GetById(long Id);
        Task<List<Payment>> GetAll(Expression<Func<Payment, bool>> predicate);
        bool Exist(Expression<Func<Payment, bool>> predicate);
        Task SaveChangesAsync();
    }
}
