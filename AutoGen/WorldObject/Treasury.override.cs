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
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(45)]
    [RequireRoomMaterialTier(1.8f)]
    public partial class TreasuryObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(TreasuryItem);
        public override LocString DisplayName => Localizer.DoStr("Treasury");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Economy"));
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
    [LocDisplayName("Treasury")]
    [Ecopedia("Work Stations", "Government", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class TreasuryItem : WorldObjectItem<TreasuryObject>, IPersistentData
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("Allows the setting of taxes.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;

        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(SmeltingSkill), 4)]
    public partial class TreasuryRecipe : RecipeFamily
    {
        public TreasuryRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Treasury",  //noloc
                Localizer.DoStr("Treasury"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BrickItem), 16, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(GoldBarItem), 12, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement("Lumber", 60, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TreasuryItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(1500, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TreasuryRecipe), 25, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Treasury"), typeof(TreasuryRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CapitolObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}