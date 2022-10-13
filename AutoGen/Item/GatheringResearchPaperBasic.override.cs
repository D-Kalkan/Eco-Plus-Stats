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
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;

    ///changing gathering skill to farming skill crashes the server when it starts initializing skills
    public partial class GatheringResearchPaperBasicRecipe : RecipeFamily
    {
        public GatheringResearchPaperBasicRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "GatheringResearchPaperBasic",  //noloc
                Localizer.DoStr("Gathering Research Paper Basic"),
                new List<IngredientElement>
                {
                    /// can change values, but they are not being used anyway
                    new IngredientElement(typeof(PlantFibersItem), 20, typeof(FarmingSkill)),
                    new IngredientElement("Raw Food", 30, typeof(FarmingSkill)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<GatheringResearchPaperBasicItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1.5f;
            ///can change values, the game accepts the change in calories usage, but it still requires Gathering Skill work to be performed, and gives Gathering XP
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(FarmingSkill));
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Gathering Research Paper Basic"), typeof(GatheringResearchPaperBasicRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Gathering Research Paper Basic")]
    [Weight(10)]
    [Ecopedia("Items", "Research Papers", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Basic Research", 1)]
    [Tag("Research", 1)]
    public partial class GatheringResearchPaperBasicItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A document containing important research information. Used to discover new skills at the research table."); } }
    }
}
