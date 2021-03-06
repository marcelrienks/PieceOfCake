﻿using System.Web.Mvc;

namespace Web.Test.Validation
{
    /// <summary>
    ///     This allows for the testing of expected errors from ModelState
    /// </summary>
    internal class TestModelStateController : Controller
    {
        /// <summary>
        ///     Instantiate a new Controller Context
        /// </summary>
        public TestModelStateController()
        {
            ControllerContext = new ControllerContext();
        }

        /// <summary>
        ///     Call TryValidateModel to force Model validation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool TestTryValidateModel(object model)
        {
            return TryValidateModel(model);
        }
    }
}
