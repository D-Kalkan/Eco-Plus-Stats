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
    [LocDisplayName("Corn Starch")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CornStarchItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Obtained from the endosperm of the kernal, cornstarch can be used as a thickening agent for sauces.");
        
        public override float Calories                  => 10;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(48);
    }


    [RequiresSkill(typeof(MillingSkill), 1)]
    public partial class CornStarchRecipe : RecipeFamily
    {
        public CornStarchRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CornStarch",  //noloc
                Localizer.DoStr("Corn Starch"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CornItem), 10, typeof(MillingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CornStarchItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(15, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornStarchRecipe), 8, typeof(MillingSkill), typeof(CuttingEdgeCookingFocusedSpeedTalent), typeof(CuttingEdgeCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Corn Starch"), typeof(CornStarchRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}