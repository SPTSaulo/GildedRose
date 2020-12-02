using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose {
    public abstract class MyItem : Item{
        protected const int MaxQualityValue = 50;
        protected const int MinQualityValue = 0;
        protected const int DecreaseValue = 1;
        protected const int IncreasesValue = 1;
        protected const int DaysForDuplicateIncreaseValue = 10;
        protected const int DaysForTriplicateIncreaseValue = 5;


        public MyItem(string name, int quality, int sellIn) {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        protected bool IsItemExpired() {
            if (SellIn < 0) return true;
            return false;
        }

        protected int IncreaseQualityValue(int value) {
            if (Quality + value <= MaxQualityValue) {
                return Quality + value;
            }
            return MaxQualityValue;
        }

        protected int DecreaseQualityValue(int value) {
            if (Quality - value >= MinQualityValue) {
                return Quality - value;
            }
            return MinQualityValue;
        }

        public abstract void UpdateItem();

    }
}
