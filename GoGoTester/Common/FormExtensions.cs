using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoGoTester.Common
{
    static class FormExtensions
    {
        public static void UIThread(this Control control, MethodInvoker uiOperationMethod)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(uiOperationMethod);
            }
            else
            {
                uiOperationMethod.Invoke();
            }
        }
    }
}
