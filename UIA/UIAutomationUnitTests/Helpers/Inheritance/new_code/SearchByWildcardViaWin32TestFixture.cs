﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2013
 * Time: 10:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    using System.Linq;
    
    /// <summary>
    /// Description of SearchByWildcardViaWin32TestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class SearchByWildcardViaWin32TestFixture
    {
    	public SearchByWildcardViaWin32TestFixture()
    	{
    		FakeFactory.Init();
    	}
    	
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}
