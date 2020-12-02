using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class CommonItem : MyItem {
        public CommonItem(string name, int quality, int sellIn) : base(name, quality, sellIn) {
        }

        public override void UpdateItem() {
            Quality = IsItemExpired()
                ? DecreaseQualityValue(DecreaseValue * 2)
                : DecreaseQualityValue(DecreaseValue);
            SellIn -= DecreaseValue;
        }

    }
}
