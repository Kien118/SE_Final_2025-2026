using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AWE_BLL; 

namespace AWE_Tests
{
    [TestClass]
    public class GoodsReceiptTests
    {
        // 1. Test Case EP
        [TestMethod]
        public void CalculateLineTotal_ValidInput_ReturnsCorrectResult()
        {
            // Arrange 
            GoodsReceiptBLL bll = new GoodsReceiptBLL();
            int qty = 10;
            decimal price = 5000;
            decimal expected = 50000; // 10 * 5000 = 50000

            // Act 
            decimal actual = bll.CalculateLineTotal(qty, price);

            // Assert 
            Assert.AreEqual(expected, actual, "Tổng tiền tính toán sai ở trường hợp thường!");
        }

        // 2. Test Case BVA
        [TestMethod]
        public void CalculateLineTotal_ZeroQuantity_ReturnsZero()
        {
            // Arrange
            GoodsReceiptBLL bll = new GoodsReceiptBLL();
            int qty = 0; // BIÊN
            decimal price = 5000;
            decimal expected = 0;

            // Act
            decimal actual = bll.CalculateLineTotal(qty, price);

            // Assert
            Assert.AreEqual(expected, actual, "Tổng tiền phải là 0 khi số lượng = 0");
        }

        // 3. Test Case EP (Invalid)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] 
        public void CalculateLineTotal_NegativeQuantity_ThrowsException()
        {
            // Arrange
            GoodsReceiptBLL bll = new GoodsReceiptBLL();
            int qty = -5; 
            decimal price = 5000;

            // Act
            bll.CalculateLineTotal(qty, price);

            
        }

        // 4. Test Case BVA: 
        [TestMethod]
        public void CalculateLineTotal_QuantityOne_ReturnsPrice()
        {
            // Arrange
            GoodsReceiptBLL bll = new GoodsReceiptBLL();
            int qty = 1; 
            decimal price = 1000;
            decimal expected = 1000;

            // Act
            decimal actual = bll.CalculateLineTotal(qty, price);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}