using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class AgedBrieItem : ItemAdapter {

        public AgedBrieItem(int quality, int sellIn) : base("Aged Brie", quality, sellIn) {
        }

        public override void UpdateItem() {
            item.Quality = IsItemExpired()
                ? IncreaseQualityValue(IncreasesValue * 2)
                : IncreaseQualityValue(IncreasesValue);
            item.SellIn -= DecreaseValue;
        }
    }
}
