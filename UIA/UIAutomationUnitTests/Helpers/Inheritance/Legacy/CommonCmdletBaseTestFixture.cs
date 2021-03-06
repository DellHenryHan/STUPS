﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 02.02.2012
 * Time: 1:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using MbUnit.Framework;// using Xunit;//using MbUnit.Framework;// using Xunit; // using MbUnit.Framework;// using Xunit;
    using System.Windows.Automation;
    using UIAutomation;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    [MbUnit.Framework.TestFixture] // [TestFixture(Description="CommonCmdletBase test")]
    [Ignore("Incompatible with the contemporary code")]
    public class CommonCmdletBaseTestFixture
    {
        UIAutomation.GetControlCmdletBase cmdlet = null;
        UIAutomation.CommonCmdletBase cmdletBase = null;
        
        private void checkConditionsArray(
            string controlType,
            string controlTypeProperty,
            string controlTypeValue)
        {
            Condition[] conditions = null;
            cmdlet = 
                new UIAutomation.Commands.GetUiaControlCommand();
            cmdletBase = 
                new UIAutomation.GetControlCmdletBase();
            
            Condition condition =
                // cmdlet.GetWildcardSearchCondition(cmdlet);
                ControlSearcher.GetWildcardSearchCondition(
                    new ControlSearcherData {
                        // completely new
                        Name = cmdlet.Name,
                        AutomationId = cmdlet.AutomationId,
                        Class = cmdlet.Class,
                        Value = cmdlet.Value,
                        ControlType = cmdlet.ControlType
                    });
            conditions = ((AndCondition)condition).GetConditions();
            foreach (Condition cond in conditions) {
                if ((cond as PropertyCondition) != null) {
                    MbUnit.Framework.Assert.AreEqual(
                        controlTypeProperty, 
                        (cond as PropertyCondition).Property.ProgrammaticName);
                    MbUnit.Framework.Assert.AreEqual(
                        controlTypeValue, 
                        (cond as PropertyCondition).Value.ToString());
                } else {
                    MbUnit.Framework.Assert.AreEqual(cond, Condition.TrueCondition);
                }
            }
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeButton()
        {
            checkConditionsArray(
                "Button",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50000");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeCalendar()
        {
            checkConditionsArray(
                "Calendar",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50001");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeCheckBox()
        {
            checkConditionsArray(
                "CheckBox",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50002");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeComboBox()
        {
            checkConditionsArray(
                "ComboBox",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50003");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeCustom()
        {
            checkConditionsArray(
                "Custom",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50025");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeDataGrid()
        {
            checkConditionsArray(
                "DataGrid",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50028");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeDataItem()
        {
            checkConditionsArray(
                "DataItem",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50029");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeDocument()
        {
            checkConditionsArray(
                "Document",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50030");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeEdit()
        {
            checkConditionsArray(
                "Edit",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50004");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeHyperlink()
        {
            checkConditionsArray(
                "Hyperlink",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50005");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeList()
        {
            checkConditionsArray(
                "List",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50008");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeRadioButton()
        {
            checkConditionsArray(
                "RadioButton",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50013");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeTable()
        {
            checkConditionsArray(
                "Table",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50036");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeText()
        {
            checkConditionsArray(
                "Text",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50020");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeTree()
        {
            checkConditionsArray(
                "Tree",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50023");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeTreeItem()
        {
            checkConditionsArray(
                "TreeItem",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50024");
        }
        
        [Test]// [Fact] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeWindow()
        {
            checkConditionsArray(
                "Window",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50032");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
// // MiddleLevelCode.DisposeRunspace();
            cmdlet = null;
        }
    }
}
