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
    [LocDisplayName("Pumpkin")]
    [Weight(100)]
    [Yield(typeof(PumpkinItem), typeof(FarmingSkill), new float[] {1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f})]
    [Crop]
    [Tag("Crop", 1)]
    [Tag("Harvestable", 1)]
    [Tag("Fruit", 1)]
    [Tag("Raw Food", 1)]
    [Ecopedia("Food", "Produce", createAsSubPage: true)]
    public partial class PumpkinItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Round and large.");

        public override float Calories                  => 34;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 5, Fat = 0, Protein = 1, Vitamins = 2};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(72);
    }

}
