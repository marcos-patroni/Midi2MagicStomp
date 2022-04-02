using System.Runtime.InteropServices;


public class ListViewWrapper
{
    IntPtr _hwnd;

    private const int LVM_FIRST = 0x1000;
    private const int LVM_GETSELECTEDCOUNT = LVM_FIRST + 50;
    private const int LVIS_SELECTED = 0x0002;
    private const int LVM_GETITEMSTATE = LVM_FIRST + 44;

    private const int LVM_GETITEMTEXT = LVM_FIRST + 45;
    private const int LVIF_TEXT = 0x0001;


    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string sClass, string sWindow);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("User32.dll")]
    static extern int SetForegroundWindow(IntPtr point);


    public void AlteraPrograma(int nuPrograma)
    {
        int iseleciona = nuPrograma;
        int atual = -1;
        //Application.DoEvents();
        if (!IsRunning())
            throw new Exception("Open Sound Editor for MAGICSTOMP as administrator and load your patches. Select first item and active the monitor.");
        for (int i = 0; i < 100; i++)
        {
            if (IsItemSelected(i))
            {
                atual = i;
                break;
            }
        }
        iseleciona--;
        if (iseleciona == atual)
            return;
        //Application.DoEvents();
        MonitorOnOff();
        //Application.DoEvents();

        if (iseleciona > atual)
        {
            for (int i = atual; i < iseleciona; i++)
            {
                if (i == iseleciona - 1)
                {
                    //Application.DoEvents();
                    MonitorOnOff();
                    //Application.DoEvents();
                }
                SetaAbaixo();
                //Application.DoEvents();
            }
        }
        else
        {
            for (int i = iseleciona; i < atual; i++)
            {
                if (i == atual - 1)
                {
                    //Application.DoEvents();
                    MonitorOnOff();
                    //Application.DoEvents();
                }
                SetaAcima();
            }
        }
    }

    private void MonitorOnOff()
    {
        SetForegroundWindow(_hwnd);
        SendKeys.SendWait("%(u)");
        SendKeys.SendWait("m");
    }
    private void SetaAcima()
    {
        SetForegroundWindow(_hwnd);
        SendKeys.SendWait("{UP}");
        SendKeys.SendWait("{ESC}");
    }
    private void SetaAbaixo()
    {
        SetForegroundWindow(_hwnd);
        SendKeys.SendWait("{DOWN}");
        SendKeys.SendWait("{ESC}");
    }
    internal ListViewWrapper()
    {
        IntPtr _hwndPrincipal;
        _hwndPrincipal = FindWindow("AfxFrameOrView42", "Sound Editor for MAGICSTOMP : ");
        if (_hwndPrincipal == IntPtr.Zero)
        {
            throw new Exception("Open Sound Editor for MAGICSTOMP as administrator and load your patches. Select first item and active the monitor.");
        }
        IntPtr c1 = FindWindowEx(_hwndPrincipal, IntPtr.Zero, "#32770", "");
        IntPtr c2 = FindWindowEx(c1, IntPtr.Zero, "AfxFrameOrView42s", "");
        IntPtr c3 = FindWindowEx(c2, IntPtr.Zero, "#32770", "");
        IntPtr c4 = FindWindowEx(c3, IntPtr.Zero, "Static", "");
        IntPtr c5 = FindWindowEx(c4, IntPtr.Zero, "SysListView32", "");
        _hwnd = c5;
    }
    private bool IsRunning()
    {
        IntPtr _hwndPrincipal;
        _hwndPrincipal = FindWindow("AfxFrameOrView42", "Sound Editor for MAGICSTOMP : ");
        if (_hwndPrincipal == IntPtr.Zero)
            return false;
        else
            return true;
    }
    private bool IsItemSelected(int itemIdx)
    {
        return (LVIS_SELECTED & SendMessage(_hwnd, LVM_GETITEMSTATE, new IntPtr(itemIdx), new IntPtr(LVIS_SELECTED)).ToInt32()) != 0;
    }


}
