using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        //with Mock implementation instead of database
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit pies", Description="All fruit pies"},
                new Category{CategoryId=2, CategoryName="Cheese cakes", Description="All fruit pies"},
                new Category{CategoryId=3, CategoryName="Seasonal pies", Description="All fruit pies"}
            };

    }
}
