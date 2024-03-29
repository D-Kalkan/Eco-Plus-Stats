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


    public partial class PropertyToolRecipe : RecipeFamily
    {
        public PropertyToolRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "PropertyTool",  //noloc
                Localizer.DoStr("Land Claim Stake"),
                new List<IngredientElement>
                {
                    new IngredientElement("Wood", 12), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<PropertyToolItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(200);
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Land Claim Stake"), typeof(PropertyToolRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Land Claim Stake")]
    [Weight(1000)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    [Tag("Tool", 1)]
    [Tag("Primitive Recyclable Tool", 1)]
    public partial class PropertyToolItem : ToolItem
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Land Claim Stakes"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Used to claim, unclaim, and examine property.\n\nWhen claiming:\n- Hold Ctrl to create a new deed.\n- Hold Shift to choose from nearby deeds.\nWhen unclaiming:\n- Hold Ctrl to unclaim an entire deed.\n- Hold Shift to move plot to a nearby deed."); } }
    }
}