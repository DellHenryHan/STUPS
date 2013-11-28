﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/25/2013
 * Time: 8:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetControlConditionsTestFixture.
    /// </summary>
    [TestFixture]
    public class GetControlConditionsTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private AndCondition ResultAndCondition { get; set; }
        private OrCondition ResultOrCondition { get; set; }
        
        private void getAndConditions(string name, string automationId, string className, string controlType)
        {
            ResultAndCondition = null;
            
            GetControlCmdletBase cmdlet =
                new GetControlCmdletBase {Name = name, AutomationId = automationId, Class = className, CaseSensitive = false };

            CommonCmdletBase common =
                new CommonCmdletBase();
            
            // 20131128
            //ResultAndCondition =
            //    (common.GetControlConditionsForWildcardSearch(cmdlet, controlType, cmdlet.CaseSensitive, true) as AndCondition);
            ResultAndCondition =
                (common.GetControlConditionsForWildcardSearch(cmdlet, controlType, cmdlet.CaseSensitive));
        }
        
        private void getOrConditions(string searchString, string controlType)
        {
            ResultOrCondition = null;
            
            GetControlCmdletBase cmdlet =
                new GetControlCmdletBase {ContainsText = searchString };

            CommonCmdletBase common =
                new CommonCmdletBase();
            
            ResultOrCondition =
                (common.GetControlConditionsForExactSearch(cmdlet, controlType, cmdlet.CaseSensitive, false) as OrCondition);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType()
        {
            getAndConditions(null, null, null, "button");

            PropertyCondition propertyCondition = ResultAndCondition.GetConditions()[0] as PropertyCondition;
            if (propertyCondition != null)
                Assert.AreEqual(
                    System.Windows.Automation.ControlType.Button.Id,
                    propertyCondition.Value);
            /*
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultCondition.GetConditions()[0] as PropertyCondition).Value);
            */

            Assert.AreEqual(
                Condition.TrueCondition,
                (ResultAndCondition.GetConditions()[1]));
           
           //Assert.ForAll(ResultCondition.GetConditions(), x => x is PropertyCondition | ((x as PropertyCondition).Value as ControlType).Id == System.Windows.Automation.ControlType.Button.Id | (x as Condition) == Condition.TrueCondition);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name()
        {
            const string expectedName = "name1";
            
            getAndConditions(expectedName, null, null, "button");
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_AutomationId()
        {
            const string expectedAutomationId = "au1";
            
            getAndConditions(null, expectedAutomationId, null, "button");
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_ClassName()
        {
            const string expectedClassName = "className1";
            
            getAndConditions(null, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_AutomationId()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            
            getAndConditions(expectedName, expectedAutomationId, null, "button");

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_ClassName()
        {
            const string expectedName = "name1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, null, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_AutomationId_ClassName()
        {
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(null, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ControlType_Name_AutomationId_ClassName()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, expectedAutomationId, expectedClassName, "button");

            Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                System.Windows.Automation.ControlType.Button.Id,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }

        // =========================
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void No_conditions()
        {
            getAndConditions(null, null, null, "");
            
            Assert.AreEqual(
                Condition.TrueCondition,
                (ResultAndCondition.GetConditions()[0]));
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name()
        {
            const string expectedName = "name1";
            
            getAndConditions(expectedName, null, null, "");
            
            Assert.AreEqual(
                expectedName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId()
        {
            const string expectedAutomationId = "au1";
            
            getAndConditions(null, expectedAutomationId, null, "");
            
            Assert.AreEqual(
                expectedAutomationId,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ClassName()
        {
            const string expectedClassName = "className1";
            
            getAndConditions(null, null, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                (ResultAndCondition.GetConditions()[0] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            
            getAndConditions(expectedName, expectedAutomationId, null, "");
            
            Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_ClassName()
        {
            const string expectedName = "name1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, null, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void AutomationId_ClassName()
        {
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(null, expectedAutomationId, expectedClassName, "");

            Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
        }
        
        [Test]
        [Description("CommonCmdletBase.GetControlConditionsForWildcardSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void Name_AutomationId_ClassName()
        {
            const string expectedName = "name1";
            const string expectedAutomationId = "au1";
            const string expectedClassName = "className1";
            
            getAndConditions(expectedName, expectedAutomationId, expectedClassName, "");
            
            Assert.AreEqual(
                expectedClassName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedName,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedAutomationId,
                ((ResultAndCondition.GetConditions()[1] as AndCondition).GetConditions()[2] as PropertyCondition).Value);
        }
        
        // ======================================================================================================
        // OrCondition (ContainsText)
        // ======================================================================================================
        [Test]
        //[Description("CommonCmdletBase.GetControlConditionsForExactSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ContainsText_1()
        {
            const string expectedText = "text";
            string controlTypeText = string.Empty;
            
            getOrConditions(expectedText, controlTypeText);
            
            Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[2] as PropertyCondition).Value);
        }
        
        [Test]
        //[Description("CommonCmdletBase.GetControlConditionsForExactSearch(HasControlInputCmdletBase, string)")]
        [Category("Fast")]
        public void ContainsTextControlType_1()
        {
            const string expectedText = "text";
            const string controlTypeText = "button";
            
            getOrConditions(expectedText, controlTypeText);
            
            Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[0] as PropertyCondition).Value);

            Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[1] as PropertyCondition).Value);
            
            Assert.AreEqual(
                expectedText,
                ((ResultOrCondition.GetConditions()[1] as OrCondition).GetConditions()[2] as PropertyCondition).Value);
        }
    }
}
