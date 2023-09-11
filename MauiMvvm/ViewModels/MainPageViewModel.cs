using System.Net.Http.Json;
using MauiMvvm.Models;
using System.Windows.Input;

namespace MauiMvvm.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    private HttpClient _httpClient;
    private Item? _item;
    public Item? Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public EventHandler OnEntryCompleted { get; set; }
    
    
    public MainPageViewModel(Item item)
    {
        _httpClient = new HttpClient();
        
        Item = item;
        
        OnEntryCompleted = (sender, args) =>
        {
            try
            {
                var text = ((Entry)sender).Text;

                // создаем JsonContent
                JsonContent content = JsonContent.Create(new UserCredentials
                {
                    User = text
                });

                var nextLaunchSerialized = _httpClient.PostAsync(
                    "http://localhost:7071" + " /api/data",
                    content).Result;
                Console.WriteLine(nextLaunchSerialized.Content);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        };
    }
    
    
    public class UserCredentials
    {
        public string User { get; set; }
    }
}
