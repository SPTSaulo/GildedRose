using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class ConjuredItem : ItemAdapter {
        public ConjuredItem(int quality, int sellIn) : base("Conjured", quality, sellIn) {

        }

        public override void UpdateItem() {
            item.Quality = IsItemExpired() 
                ? DecreaseQualityValue(DecreaseValue * 4) 
                : DecreaseQualityValue(DecreaseValue * 2);
            item.SellIn -= DecreaseValue;
        }
    }
}
