using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6.Models;

public partial class Purchase : ObservableValidator
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    [Required(ErrorMessage = "Data zakupu jest wymagana")]
    private DateTime dateTime =DateTime.Today;

    [ObservableProperty]
    [Required(ErrorMessage = "Nazwa zakupu jest wymagana")]
    private string title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GrossPrice))]
    [Required(ErrorMessage = "Ilość jest wymagana")]
    [Range(0.0, 9999.99, ErrorMessage = "Ilość spoza dopuszczalnego zakresu.")]
    [Column(TypeName = "decimal(6, 2)")]
    private decimal amount;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GrossPrice))]
    [Required(ErrorMessage = "Cena jednostkowa jest wymagana")]
    [Range(0.0, 9999.99, ErrorMessage = "Cena jednostkowa spoza dopuszczalnego zakresu.")]
    [Column(TypeName = "decimal(6, 2)")]
    private decimal unitPrice;

    public decimal GrossPrice => UnitPrice * Amount;

    public bool Validate()
    {
        ValidateAllProperties();
        return !HasErrors;
    }
}