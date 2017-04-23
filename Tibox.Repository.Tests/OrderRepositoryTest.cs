using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tibox.Models;
using Tibox.UnitOfWork;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderRepositoryTest()
        {
            _unitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Orders()
        {
            var orderList = _unitOfWork.Orders.GetAll();
            Assert.AreEqual(orderList.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Order()
        {
            var order = new Order
            {
                CustomerId=1,
                OrderDate=DateTime.Now,
                OrderNumber="99999",
                TotalAmount=200                                
            };
            var result = _unitOfWork.Orders.Insert(order);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void First_ORder_By_Id()
        {
            var order = _unitOfWork.Orders.GetEntityById(1);
            Assert.AreEqual(order != null, true);
                        
            Assert.AreEqual(order.Id, 1);
            Assert.AreEqual(order.CustomerId, 85);
            Assert.AreEqual(order.TotalAmount, 440);

        }

        [TestMethod]
        public void Delete_Order()
        {
            var customer = _unitOfWork.Orders.GetEntityById(831);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_unitOfWork.Orders.Delete(customer), true);
        }

        [TestMethod]
        public void Update_Order()
        {
            var order = _unitOfWork.Orders.GetEntityById(1);
            Assert.AreEqual(order != null, true);

            Assert.AreEqual(_unitOfWork.Orders.Update(order), true);
        }

        [TestMethod]
        public void Order_By_OrderNumber()
        {
            var order = _unitOfWork.Orders.OrderByOrderNumber("543207");
            Assert.AreEqual(order != null, true);
            
            Assert.AreEqual(order.Id, 830);
            Assert.AreEqual(order.CustomerId, 65);
            Assert.AreEqual(order.TotalAmount, Convert.ToDecimal(1374.60));
        }

        [TestMethod]
        public void Customer_With_Orders()
        {
            var order = _unitOfWork.Orders.OrderWithOrderItems(1);
            Assert.AreEqual(order != null, true);

            Assert.AreEqual(order.OrderItems.Any(), true);
        }

    }
}
