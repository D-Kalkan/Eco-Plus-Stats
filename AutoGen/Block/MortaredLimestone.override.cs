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

    [RequiresSkill(typeof(MasonrySkill), 3)]
    [ForceCreateView]
    public partial class MortaredLimestoneRecipe : Recipe
    {
        public MortaredLimestoneRecipe()
        {
            this.Init(
                "MortaredLimestone",  //noloc
                Localizer.DoStr("Mortared Limestone"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(LimestoneItem), 4, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(MortarItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MortaredLimestoneItem>(),
                    new CraftingElement<GarbageItem>(0.1f)
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(MasonryTableObject), typeof(MortaredStoneRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(1)]
    [RequiresSkill(typeof(MasonrySkill), 3)]
    public partial class MortaredLimestoneBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(MortaredLimestoneItem); } }
    }

    [Serialized]
    [LocDisplayName("Mortared Limestone")]
    [MaxStackSize(15)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Tag("MortaredStone", 1)]
    [Tag("Constructable", 1)]
    [Tier(1)]
    public partial class MortaredLimestoneItem :
 
    BlockItem<MortaredLimestoneBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Mortared Limestone"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Used to create tough but rudimentary buildings."); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(MortaredLimestoneStacked1Block),
            typeof(MortaredLimestoneStacked2Block),
            typeof(MortaredLimestoneStacked3Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class MortaredLimestoneStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class MortaredLimestoneStacked2Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class MortaredLimestoneStacked3Block : PickupableBlock { } //Only a wall if it's all 4 MortaredLimestone
}
