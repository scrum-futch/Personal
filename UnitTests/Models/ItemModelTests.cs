using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Mine.Models;
namespace UnitTests.Models
{
    [TestFixture]
    class ItemModelTests
    {
        [Test]
        public void ItemModel_Constructor_Valid_()
        {
            var result = new ItemModel();

            Assert.IsNotNull(result);
        }
        [Test]
        public void ItemModel_Set_Get_Valid_Default_Should_Pass()
        {
            var result = new ItemModel();
            result.Description = "Description";
            result.Id = "ID";
            result.Text = "Text";
            result.Value = 1;

            Assert.AreEqual("Description",result.Description);
            Assert.AreEqual("ID",result.Id);
            Assert.AreEqual("Text", result.Text);
            Assert.AreEqual(1,result.Value);
        }
        [Test]
        public void ItemModel_Get_Valid_Default_Should_Pass()
        {
            var result = new ItemModel();

            Assert.AreEqual(0, result.Value);
        }
    }
}
