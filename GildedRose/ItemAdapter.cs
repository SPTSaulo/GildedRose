using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public abstract class ItemAdapter {
        protected const int MaxQualityValue = 50;
        protected const int MinQualityValue = 0;
        protected const int DecreaseValue = 1;
        protected const int IncreasesValue = 1;
        protected const int DaysForDuplicateIncreaseValue = 10;
        protected const int DaysForTriplicateIncreaseValue = 5;

        public Item item { get; set; }

        public ItemAdapter(string name, int quality, int sellIn) {
            item = new Item() {Name = name, Quality = quality, SellIn = sellIn};
        }

        protected bool IsItemExpired() {
            if (item.SellIn < 0) return true;
            return false;
        }

        protected int IncreaseQualityValue(int value) {
            if (item.Quality + value <= MaxQualityValue) {
                return item.Quality + value;
            }
            return MaxQualityValue;
        }

        protected int DecreaseQualityValue(int value) {
            if (item.Quality - value >= MinQualityValue) {
                return item.Quality - value;
            }
            return MinQualityValue;
        }

        public abstract void UpdateItem();

    }
}
