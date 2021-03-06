using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using System.Text.RegularExpressions;

namespace BusinessOneBarcodeGenerator
{

    [FormAttribute("1470000020", "Bar Codes.b1f")]
    class Bar_Codes : SystemFormBase
    {
        public Bar_Codes()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Button Button0;

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (Regex.IsMatch(EditText0.Value, "[ ^ 0-9]{12}"))
            {
                if (EditText0.Value.Length == 12)
                {
                    var barcode = BarcodeGenerator.GenerateEAN13(long.Parse(EditText0.Value));
                    EditText0.Value = barcode.ToString();
                }
                else
                {
                    Application.SBO_Application.SetStatusBarMessage("barcode must be at least 12 digits", SAPbouiCOM.BoMessageTime.bmt_Medium);
                }
            }
            else
            {
                Application.SBO_Application.SetStatusBarMessage("enter only number", SAPbouiCOM.BoMessageTime.bmt_Medium);
            }
        }
    }
}
