using System.Windows.Automation;

namespace WindowMover.UIAutomation.Library;

public class AutomationClient
{
    public void InvokeAutomationElement(AutomationElement automationElement)
    {
        var invokePattern = automationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        invokePattern?.Invoke();
    }
    public bool Invoke(nint windowHandle, string id)
    {
        bool result = false;

        AutomationElement mainWindow = AutomationElement.FromHandle(windowHandle);
        AutomationElementCollection items = mainWindow.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));

        foreach (AutomationElement item in items)
        {
            if (item.Current.AutomationId.Contains(id))
            {
                Console.WriteLine("Found automation element, invoking!");
                InvokeAutomationElement(item);
                result = true;
            }
        }

        return result;
    }
}
