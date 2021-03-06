// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [Serialized]
    [LocDisplayName("Liquid Nitrogen")]
    [Weight(100)]
	[Category("Hidden"),Tag("NotInBrowser")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class LiquidNitrogenItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Liquid Nitrogen");
        public override LocString DisplayDescription    => Localizer.DoStr("Useful for a quick chilling.");
        
        public override float Calories                  => 10;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
    }


    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 1)]
    public partial class LiquidNitrogenRecipe : RecipeFamily
    {
        public LiquidNitrogenRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "LiquidNitrogen",  //noloc
                Localizer.DoStr("Liquid Nitrogen"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(SteelBarItem), 2, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<LiquidNitrogenItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LiquidNitrogenRecipe), 8, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingFocusedSpeedTalent), typeof(CuttingEdgeCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Liquid Nitrogen"), typeof(LiquidNitrogenRecipe));
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}