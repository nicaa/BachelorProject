using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garia.Core.Entities;
using Garia.Controllers;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Garia.Test
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void Message_ValidMessage()
        {
            Message model = new Message();
            model.Title = "Valid title ";
            model.MessageText = "Valid message";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Message_TitleEmpty()
        {
            Message model = new Message();
            model.Title = "";
            model.MessageText = "Valid message";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Message_MessageEmpty()
        {
            Message model = new Message();
            model.Title = "Valid title ";
            model.MessageText = "";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Message_TitleLongerThan100Chars()
        {
            Message model = new Message();
            model.Title = "Valid titleValid title Valid title Valid title Valid title Valid title Valid title Valid title Valid title Valid title  ";
            model.MessageText = "Valid message";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Message_TitleMessageEmpty()
        {
            Message model = new Message();
            model.Title = "";
            model.MessageText = "";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }
    }
}
