﻿using AutoMapperConfiguration;
using NicheMarket.Data;
using NicheMarket.Data.Models;
using NicheMarket.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicheMarket.Services
{
    public class RetailerService : IRetailerService
    {
        private readonly NicheMarketDBContext dBContext;

        public RetailerService(NicheMarketDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IEnumerable<ProductViewModel>> MyProducts(string retailerId)
        {
            List<Product> products = dBContext.Products.Where(p => p.RetailerId == retailerId).ToList();
            List<ProductViewModel> myProducts = new List<ProductViewModel>();

            foreach (var product in products)
            {
                myProducts.Add(product.To<ProductViewModel>());
            }
            return myProducts;
        }
        public async Task<IEnumerable<OrderViewModel>> PendingOrders(string retailerId)
        {
            List<OrderViewModel> orders = dBContext.Orders.Where(o => o.RetailerId == retailerId && o.IsCompleted == false).Select(o => o.To<OrderViewModel>()).ToList();
            return orders;
        }

        public async Task<IEnumerable<OrderViewModel>> CompletedOrders(string retailerId)
        {
            List<OrderViewModel> orders = dBContext.Orders.Where(o => o.RetailerId == retailerId && o.IsCompleted == true).Select(o => o.To<OrderViewModel>()).ToList();
            return orders;
        }

        public async Task<bool> ComleteOrder(string orderId)
        {
            Order order = await dBContext.Orders.FindAsync(orderId);
            if (order == null)  return  false;
            order.IsCompleted = true;
            dBContext.Orders.Update(order);
            dBContext.SaveChanges();
            return true;
        }     
        public async Task<bool> UndoOrder(string orderId)
        {
            Order order = await dBContext.Orders.FindAsync(orderId);
            if (order == null)  return  false;
            order.IsCompleted = false;
            dBContext.Orders.Update(order);
            dBContext.SaveChanges();
            return true;
        }

    }
}
