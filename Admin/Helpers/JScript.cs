using Microsoft.JSInterop;

public class JScript
{
    private readonly IJSRuntime _script;
    public JScript(IJSRuntime script)
    {
        _script = script;
    }

    public async Task RenderDatetable()
    {
        await _script.InvokeVoidAsync("RenderDatetable");
    }
    public async Task<bool> Confirm(string message)
    {
        return await _script.InvokeAsync<bool>("confirm", message);
    }
    public async Task Redirect(string URL)
    {
        await _script.InvokeVoidAsync("Redirect", URL, "_self");
    }
    public async Task RedirectBlank(string URL)
    {
        await _script.InvokeVoidAsync("Redirect", URL, "_blank");
    }
    public async Task SaveAsFile(string fileName, MemoryStream stream)
    {
        await _script.InvokeVoidAsync("SaveAsFile", fileName, Convert.ToBase64String(stream.ToArray()));
    }
}