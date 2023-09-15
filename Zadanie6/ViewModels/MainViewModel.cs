using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Zadanie6.Data;
using Zadanie6.Models;

namespace Zadanie6.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly Zadanie6Context context;

    public MainViewModel(Zadanie6Context context)
    {
        this.context = context;
        Purchases = context.Purchases
            .LoadAsync()
            .ContinueWith(p => context.Purchases.Local.ToObservableCollection());
    }
    [RelayCommand]
    private async Task AddPurchaseAsync()
    {
        if (NewPurchase.Validate())
        {
            context.Add(NewPurchase);
            await context.SaveChangesAsync();
            NewPurchase = new Purchase();
        }
    }
    [RelayCommand]
    private async Task DeletePurchaseAsync(Purchase purchase)
    {
        context.Remove(purchase);
        await context.SaveChangesAsync();
    }

  

    [ObservableProperty]
    private Purchase newPurchase = new Purchase();

    private TaskNotifier<ObservableCollection<Purchase>> purchases;
    public Task<ObservableCollection<Purchase>> Purchases
    {
        get => purchases;
        set => SetPropertyAndNotifyOnCompletion(ref purchases, value);
    }

}
