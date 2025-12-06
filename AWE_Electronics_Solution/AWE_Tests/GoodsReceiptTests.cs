using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AWE_BLL; // Tham chiếu đến logic cần test

namespace AWE_Tests
{
    [TestClass]
    public class GoodsReceiptTests
    {
        // 1. Test Case EP: Kiểm tra tính toán thông thường (Hợp lệ)
        [TestMethod]
        public void CalculateLineTotal_ValidInput_ReturnsCorrectResult()
        {
            // Arrange (Chuẩn bị)
            GoodsReceiptBLL bll = new GoodsReceiptBLL();
            int qty = 10;
            decimal price = 5000;
            decimal expected = 50000; // 10 * 5000 = 50000

            // Act (Thực hiện hành động)
            decimal actual = bll.CalculateLineTotal(qty, price);

            // Assert (Kiểm tra kết quả)
            Assert.AreEqual(expected, actual, "Tổng tiền tính toán sai ở trường hợp thường!");
        }

        // 2. Test Case BVA: Kiểm tra biên số 0 (Boundary Value)
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

        // 3. Test Case EP (Invalid): Kiểm tra số âm (Ném ra lỗi)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // Mong đợi chương trình báo lỗi
        public void CalculateLineTotal_NegativeQuantity_ThrowsException()
        {
            // Arrange
            GoodsReceiptBLL bll = new GoodsReceiptBLL();
            int qty = -5; // Giá trị không hợp lệ
            decimal price = 5000;

            // Act
            bll.CalculateLineTotal(qty, price);

            // Assert: Không cần Assert vì [ExpectedException] đã tự bắt lỗi rồi
        }

        // 4. Test Case BVA: Kiểm tra biên giá trị = 1
        [TestMethod]
        public void CalculateLineTotal_QuantityOne_ReturnsPrice()
        {
            // Arrange
            GoodsReceiptBLL bll = new GoodsReceiptBLL();
            int qty = 1; // BIÊN
            decimal price = 1000;
            decimal expected = 1000;

            // Act
            decimal actual = bll.CalculateLineTotal(qty, price);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}