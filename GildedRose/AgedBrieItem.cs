using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class AgedBrieItem : MyItem {

        public AgedBrieItem(int quality, int sellIn) : base("Aged Brie", quality, sellIn) {
        }

        public override void UpdateItem() {
            Quality = IsItemExpired()
                ? IncreaseQualityValue(IncreasesValue * 2)
                : IncreaseQualityValue(IncreasesValue);
            SellIn -= DecreaseValue;
        }
    }
}
