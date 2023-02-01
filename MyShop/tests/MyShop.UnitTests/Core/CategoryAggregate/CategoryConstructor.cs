using MyShop.Core.CategoryAggregate;
using MyShop.Core.ProjectAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyShop.UnitTests.Core.CategoryAggregate
{
    public class CategoryConstructor
    {
        private string _testName = "test name";
        private string _testDescription = "test description";
        private Category? _testCategory;

        private Category CreateCategory()
        {
            return new Category(_testName, _testDescription);
        }

        [Fact]
        public void Initialize()
        {
            _testCategory = CreateCategory();

            Assert.Equal(_testName, _testCategory.Name);
            Assert.Equal(_testDescription, _testCategory.Description);
        }
    }
}
