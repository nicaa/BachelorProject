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
    public class TaskTest
    {
        [TestMethod]
        public void Task_ValidTask()
        {
            GariaTask model = new GariaTask();
            model.Title = "Valid title ";
            model.Description = "Valid Description";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void Task_TitleEmpty()
        {
            GariaTask model = new GariaTask();
            model.Title = "";
            model.Description = "Valid Description";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void Task_DescriptionEmpty()
        {
            GariaTask model = new GariaTask();
            model.Title = "Valid title";
            model.Description = "";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void Task_TitleLongerThan300Chars()
        {
            GariaTask model = new GariaTask();
            model.Title = "DeterminesDeterminesDetermines Determines whether the specified object is valid using the validation context, validation results collection, and a value that specifies whether to validate all properties.Determines whether the specified object is valid using the validation context, validation results collection,";
            model.Description = "Valid Description";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void Task_TitleDescriptionEmpty()
        {
            GariaTask model = new GariaTask();
            model.Title = "";
            model.Description = "";

            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), new List<ValidationResult>(), true);
            Assert.IsFalse(isValid);
        }
    }
}
