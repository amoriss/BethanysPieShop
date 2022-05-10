using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    { 
        //DbContext is registered in startup class in Configure Services
        //managed through the dependency injection container
        private readonly AppDbContext _appDbContext;

        //get access to Pie repository through constructor injection
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        IEnumerable<Pie> IPieRepository.AllPies      
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }
        

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
