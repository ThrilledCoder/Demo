namespace Demo.Web.Components.Pages;

public partial class FilesUpAndDown
{
    private readonly List<string> fileUrls = [];

    protected override Task OnInitializedAsync()
    {
        var files = Directory.GetFiles(Environment.CurrentDirectory + "\\files", "*.jpg");
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            fileUrls.Add(fileName);
        }
        return base.OnInitializedAsync();
    }

    private Task Calculate()
    {
        var files = Directory.GetFiles(Environment.CurrentDirectory + "\\files", "*.*");
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            fileUrls.Add(fileName);
        }
        return Task.CompletedTask;
    } 
}

