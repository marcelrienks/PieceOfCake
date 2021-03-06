﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Test.Factories.RepresenterFactories;

namespace Web.Test.Validation
{
    [TestClass]
    public class RoleRepresenterTest
    {
        #region Properties

        private readonly TestModelStateController _testController; 
        
        #endregion

        public RoleRepresenterTest()
        {
            _testController = new TestModelStateController();
        }

        [TestMethod]
        public void TestRequiredFields()
        {
            var role = new RoleRepresenterFactory().WithNullRequiredFields().Build();
            var result = _testController.TestTryValidateModel(role);

            var modelState = _testController.ModelState;

            Assert.IsFalse(result);
            Assert.AreEqual(1, modelState.Keys.Count);

            Assert.IsTrue(modelState.Keys.Contains("Title"));
            Assert.IsTrue(modelState["Title"].Errors.Count == 1);
            Assert.AreEqual("The Title field is required.", modelState["Title"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void TestInvalidFields()
        {
            var role = new RoleRepresenterFactory().WithInvalidFields().Build();
            var result = _testController.TestTryValidateModel(role);

            var modelState = _testController.ModelState;

            Assert.IsFalse(result);
            Assert.AreEqual(2, modelState.Keys.Count);

            Assert.IsTrue(modelState.Keys.Contains("Title"));
            Assert.IsTrue(modelState["Title"].Errors.Count == 1);
            Assert.AreEqual("The Title must be between 3 and 30 characters long.",
                modelState["Title"].Errors[0].ErrorMessage);

            Assert.IsTrue(modelState.Keys.Contains("Description"));
            Assert.IsTrue(modelState["Description"].Errors.Count == 1);
            Assert.AreEqual("The Description must be between 3 and 180 characters long.",
                modelState["Description"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void TestValidRole()
        {
            var role = new RoleRepresenterFactory().Build();
            var result = _testController.TestTryValidateModel(role);

            var modelState = _testController.ModelState;

            Assert.IsTrue(result);
            Assert.AreEqual(0, modelState.Keys.Count);
        }
    }
}
