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
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class BarrelRecipe : RecipeFamily
    {
        public BarrelRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Barrel",  //noloc
                Localizer.DoStr("Barrel"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronPlateItem), 1, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BarrelItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(180, typeof(PotterySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BarrelRecipe), 0.5f, typeof(PotterySkill), typeof(PotteryFocusedSpeedTalent), typeof(PotteryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Barrel"), typeof(BarrelRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class BarrelBlock :
        PickupableBlock
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(BarrelItem); } }
    }

    [Serialized]
    [LocDisplayName("Barrel")]
    [MaxStackSize(10)]
    [Weight(2000)]
    [Ecopedia("Blocks", "Liquids", createAsSubPage: true)]
    public partial class BarrelItem :
 
    BlockItem<BarrelBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A metal barrel for carrying liquids."); } }

        public override bool CanStickToWalls { get { return false; } }
    }

}
