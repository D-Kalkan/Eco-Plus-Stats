// Copyright (c) Strange Loop Games. All rights reserved.
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

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class TransmissionPoleObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Transmission Pole"); } }
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public virtual Type RepresentedItemType { get { return typeof(TransmissionPoleItem); } }

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<PowerGridComponent>().Initialize(15, new ElectricPower());
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
    [LocDisplayName("Transmission Pole")]
    [Ecopedia("Crafted Objects", "Specialty", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class TransmissionPoleItem : WorldObjectItem<TransmissionPoleObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Can link energy.");


    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class TransmissionPoleRecipe : RecipeFamily
    {
        public TransmissionPoleRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "TransmissionPole",  //noloc
                Localizer.DoStr("Transmission Pole"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(SteelBarItem), 16, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(CopperBarItem), 14, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement("Lumber", 20, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TransmissionPoleItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(800, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TransmissionPoleRecipe), 4, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Crude Transmission Pole"), typeof(TransmissionPoleRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this); //ElectricMachinistTableObject
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
