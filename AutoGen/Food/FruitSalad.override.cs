// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Fruit Salad")]
    [Weight(300)]
    [Tag("Salad", 1)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FruitSaladItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("While tomatoes are fruits, you don't usually put them in fruit salads.");
        
        public override float Calories                  => 900;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 12, Fat = 3, Protein = 4, Vitamins = 19};
    }

}