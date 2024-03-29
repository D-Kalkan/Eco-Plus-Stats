﻿// Copyright (c) Strange Loop Games. All rights reserved.
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
    using Eco.Core.Controller;


    [RequiresModule(typeof(MachinistTableObject))]
    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class IronPlateRecipe : RecipeFamily
    {
        public IronPlateRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "IronPlate",  //noloc
                Localizer.DoStr("Iron Plate"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronBarItem), 1, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<IronPlateItem>(),
                    new CraftingElement<GarbageItem>(0.1f)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronPlateRecipe), 2, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Plate"), typeof(IronPlateRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ScrewPressObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Iron Plate")]
    [Weight(500)]
    [Tag("Currency")][Currency]
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    public partial class IronPlateItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A solid iron plate for use in various crafting recipes."); } }
    }
}