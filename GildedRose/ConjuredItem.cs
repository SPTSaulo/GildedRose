using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class ConjuredItem : MyItem {
        public ConjuredItem(int quality, int sellIn) : base("Conjured", quality, sellIn) {

        }

        public override void UpdateItem() {
            Quality = IsItemExpired() 
                ? DecreaseQualityValue(DecreaseValue * 4) 
                : DecreaseQualityValue(DecreaseValue * 2);
            SellIn -= DecreaseValue;
        }
    }
}
