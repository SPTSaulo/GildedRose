using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml;

namespace GildedRose {
    public class GildedRose{
        IList<MyItem> Items;

        public GildedRose(IList<MyItem> items) {
            this.Items = items;
        }

        public void UpdateItemProperties() {
            foreach (var item in Items) {
                item.UpdateItem();
            }
        }
    }
}
