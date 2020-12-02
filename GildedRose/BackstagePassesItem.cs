using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class BackstagePassesItem : MyItem {

        public BackstagePassesItem(int quality, int sellIn) : base("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) {
        }

        public override void UpdateItem() {
            Quality = IncreaseQualityByPassedDays();
            SellIn -= DecreaseValue;
        }

        private int IncreaseQualityByPassedDays() {
            if (IsItemExpired()) return MinQualityValue;
            if (IsConcertBeSoon()) {
                return GetItemExtraValue();
            }
            return Quality + IncreasesValue;
        }

        private bool IsConcertBeSoon() {
            if (SellIn <= DaysForDuplicateIncreaseValue) return true;
            return false;
        }

        private int GetItemExtraValue() { 
            if (SellIn <= DaysForDuplicateIncreaseValue && SellIn >= DaysForTriplicateIncreaseValue) return IncreaseQualityValue(IncreasesValue * 2);
            if (SellIn <= DaysForTriplicateIncreaseValue) return IncreaseQualityValue(IncreasesValue * 3);
            return 0;
        }

        
    }
}
