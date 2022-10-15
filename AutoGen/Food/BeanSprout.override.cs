﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Bean Sprout")]
    [Weight(10)]
    [Yield(typeof(BeanSproutItem), typeof(FarmingSkill), new float[] {1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f})]
    [Crop]
    [Tag("Crop", 1)]
    [Tag("Harvestable", 1)]
    [Tag("Raw Food", 1)]
    [Ecopedia("Food", "Produce", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeanSproutItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("The small sprouts from a grown bean plant.");

        public override float Calories                  => 10;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 2, Fat = 0, Protein = 1, Vitamins = 5};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(48);
    }


    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class BeanSproutRecipe : RecipeFamily
    {
        public BeanSproutRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "BeanSprout",  //noloc
                Localizer.DoStr("Bean Sprout"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BeansItem), 2, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BeanSproutItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FarmingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeanSproutRecipe), 1, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bean Sprout"), typeof(BeanSproutRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
