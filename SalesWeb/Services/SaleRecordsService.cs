using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Models;

namespace SalesWeb.Services
{
    public class SaleRecordsService
    {
        private readonly SalesWebContext _context;

        public SaleRecordsService(SalesWebContext context)
        {
            _context = context;
        }

        public async Task<List<SaleRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from saleRecord in _context.SaleRecord select saleRecord;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SaleRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from saleRecord in _context.SaleRecord select saleRecord;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
