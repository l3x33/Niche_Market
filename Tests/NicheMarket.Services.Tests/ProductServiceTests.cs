﻿using AutoMapperConfiguration;
using Microsoft.EntityFrameworkCore;
using NicheMarket.Data;
using NicheMarket.Data.Models;
using NicheMarket.Services.Models;
using NicheMarket.Web.Models.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicheMarket.Services.Tests
{
    [TestFixture]
    class ProductServiceTests
    {
        private NicheMarketDBContext dBContext;
        private IProductService productService;

        [SetUp]
        public void SetUp()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(Product).Assembly.GetTypes(),
                typeof(ProductServiceModel).Assembly.GetTypes()
                );

            DbContextOptions<NicheMarketDBContext> options = new DbContextOptionsBuilder<NicheMarketDBContext>()
                .UseInMemoryDatabase($"TESTS-DB-{Guid.NewGuid()}")
                .Options;

            this.dBContext = new NicheMarketDBContext(options);
            this.productService = new ProductService(dBContext);
        }


        [Test]
        public async Task CreateProduct_ValidData_ShouldReturnTruthyValue()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            bool result = await productService.CreateProduct(productServiceModel);
            Assert.True(result, TestsMessages.ResultErrorMessage(nameof(productService.CreateProduct)));
        }

        [Test]
        public async Task CreateProduct_ValidData_ShouldCorrectlyCreateEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();

            Assert.IsNotNull(actualEntity);
        }

        [Test]
        public async Task CreateProductWithCorrectTitle_ValidData_ShouldCorrectlyMapData()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            Product expectedEntity = new Product()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();
            Assert.AreEqual(expectedEntity.Title, actualEntity.Title, TestsMessages.MappingErrorMessage(nameof(productService.CreateProduct), nameof(actualEntity.Title)));
        }


        [Test]
        public async Task CreateProductWithCorrectPrice_ValidData_ShouldCorrectlyMapData()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            Product expectedEntity = new Product()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();
            Assert.AreEqual(expectedEntity.Price, actualEntity.Price, TestsMessages.MappingErrorMessage(nameof(productService.CreateProduct), nameof(actualEntity.Price)));
        }

        [Test]
        public async Task CreateProductWithCorrectImageUrl_ValidData_ShouldCorrectlyMapData()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            Product expectedEntity = new Product()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();
            Assert.AreEqual(expectedEntity.ImageURL, actualEntity.ImageURL, TestsMessages.MappingErrorMessage(nameof(productService.CreateProduct), nameof(actualEntity.ImageURL)));
        }

        [Test]
        public async Task CreateProductWithCorrectType_ValidData_ShouldCorrectlyMapData()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            Product expectedEntity = new Product()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();
            Assert.AreEqual(expectedEntity.Type, actualEntity.Type, TestsMessages.MappingErrorMessage(nameof(productService.CreateProduct), nameof(actualEntity.Type)));
        }

        [Test]
        public async Task CreateProductWithCorrectDescription_ValidData_ShouldCorrectlyMapData()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            Product expectedEntity = new Product()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();
            Assert.AreEqual(expectedEntity.Description, actualEntity.Description, TestsMessages.MappingErrorMessage(nameof(productService.CreateProduct), nameof(actualEntity.Description)));
        }

        [Test]
        public async Task CreateProductWithCorrectRetailerId_ValidData_ShouldCorrectlyMapData()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            Product expectedEntity = new Product()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();
            Assert.AreEqual(expectedEntity.RetailerId, actualEntity.RetailerId, TestsMessages.MappingErrorMessage(nameof(productService.CreateProduct), nameof(actualEntity.RetailerId)));
        }

        [Test]
        public async Task CreateProductSetIdCorrectly_ValidData_ShouldCorrectlySetProductId()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product actualEntity = await dBContext.Products.FirstOrDefaultAsync();

            Assert.IsNotNull(actualEntity.Id, TestsMessages.SetPropertyIncorrectlyErrorMessage(nameof(productService.CreateProduct), nameof(Product.Id)));
        }


        [Test]
        public async Task EditProduct_ValidData_ShouldReturnTrue()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            Product entity = await dBContext.Products.FirstOrDefaultAsync();
            productServiceModel.Id = entity.Id;
            bool result = await productService.EditProduct(productServiceModel);
            Assert.IsTrue(result, TestsMessages.ResultErrorMessage(nameof(productService.EditProduct)));
        }

        [Test]
        public async Task EditProductPrice_ValidData_ShouldCorrectlyEditEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Price = 5;
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreEqual(expectedEntity.Price, actualEntity.Price, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Price)));
        }


        [Test]
        public async Task EditProductPrice_ValidData_ShouldBeDifferentFromTheOldEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Price = 5;
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreNotEqual(productServiceModel.Price, actualEntity.Price, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Price)));
        }


        [Test]
        public async Task EditProductTitle_ValidData_ShouldCorrectlyEditEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Title = "New Title";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreEqual(expectedEntity.Title, actualEntity.Title, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Title)));
        }

        [Test]
        public async Task EditProductTitle_ValidData_ShouldBeDifferentFromTheOldEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Title = "New Title";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreNotEqual(productServiceModel.Title, actualEntity.Title, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Title)));
        }


        [Test]
        public async Task EditProductType_ValidData_ShouldCorrectlyEditEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Type = "New type";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreEqual(expectedEntity.Type, actualEntity.Type, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Type)));
        }

        [Test]
        public async Task EditProductType_ValidData_ShouldBeDifferentFromTheOldEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Type = "New type";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreNotEqual(productServiceModel.Type, actualEntity.Type, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Type)));
        }


        [Test]
        public async Task EditProductDescription_ValidData_ShouldCorrectlyEditEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Description = "New description";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreEqual(expectedEntity.Description, actualEntity.Description, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Description)));
        }
        [Test]
        public async Task EditProductDescription_ValidData_ShouldBeDifferentFromTheOldEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.Description = "New description";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreNotEqual(productServiceModel.Description, actualEntity.Description, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.Description)));
        }

        [Test]
        public async Task EditProductImage_ValidData_ShouldCorrectlyEditEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1615983722/d8f9c6d8-a651-4d24-9d4c-987825d8b43d.png";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreEqual(expectedEntity.ImageURL, actualEntity.ImageURL, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.ImageURL)));
        }

        [Test]
        public async Task EditProductImage_ValidData_ShouldBeDifferentFromTheOldEntity()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            await productService.CreateProduct(productServiceModel);

            ProductServiceModel expectedEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();
            expectedEntity.ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1615983722/d8f9c6d8-a651-4d24-9d4c-987825d8b43d.png";
            await productService.EditProduct(expectedEntity);
            ProductServiceModel actualEntity = (await dBContext.Products.FirstOrDefaultAsync()).To<ProductServiceModel>();

            Assert.AreNotEqual(productServiceModel.ImageURL, actualEntity.ImageURL, TestsMessages.MappingErrorMessage(nameof(productService.EditProduct), nameof(Product.ImageURL)));
        }

        //[Test]
        //public async Task EditProductWithNullTitle_InvalidData_ShouldReturnFalse()
        //{
        //    ProductServiceModel productServiceModel = new ProductServiceModel()
        //    {
        //        Title = "TestProduct",
        //        Price = 3,
        //        Type = "TestProduct",
        //        Description = "TestProduct",
        //        ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
        //        RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
        //    };

        //    await productService.CreateProduct(productServiceModel);
        //    Product entity = await dBContext.Products.FirstOrDefaultAsync();
        //    productServiceModel.Id = entity.Id;
        //    productServiceModel.Title = null;
        //    bool result = await productService.EditProduct(productServiceModel);
        //    Assert.IsFalse(result, TestsMessages.ResultErrorMessage(nameof(productService.EditProduct)));
        //}

        [Test]
        public async Task EditProductWithNullId_InvalidData_ShouldReturnFalse()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Id = null,
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);
            bool result = await productService.EditProduct(productServiceModel);
            Assert.IsFalse(result, TestsMessages.ResultErrorMessage(nameof(productService.EditProduct)));
        }

        [Test]
        public async Task AllProducts_ValidData_ShouldReturnListOfProductViewModels()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct1",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };

            await productService.CreateProduct(productServiceModel);

            productServiceModel.Title = "TestProduct2";
            await productService.CreateProduct(productServiceModel);
            productServiceModel.Title = "TestProduct3";
            await productService.CreateProduct(productServiceModel);

            Assert.IsNotEmpty(await productService.AllProducts(), TestsMessages.ResultErrorMessage(nameof(productService.CreateProduct)));
            Assert.IsNotNull(await productService.AllProducts(), TestsMessages.ResultErrorMessage(nameof(productService.CreateProduct)));
        }

        [Test]
        public async Task AllProducts_ValidData_ShouldReturnTruthyValue()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct1",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            List<ProductViewModel> expectedProducts = new List<ProductViewModel>();

            for (int i = 0; i < 3; i++)
            {
                productServiceModel.Title += i.ToString();
                await productService.CreateProduct(productServiceModel);
                Product entity = await dBContext.Products.FirstOrDefaultAsync();
                expectedProducts.Add(entity.To<ProductViewModel>());

            }


            IEnumerable<ProductViewModel> retunedProducts = await productService.AllProducts();

            List<ProductViewModel> actualProducts = new List<ProductViewModel>();

            foreach (var product in retunedProducts)
            {
                actualProducts.Add(product);
            }


            Assert.AreEqual(actualProducts.Count, expectedProducts.Count, TestsMessages.ResultErrorMessage(nameof(productService.CreateProduct)));
        }

        [Test]
        public async Task AllProducts_ValidData_ShouldReturnEntitiesWithEqualValue()
        {
            ProductServiceModel productServiceModel = new ProductServiceModel()
            {
                Title = "TestProduct",
                Price = 3,
                Type = "TestProduct",
                Description = "TestProduct",
                ImageURL = "http://res.cloudinary.com/niche-market/image/upload/v1612549640/7223595e-3b3e-4452-bd9e-f3fad9130046.png",
                RetailerId = "69320701-412e-4de3-8e43-b39b17439c73"
            };
            //Dictionary<string, ProductViewModel> expectedProducts = new Dictionary<string, ProductViewModel>();            Dictionary<string, ProductViewModel> expectedProducts = new Dictionary<string, ProductViewModel>();
            List<ProductViewModel> expectedProducts = new List<ProductViewModel>();
            await productService.CreateProduct(productServiceModel);
            Product entity = await dBContext.Products.FirstOrDefaultAsync();
            expectedProducts.Add(entity.To<ProductViewModel>());

            productServiceModel.Price = 5;
            await productService.CreateProduct(productServiceModel);
            Product entity2 = await dBContext.Products.FirstOrDefaultAsync();
            expectedProducts.Add(entity2.To<ProductViewModel>());

            expectedProducts.OrderBy(p => p.Id);

            IEnumerable<ProductViewModel> retunedProducts = await productService.AllProducts();

            List<ProductViewModel> actualProducts = new List<ProductViewModel>();

            foreach (var product in retunedProducts)
            {
                actualProducts.Add(product);
            }

            bool result = true;
            foreach (var actualProduct in actualProducts)
            {
                if (!expectedProducts.Contains(actualProduct))
                {
                    result = false;
                }
            }
            Assert.IsTrue(result);
        }


        [TearDown]
        public void Dispose()
        {
            this.dBContext.Dispose();
            this.productService = null;
        }

    }
}