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

    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]
    public partial class StoneRoadRecipe : RecipeFamily
    {
        public StoneRoadRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "StoneRoad",  //noloc
                Localizer.DoStr("Stone Road"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(MortarItem), 3, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 2, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<StoneRoadItem>(),
                    new CraftingElement<GarbageItem>(0.1f)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneRoadRecipe), 0.5f, typeof(BasicEngineeringSkill), typeof(BasicEngineeringFocusedSpeedTalent), typeof(BasicEngineeringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stone Road"), typeof(StoneRoadRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Constructed,Wall]
    [Road(1.2f)]
    [UsesRamp(typeof(StoneRampItem))]
    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]
    public partial class StoneRoadBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(StoneRoadItem); } }
    }

    [Serialized]
    [LocDisplayName("Stone Road")]
    [MaxStackSize(10)]
    [Weight(10000)]
    [MakesRoads]
    [Ecopedia("Blocks", "Roads", createAsSubPage: true)]
    [Tag("Road", 1)]
    [Tag("Constructable", 1)]
    [Tag("RoadType", 1)]
    public partial class StoneRoadItem :
 
    RoadItem<StoneRoadBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A rocky surface formed from smoothed rubble. It's fairly durable and efficient for any wheeled vehicle."); } }

    }

}
