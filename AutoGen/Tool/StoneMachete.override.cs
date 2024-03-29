﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Math;
    using Eco.Core.Controller;


    public partial class StoneMacheteRecipe : RecipeFamily
    {
        public StoneMacheteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "StoneMachete",  //noloc
                Localizer.DoStr("Stone Machete"),
                new List<IngredientElement>
                {
                    new IngredientElement("Wood", 4), //noloc
                    new IngredientElement("Rock", 10), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<StoneMacheteItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(10);
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stone Machete"), typeof(StoneMacheteRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Stone Machete")]
    [Tier(1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Tag("Primitive Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class StoneMacheteItem : MacheteItem
    {
                                                                                                                                                                                                                                           // Static values
        private static IDynamicValue caloriesBurn           = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(StoneMacheteItem), typeof(GatheringToolEfficiencyTalent)), CreateCalorieValue(20, typeof(FarmingSkill), typeof(StoneMacheteItem)));
        private static IDynamicValue exp                    = new ConstantValue(0.1f);
        private static IDynamicValue tier                   = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(1), new TalentModifiedValue(typeof(StoneMacheteItem), typeof(GatheringToolStrengthTalent), 0));
        private static IDynamicValue skilledRepairCost      = new ConstantValue(5);


        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A machete used to quickly clear plants.");
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(FarmingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override Item RepairItem                 => Item.Get<Item>();
        public override Tag RepairTag                   => TagManager.Tag("Rock");
        public override int FullRepairAmount            => 5;
    }
}
