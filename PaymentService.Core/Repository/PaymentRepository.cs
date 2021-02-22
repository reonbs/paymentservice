using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentService.Core.Entity;
using PaymentService.Core.Interfaces;

namespace PaymentService.Core.Repository
{
    public class PaymentRepository : IPaymentRepository, IDisposable
    {
        private AppDBContext _appDBContext;

        public PaymentRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task Create(Payment payment)
        {
            _appDBContext.Add(payment);
            await _appDBContext.SaveChangesAsync();
        }

        public void Update(Payment Payment)
        {
            _appDBContext.Attach(Payment);
            _appDBContext.Entry(Payment).State = EntityState.Modified;
        }

        public async Task<Payment> GetById(long Id)
        {
            return await _appDBContext.Payments.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Payment>> GetAll(Expression<Func<Payment, bool>> predicate)
        {
            return await _appDBContext.Payments.Where(predicate).ToListAsync();
        }

        public bool Exist(Expression<Func<Payment, bool>> predicate)
        {
            return _appDBContext.Payments.Where(predicate).Any();
        }

        public async Task SaveChangesAsync()
        {
            await _appDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDBContext.Dispose();
            _appDBContext = null;
        }
    }
}
