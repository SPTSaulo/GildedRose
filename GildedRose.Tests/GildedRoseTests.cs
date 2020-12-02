using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests {
    class GildedRoseTests {
        
        [Test]
        public void CheckItemQualityDecrease() {
            CommonItem chocolateChipsItemAdapter = new CommonItem("Chocolate Chips", 20, 90);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(chocolateChipsItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();
            ItemAdapter chocolateChipsItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Chocolate Chips");
            chocolateChipsItemAdapterUpdated.item.Quality.Should().Be(19);
        }

        [Test]
        public void CheckItemQualityDecreaseTwiceFast() {
            CommonItem scannerItemAdapter = new CommonItem("Scanner", 50, -1);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(scannerItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter agedBrieItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Scanner");
            agedBrieItemAdapterUpdated.item.Quality.Should().Be(48);
        }

        [Test]
        public void CheckItemSellInDecrease() {
            CommonItem chairItemAdapter = new CommonItem("Chair", 40, 10);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(chairItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter chairItemAdapterUpdated = items.First(itemAdapter => "Chair" == itemAdapter.item.Name);
            chairItemAdapterUpdated.item.SellIn.Should().Be(9);
        }

        [Test]
        public void CheckSulfurasQualityNotDecrease() {
            SulfurasItem sulfurasItemAdapter = new SulfurasItem();
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(sulfurasItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter sulfurasItemAdapterUdapted = items.First(itemAdapter => itemAdapter.item.Name == "Sulfuras, Hand of Ragnaros");
            sulfurasItemAdapterUdapted.item.Quality.Should().Be(80);
        }

        [Test]
        public void CheckSulfurasSellInNotDecrease() {
            SulfurasItem sulfurasItemAdapter = new SulfurasItem();
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(sulfurasItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter sulfurasItemAdapterUdapted = items.First(itemAdapter => itemAdapter.item.Name == "Sulfuras, Hand of Ragnaros");
            sulfurasItemAdapterUdapted.item.SellIn.Should().Be(0);
        }

        [Test]
        public void CheckItemQualityMinValue() {
            CommonItem gameControllerItemAdapter = new CommonItem("Game Controller", 0, -2);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(gameControllerItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter gameControllerItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Game Controller");
            gameControllerItemAdapterUpdated.item.Quality.Should().Be(0);
        }

        [Test]
        public void CheckItemQualityMaxValue() {
            AgedBrieItem agedBrieItemAdapter = new AgedBrieItem(50, -2);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(agedBrieItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter agedBrieItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Aged Brie");
            agedBrieItemAdapterUpdated.item.Quality.Should().Be(50);
        }

        [Test]
        public void CheckAgedBrieQualityIncreases() {
            AgedBrieItem agedBrieItemAdapter = new AgedBrieItem(30,10);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(agedBrieItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter agedBrieItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Aged Brie");
            agedBrieItemAdapterUpdated.item.Quality.Should().Be(31);
        }

        [Test]
        public void CheckBackstagesPassesQualityIncreasesBy1() {
            BackstagePassesItem backstagesPassesItemAdapter = new BackstagePassesItem(10,20);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(backstagesPassesItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter backstagesPassesItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemAdapterUpdated.item.Quality.Should().Be(11);
        }

        [Test]
        public void CheckBackstagesPassesQualityIncreasesBy2() {
            BackstagePassesItem backstagesPassesItemAdapter = new BackstagePassesItem(10,10);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(backstagesPassesItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter backstagesPassesItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemAdapterUpdated.item.Quality.Should().Be(12);
        }

        [Test]
        public void CheckBackstagesPassesQualityIncreasesBy3() {
            BackstagePassesItem backstagesPassesItemAdapter = new BackstagePassesItem(10,3);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(backstagesPassesItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter backstagesPassesItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemAdapterUpdated.item.Quality.Should().Be(13);
        }

        [Test]
        public void CheckBackstagesPassesLosesQuality() {
            BackstagePassesItem backstagesPassesItemAdapter = new BackstagePassesItem(10,-1);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(backstagesPassesItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter backstagesPassesItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Backstage passes to a TAFKAL80ETC concert");
            backstagesPassesItemAdapterUpdated.item.Quality.Should().Be(0);
        }

        [Test]
        public void CheckConjuredLosesQuality() {
            ConjuredItem conjuredItemAdapter = new ConjuredItem(30, 20);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(conjuredItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter conjuredItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Conjured");
            conjuredItemAdapterUpdated.item.Quality.Should().Be(28);
        }

        [Test]
        public void CheckConjuredLoseQualityTwiceFast() {
            ConjuredItem conjuredItemAdapter = new ConjuredItem(30, -1);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(conjuredItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter conjuredItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Conjured");
            conjuredItemAdapterUpdated.item.Quality.Should().Be(26);
        }

        [Test]
        public void CheckConjuredSellInDecrease() {
            ConjuredItem conjuredItemAdapter = new ConjuredItem(30, -1);
            List<ItemAdapter> items = new List<ItemAdapter>();
            items.Add(conjuredItemAdapter);
            GildedRose gildedRose = new GildedRose(items);

            gildedRose.UpdateItemProperties();

            ItemAdapter conjuredItemAdapterUpdated = items.First(itemAdapter => itemAdapter.item.Name == "Conjured");
            conjuredItemAdapterUpdated.item.SellIn.Should().Be(-2);
        }
    }
}
