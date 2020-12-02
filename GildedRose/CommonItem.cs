using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class CommonItem : ItemAdapter {
        public CommonItem(string name, int quality, int sellIn) : base(name, quality, sellIn) {
        }

        public override void UpdateItem() {
            item.Quality = IsItemExpired()
                ? DecreaseQualityValue(DecreaseValue * 2)
                : DecreaseQualityValue(DecreaseValue);
            item.SellIn -= DecreaseValue;
        }

    }
}
