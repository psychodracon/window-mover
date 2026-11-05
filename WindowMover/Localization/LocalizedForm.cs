using WindowMover.Classes;

namespace WindowMover.Localization;

public class LocalizedForm : Form
{
    const string languageTag = "l10n:";
    public void LocalizeControls()
    {
        List<Control> controls = FindAllControlsWithTag(languageTag);

        foreach (Control control in controls)
        {
            Localize<Control>(control);
        }

        foreach (DataGridView dataGridView in FindAllControlsOfType(typeof(DataGridView)))
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                Localize<DataGridViewColumn>(column);
            }
        }
    }

    private void Localize<T>(T control) where T : class
    {
        string? tag = Helpers.GetPropertyValue<string>(control, "Tag");
        if (tag != null)
        {
            string? translatedText = JsonStringLocalizer.Instance.GetString(tag.Split(languageTag)[1]);
            if (control is Control c)
            {
                c.Text = translatedText != null ? translatedText : c.Text;
            }
            else if (control is DataGridViewColumn column)
            {
                column.HeaderText = translatedText != null ? translatedText : column.HeaderText;
            }

        }
    }

    private List<Control> FindAllControlsWithTag(string tag)
    {
        List<Control> result = FindAllControlsWithTag(this.Controls, tag);
        if (this.Tag != null && this.Tag.ToString() != null) result.Add(this);
        result.AddRange(FindAllControlsWithTag(this.Controls, tag));

        return result;
    }

    private List<Control> FindAllControlsWithTag(System.Windows.Forms.Control.ControlCollection controls, string tag)
    {
        List<Control> result = new List<Control>();

        foreach (Control item in controls)
        {
            if (item.Tag?.ToString()?.Contains(tag) == true)
            {
                result.Add(item);
            }
            if (item.HasChildren)
            {
                List<Control> controlsWithTag = FindAllControlsWithTag(item.Controls, tag);
                result.AddRange(controlsWithTag);
            }
        }

        return result;
    }

    private List<Control> FindAllControlsOfType(Type type)
    {
        return FindAllControlsOfType(this.Controls, type);
    }

    private List<Control> FindAllControlsOfType(System.Windows.Forms.Control.ControlCollection controls, Type type)
    {
        List<Control> result = new List<Control>();

        foreach (Control item in controls)
        {
            if (item.GetType() == type)
            {
                result.Add(item);
            }
            if (item.HasChildren)
            {
                List<Control> controlsWithType = FindAllControlsOfType(item.Controls, type);
                result.AddRange(controlsWithType);
            }
        }

        return result;
    }
}
