namespace RefactoringLab.Part02.Reports;

// Template Method: the steps and their ORDER are written here, in one place.
// Subclasses only supply the step that is different: Format.
public abstract class ReportExporter
{
    // The template method. Not virtual, so no subclass can change the order.
    public void Export(string path)
    {
        var rows = Load();
        if (!Validate(rows))
            throw new InvalidOperationException("Invalid data");
        var content = Format(rows);
        Save(path, content);
    }

    // Shared steps - written once instead of three times.
    protected virtual List<string[]> Load() =>
    [
        ["Id", "Name"],
        ["1", "Keyboard"],
        ["2", "Mouse"]
    ];

    protected virtual bool Validate(List<string[]> rows) =>
        rows.Count > 1 && rows[0].Length > 0;

    private void Save(string path, string content) =>
        File.WriteAllText(path, content);

    // The only step that is different for every exporter.
    protected abstract string Format(List<string[]> rows);
}