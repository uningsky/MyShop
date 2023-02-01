using MyShop.Core.ProductAggregate;
using MyShop.Core.ProjectAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyShop.UnitTests.Core.ProductAggregate
{
    public class ProductConstructor
    {
        private string _testName = "test name";
        private string _testDescription = "test description";
        private string _testImagePath = "test imagePath";
        private decimal _testPrice = 1000;
        private int _testQuantity = 3;
        private Product? _testProduct;

        private Product CreateProduct()
        {
            return new Product(_testName, _testDescription, _testImagePath, _testPrice, _testQuantity);
        }

        [Fact]
        public void Initialize()
        {
            _testProduct = CreateProduct();

            Assert.Equal(_testName, _testProduct.Name);
            Assert.Equal(_testDescription, _testProduct.Description);
            Assert.Equal(_testImagePath, _testProduct.ImagePath);
            Assert.Equal(_testPrice, _testProduct.Price);
            Assert.Equal(_testQuantity, _testProduct.Quantity);
        }

        [Fact]
        public void InitializesEmptyCategory()
        {
            _testProduct = CreateProduct();

            Assert.Empty(_testProduct.Categories);
        }
    }
}
