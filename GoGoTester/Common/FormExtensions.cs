using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoGoTester.Common
{
    static class FormExtensions
    {
        //static public void UIThread(this Form form, MethodInvoker code)
        //{
        //    if (form.InvokeRequired)
        //    {
        //        form.Invoke(code);
        //        return;
        //    }
        //    code.Invoke();
        //}

        public static void UIThread(this Control invokerControl, MethodInvoker uiOperationMethod)
        {
            if (invokerControl.InvokeRequired)
            {
                invokerControl.Invoke(uiOperationMethod);
                return;
            }

            uiOperationMethod.Invoke();
        }
    }
}
