namespace WindowMover.TaskDialogs;

public static class QuestionDialog
{
    public static void Create(string caption, string heading, string yesText, string noText, Action yesAction, Action noAction, Form? owner = null)
    {
        TaskDialogButton yesButton = new(yesText) { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new(noText) { Tag = DialogResult.No };

        var buttons = new TaskDialogButtonCollection { yesButton, noButton };

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

        if (result.Tag is DialogResult.Yes)
        {
            yesAction?.Invoke();
        }
        else
        {
            noAction?.Invoke();
        }

    }
}
