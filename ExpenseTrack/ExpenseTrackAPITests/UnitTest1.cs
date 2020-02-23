using ExpenseTrackAPI.Controllers;
using System;
using Xunit;

namespace ExpenseTrackAPITests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var fakeExpenseId = "12";
            //var fakeOrder = GetFakeOrder();

            //...

            //Act
            var x = 2 + 4;

            //Assert
            Assert.Equal(6, x);
        }
    }
}
