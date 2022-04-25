using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        //with Mock implementation instead of database

        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Pie> AllPies =>
            new List<Pie>
            {
                new Pie {PieId = 1, Name="Strawberry Pie", Price=15.95M, ShortDescription = "Lorem ", LongDescription = "Lorem", Category = _categoryRepository.AllCategories.ToList()[0]},
                new Pie {PieId = 2, Name="Cheese cake", Price=18.95M, ShortDescription = "Lorem ", LongDescription = "Lorem", Category = _categoryRepository.AllCategories.ToList()[1]},
                new Pie {PieId = 3, Name="Rhubarb Pie", Price=15.95M, ShortDescription = "Lorem ", LongDescription = "Lorem", Category = _categoryRepository.AllCategories.ToList()[1]},
                new Pie {PieId = 4, Name="Pumpkin Pie", Price=12.95M, ShortDescription = "Lorem ", LongDescription = "Lorem", Category = _categoryRepository.AllCategories.ToList()[1]}
                 

            };            
            

        public IEnumerable<Pie> PiesOfTheWeek { get; }
       

        public Pie GetPieById(int pieId)
        {
            return AllPies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
