﻿using System;
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
    }
}
