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

    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]
    public partial class AshlarGneissRecipe : RecipeFamily
    {
        public AshlarGneissRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "AshlarGneiss",  //noloc
                Localizer.DoStr("Ashlar Gneiss"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(GneissItem), 20, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(MortarItem), 6, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SteelBarItem), 1, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<AshlarGneissItem>(),
                    new CraftingElement<CrushedGneissItem>(typeof(AdvancedMasonrySkill), 2, typeof(AdvancedMasonryLavishResourcesTalent)),
                    new CraftingElement<GarbageItem>(0.3f)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(180, typeof(AdvancedMasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AshlarGneissRecipe), 2, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryFocusedSpeedTalent), typeof(AdvancedMasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Ashlar Gneiss"), typeof(AshlarGneissRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AdvancedMasonryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(4)]
    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]
    public partial class AshlarGneissBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(AshlarGneissItem); } }
    }

    [Serialized]
    [LocDisplayName("Ashlar Gneiss")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Tag("AshlarStone", 1)]
    [Tag("Constructable", 1)]
    [Tier(4)]
    public partial class AshlarGneissItem :
 
    BlockItem<AshlarGneissBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Ashlar Gneiss"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Ashlar is finely cut stone made by an expert mason. Ashlar stone is an especially decorative building material that comes in a variety of styles based on the type of rock used."); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(AshlarGneissStacked1Block),
            typeof(AshlarGneissStacked2Block),
            typeof(AshlarGneissStacked3Block),
            typeof(AshlarGneissStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class AshlarGneissStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class AshlarGneissStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class AshlarGneissStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class AshlarGneissStacked4Block : PickupableBlock { } //Only a wall if it's all 4 AshlarGneiss
}
