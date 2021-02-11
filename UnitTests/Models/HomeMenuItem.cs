using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Mine.Models;
namespace UnitTests.Models
{
    [TestFixture]
    class HomeMenuItemTests
    {
        [Test]
        public void HomeMenuItem_Constructor_Valid_()
        {
            var result = new HomeMenuItem();

            Assert.IsNotNull(result);
        }
        [Test]
        public void HomeMenuItem_Set_Get_Valid_Default_Should_Pass()
        {
            var result = new HomeMenuItem();
            result.Id = MenuItemType.Game;
            result.Title = "Text";
  
            Assert.AreEqual(MenuItemType.Game, result.Id);
            Assert.AreEqual("Text", result.Title);

        }
    }
}
