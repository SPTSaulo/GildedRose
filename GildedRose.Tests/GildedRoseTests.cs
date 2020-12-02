using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests {
    class GildedRoseTests {
        
        [Test]
        public void CheckItemQualityDecrease() {
            CommonItem chocolateChipsItem = new CommonItem("Chocolate Chips", 20, 90);
            List<MyItem> items = new List<MyItem>();
            items.Add(chocolateChipsItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();
            MyItem chocolateChipsItemUpdated = items.First(item => item.Name == "Chocolate Chips");
            chocolateChipsItemUpdated.Quality.Should().Be(19);
        }

        [Test]
        public void CheckItemQualityDecreaseTwiceFast() {
            CommonItem scannerItem = new CommonItem("Scanner", 50, -1);
            List<MyItem> items = new List<MyItem>();
            items.Add(scannerItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem agedBrieItemUpdated = items.First(item => item.Name == "Scanner");
            agedBrieItemUpdated.Quality.Should().Be(48);
        }

        [Test]
        public void CheckItemSellInDecrease() {
            CommonItem chairItem = new CommonItem("Chair", 40, 10);
            List<MyItem> items = new List<MyItem>();
            items.Add(chairItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem chairItemUpdated = items.First(item => "Chair" == item.Name);
            chairItemUpdated.SellIn.Should().Be(9);
        }

        [Test]
        public void CheckSulfurasQualityNotDecrease() {
            SulfurasItem sulfurasItem = new SulfurasItem();
            List<MyItem> items = new List<MyItem>();
            items.Add(sulfurasItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem sulfurasItemUdapted = items.First(item => item.Name == "Sulfuras, Hand of Ragnaros");
            sulfurasItemUdapted.Quality.Should().Be(80);
        }

        [Test]
        public void CheckSulfurasSellInNotDecrease() {
            SulfurasItem sulfurasItem = new SulfurasItem();
            List<MyItem> items = new List<MyItem>();
            items.Add(sulfurasItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem sulfurasItemUdapted = items.First(item => item.Name == "Sulfuras, Hand of Ragnaros");
            sulfurasItemUdapted.SellIn.Should().Be(0);
        }

        [Test]
        public void CheckItemQualityMinValue() {
            CommonItem gameControllerItem = new CommonItem("Game Controller", 0, -2);
            List<MyItem> items = new List<MyItem>();
            items.Add(gameControllerItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem gameControllerItemUpdated = items.First(item => item.Name == "Game Controller");
            gameControllerItemUpdated.Quality.Should().Be(0);
        }

        [Test]
        public void CheckItemQualityMaxValue() {
            AgedBrieItem agedBrieItem = new AgedBrieItem(50, -2);
            List<MyItem> items = new List<MyItem>();
            items.Add(agedBrieItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem agedBrieItemUpdated = items.First(item => item.Name == "Aged Brie");
            agedBrieItemUpdated.Quality.Should().Be(50);
        }

        [Test]
        public void CheckAgedBrieQualityIncreases() {
            AgedBrieItem agedBrieItem = new AgedBrieItem(30,10);
            List<MyItem> items = new List<MyItem>();
            items.Add(agedBrieItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem agedBrieItemUpdated = items.First(item => item.Name == "Aged Brie");
            agedBrieItemUpdated.Quality.Should().Be(31);
        }

        [Test]
        public void CheckBackstagesPassesQualityIncreasesBy1() {
            BackstagePassesItem backstagesPassesItem = new BackstagePassesItem(10,20);
            List<MyItem> items = new List<MyItem>();
            items.Add(backstagesPassesItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem backstagesPassesItemUpdated = items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemUpdated.Quality.Should().Be(11);
        }

        [Test]
        public void CheckBackstagesPassesQualityIncreasesBy2() {
            BackstagePassesItem backstagesPassesItem = new BackstagePassesItem(10,10);
            List<MyItem> items = new List<MyItem>();
            items.Add(backstagesPassesItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem backstagesPassesItemUpdated = items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemUpdated.Quality.Should().Be(12);
        }

        [Test]
        public void CheckBackstagesPassesQualityIncreasesBy3() {
            BackstagePassesItem backstagesPassesItem = new BackstagePassesItem(10,3);
            List<MyItem> items = new List<MyItem>();
            items.Add(backstagesPassesItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem backstagesPassesItemUpdated = items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemUpdated.Quality.Should().Be(13);
        }

        [Test]
        public void CheckBackstagesPassesLosesQuality() {
            BackstagePassesItem backstagesPassesItem = new BackstagePassesItem(10,-1);
            List<MyItem> items = new List<MyItem>();
            items.Add(backstagesPassesItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem backstagesPassesItemUpdated = items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemUpdated.Quality.Should().Be(0);
        }

        [Test]
        public void CheckConjuredLosesQuality() {
            ConjuredItem conjuredItem = new ConjuredItem(30, 20);
            List<MyItem> items = new List<MyItem>();
            items.Add(conjuredItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem conjuredItemUpdated = items.First(item => item.Name == "Conjured");
            conjuredItemUpdated.Quality.Should().Be(28);
        }

        [Test]
        public void CheckConjuredLoseQualityTwiceFast() {
            ConjuredItem conjuredItem = new ConjuredItem(30, -1);
            List<MyItem> items = new List<MyItem>();
            items.Add(conjuredItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem conjuredItemUpdated = items.First(item => item.Name == "Conjured");
            conjuredItemUpdated.Quality.Should().Be(26);
        }

        [Test]
        public void CheckConjuredSellInDecrease() {
            ConjuredItem conjuredItem = new ConjuredItem(30, -1);
            List<MyItem> items = new List<MyItem>();
            items.Add(conjuredItem);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            MyItem conjuredItemUpdated = items.First(item => item.Name == "Conjured");
            conjuredItemUpdated.SellIn.Should().Be(-2);
        }
    }
}
