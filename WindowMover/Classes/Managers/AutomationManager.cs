using WinApiEnums = WindowMover.Classes.Wrappers.Enums;
using Marshal = System.Runtime.InteropServices.Marshal;

namespace WindowMover.Classes.Managers;

public class AutomationManager
{
    private WindowManager windowManager;
    private WindowHandlerManager windowHandlerManager;
    private nint hookHandle;

    private static WinApiWrapper.HookProc? hookProc;
    public AutomationManager(WindowManager windowManager, WindowHandlerManager windowHandlerManager)
    {
        this.windowManager = windowManager;
        this.windowHandlerManager = windowHandlerManager;
    }

    public void SubscribeToEvents()
    {
        if (hookHandle == nint.Zero)
        {
            hookProc = new WinApiWrapper.HookProc(HookCallback);
            hookHandle = windowManager.SetWindowsHookEx(WinApiEnums.Hooks.WH_KEYBOARD_LL, hookProc, nint.Zero, 0);

            if (hookHandle == nint.Zero)
            {
                Console.WriteLine("Ostatni błąd: {0}", windowManager.GetLastError());
            }
        }
    }

    public void UnsubscribeFromEvents()
    {
        windowManager.UnhookWinEvent(hookHandle);
    }

    private nint HookCallback(int code, nint wParam, nint lParam)
    {
        if (code >= 0 & wParam == (nint)WinApiEnums.KeyboardInput.WM_KEYDOWN || wParam == (nint)WinApiEnums.KeyboardInput.WM_SYSKEYDOWN)
        {
            WinApiWrapper.KBDLLHOOKSTRUCT kbd = Marshal.PtrToStructure<WinApiWrapper.KBDLLHOOKSTRUCT>(lParam)!;
            Console.WriteLine("Przycisk: {0}, flagi: {1}", kbd.vkCode, kbd.flags);
            if (kbd.vkCode == (uint)WinApiEnums.KeyboardKeys.VK_TAB && kbd.flags == (WinApiWrapper.KBDLLHOOKSTRUCTFlags)WinApiEnums.KeyboardFlags.LLKHF_ALTDOWN
                || kbd.vkCode == (uint)WinApiEnums.KeyboardKeys.VK_LWIN
                || kbd.vkCode == (uint)WinApiEnums.KeyboardKeys.VK_RWIN)
            {
                windowHandlerManager.RemoveTopMostStyleFromWindows(windowManager);
            }
        }

        return windowManager.CallNextHookEx(hookHandle, code, wParam, lParam);
    }
}