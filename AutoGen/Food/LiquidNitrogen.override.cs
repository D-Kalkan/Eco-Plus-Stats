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

    [RequiresSkill(typeof(IndustrySkill), 3)]
    public partial class LiquidNitrogenRecipe : RecipeFamily
    {
        public LiquidNitrogenRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Diesel",  //noloc
                Localizer.DoStr("Diesel"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(GasolineItem), 1, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), //noloc 
                    new IngredientElement(typeof(BiodieselItem), 1, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), //noloc 
                },
                new List<CraftingElement>
                {
                    new CraftingElement<LiquidNitrogenItem>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LiquidNitrogenRecipe), 0.5f, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Diesel"), typeof(LiquidNitrogenRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Diesel")]
    [Weight(1000)]
    [Fuel(120000)][Tag("Fuel")]
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    [Tag("Diesel", 1)]
    [Tag("Liquid Fuel", 1)]
    public partial class LiquidNitrogenItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Yellow liquid, designed for use in a combustion engine without needing a spark."); } }
    }
}