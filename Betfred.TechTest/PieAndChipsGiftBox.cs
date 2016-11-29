using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfred.TechTest
{
    public class PieAndChipsGiftBox : ShoppingCartItem
    {
        private readonly Chips _chips;
        private readonly Pie _pie;

        public PieAndChipsGiftBox(Chips chips, Pie pie)
        {
            _chips = chips;
            _pie = pie;
        }
        
        public override decimal Price
        {
            get { return 3m; }
        }

        public override decimal CalculatedPrice
        {
            get
            {
                var piePrice = _pie.CalculatedPrice;
                var chipsPrice = _chips.CalculatedPrice;

                return (piePrice + chipsPrice) * 0.75m;
            }
        }
    }
}
