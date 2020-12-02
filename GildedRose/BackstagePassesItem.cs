using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public class BackstagePassesItem : ItemAdapter {

        public BackstagePassesItem(int quality, int sellIn) : base("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) {
        }

        public override void UpdateItem() {
            item.Quality = IncreaseQualityByPassedDays();
            item.SellIn -= DecreaseValue;
        }

        private int IncreaseQualityByPassedDays() {
            if (IsItemExpired()) return MinQualityValue;
            if (IsConcertBeSoon()) return GetItemExtraValue();
            return item.Quality + IncreasesValue;
        }

        private bool IsConcertBeSoon() {
            if (item.SellIn <= DaysForDuplicateIncreaseValue) return true;
            return false;
        }

        private int GetItemExtraValue() { 
            if (item.SellIn <= DaysForDuplicateIncreaseValue && item.SellIn >= DaysForTriplicateIncreaseValue) return IncreaseQualityValue(IncreasesValue * 2);
            if (item.SellIn <= DaysForTriplicateIncreaseValue) return IncreaseQualityValue(IncreasesValue * 3);
            return 0;
        }

        
    }
}
