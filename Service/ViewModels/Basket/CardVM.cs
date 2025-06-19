using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Basket;

public class CardVM
{
    public List<BasketItemVM> Prroduct { get; set; } = new List<BasketItemVM>();
    public int Count { get; set; }
    public decimal TotalAmount { get; set; }
}
