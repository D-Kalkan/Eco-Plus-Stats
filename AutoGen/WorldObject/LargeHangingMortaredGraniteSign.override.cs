﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from WorldObjectTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    public partial class LargeHangingMortaredGraniteSignObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(LargeHangingMortaredGraniteSignItem);
        public override LocString DisplayName => Localizer.DoStr("Large Hanging Mortared Granite Sign");
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<CustomTextComponent>().Initialize(700);
            this.ModsPostInitialize();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Large Hanging Mortared Granite Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class LargeHangingMortaredGraniteSignItem : WorldObjectItem<LargeHangingMortaredGraniteSignObject>, IPersistentData
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A large sign for all your large text needs!");



        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(MasonrySkill), 5)]
    [ForceCreateView]
    public partial class LargeHangingMortaredGraniteSignRecipe : Recipe
    {
        public LargeHangingMortaredGraniteSignRecipe()
        {
            this.Init(
                "LargeHangingMortaredGraniteSign",  //noloc
                Localizer.DoStr("Large Hanging Mortared Granite Sign"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(MortaredGraniteItem), 10, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<LargeHangingMortaredGraniteSignItem>()
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(MasonryTableObject), typeof(LargeHangingMortaredStoneSignRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
