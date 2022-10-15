﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Cookeina Mushrooms")]
    [Weight(10)]
    [Yield(typeof(CookeinaMushroomsItem), typeof(FarmingSkill), new float[] {1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f})]
    [Crop]
    [Tag("Crop", 1)]
    [Tag("Harvestable", 1)]
    [Tag("Fungus", 1)]
    [Tag("Raw Food", 1)]
    [Ecopedia("Food", "Produce", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CookeinaMushroomsItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Tiny Cup Mushrooms.");

        public override float Calories                  => 20;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 2, Fat = 1, Protein = 4, Vitamins = 1};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(48);
    }

}
