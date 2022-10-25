﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [RequiresSkill(typeof(FertilizersSkill), 3)]
    public partial class ReclaimedClayRecipe : RecipeFamily
    {
        public ReclaimedClayRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Clay",  //noloc
                Localizer.DoStr("Reclaimed Clay"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(GarbageItem), 50, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ClayItem>(1),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(FertilizersSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ReclaimedClayRecipe), 0.5f, typeof(FertilizersSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Reclaimed Clay"), typeof(ReclaimedClayRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
