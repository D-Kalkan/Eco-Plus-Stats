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
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class LumberRecipe : RecipeFamily
    {
        public LumberRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Lumber",  //noloc
                Localizer.DoStr("Lumber"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(NailItem), 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    new IngredientElement("HewnLog", 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<LumberItem>(),
                    new CraftingElement<GarbageItem>(0.1f)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LumberRecipe), 0.5f, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Lumber"), typeof(LumberRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(2)]
    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class LumberBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(LumberItem); } }
    }

    [Serialized]
    [LocDisplayName("Lumber")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Fuel(4000)][Tag("Fuel")]
    [ResourcePile]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Lumber", 1)]
    [Tag("Burnable Fuel", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class LumberItem :
 
    BlockItem<LumberBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Can be fashioned into various usable equipment."); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(LumberStacked1Block),
            typeof(LumberStacked2Block),
            typeof(LumberStacked3Block),
            typeof(LumberStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class LumberStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class LumberStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class LumberStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class LumberStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Lumber
}