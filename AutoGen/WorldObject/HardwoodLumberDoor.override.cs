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
    using Eco.Gameplay.Settlements;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class HardwoodLumberDoorObject : DoorObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(HardwoodLumberDoorItem);
        public override LocString DisplayName => Localizer.DoStr("Hardwood Lumber Door");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public override bool HasTier => true;
        public override int Tier => 2;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            base.Initialize();

            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Hardwood Lumber Door")]
    [Tier(2)]
    [Ecopedia("Housing Objects", "Doors", createAsSubPage: true)]
    [Tag("Small Lumber Furnishing", 1)]
    public partial class HardwoodLumberDoorItem : WorldObjectItem<HardwoodLumberDoorObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A door made from finely cut lumber.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;

    }

    [RequiresSkill(typeof(CarpentrySkill), 5)]
    [ForceCreateView]
    public partial class HardwoodLumberDoorRecipe : Recipe
    {
        public HardwoodLumberDoorRecipe()
        {
            this.Init(
                name: "HardwoodLumberDoor",  //noloc
                displayName: Localizer.DoStr("Hardwood Lumber Door"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(HardwoodLumberItem), 6, true),
                    new IngredientElement("WoodBoard", 12, true), //noloc
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<HardwoodLumberDoorItem>()
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SawmillObject), typeof(LumberDoorRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
