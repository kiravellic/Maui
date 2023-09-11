using MauiMvvm.ViewModels;

namespace MauiMvvm.Models;

public class Item : ViewModelBase
{
    private string value;
    public string Value
    {
        get => value;
        set => SetProperty(ref this.value, value);
    }
}
