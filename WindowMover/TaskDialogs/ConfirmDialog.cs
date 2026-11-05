namespace WindowMover.TaskDialogs;

public static class InformationalDialog
{
    public static void Create(string caption, string heading, string okText, Form? owner = null)
    {
        TaskDialogButton okButton = new(okText) { Tag = DialogResult.OK };

        var buttons = new TaskDialogButtonCollection { okButton };

        TaskDialogPage page = new()
        {
            SizeToContent = true,
            Caption = caption,
            Heading = heading,
            Buttons = buttons,
            Icon = TaskDialogIcon.Information
        };

        TaskDialogButton result;
        if (owner != null)
            result = TaskDialog.ShowDialog(owner, page);
        else
            result = TaskDialog.ShowDialog(page);
    }
}
