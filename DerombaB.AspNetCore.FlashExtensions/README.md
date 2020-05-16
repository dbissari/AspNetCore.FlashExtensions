### How to use
___
From Controller/PageModel :

```csharp
public async Task<IActionResult> OnGet()
{
    ...
    return RedirectToPage("./Index")
        .WithSuccessFlash("Success title", "Success body")
        .WithInfoFlash("Info title", "Info body")
        .WithWarningFlash("Warning title", "Warning body")
        .WithDangerFlash("Danger title", "Danger body");
}
```
There is also a `.WithFlash(string type, string title, string body)` to use custom types of flash messages.
Those methods are extensions of `IActionResult` and can be used then on any type of `ActionResult`.


And then from Page/View (the following code uses BS4 classes for dismissible alert) :
```csharp
...
@{
    var flashMessages = TempData.GetFlashMessages();
}
@if(flashMessages != null)
{
    @foreach (var flashMessage in flashMessages)
    {
        <div class="alert alert-@flashMessage.Type alert-dismissible" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            <strong>@flashMessage.Title</strong> @flashMessage.Body
        </div>
    }
}
...
```

**PS:** The call to `.GetFlashMessages()` function frow view to display the data end up cleaning all the flash messages of the list, not only the displayed ones.
