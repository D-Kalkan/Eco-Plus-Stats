﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Baking")]
    [Ecopedia("Professions", "Chef", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [RequiresSkill(typeof(ChefSkill), 0), Tag("Chef Specialty"), Tier(3)]
    [Tag("Specialty")]
    [Tag("Teachable")]
    public partial class BakingSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An introduction to cooking with an oven. Level by crafting related unleavened recipes."); } }

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 
                1,
                1 - 0.5f,
                1 - 0.55f,
                1 - 0.6f,
                1 - 0.65f,
                1 - 0.7f,
                1 - 0.75f,
                1 - 0.8f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;

        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 3; } }
    }

    [Serialized]
    [LocDisplayName("Eco+ Baking Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BakingSkillBook : SkillBook<BakingSkill, BakingSkillScroll> {}

    [Serialized]
    [LocDisplayName("Eco+ Baking Skill Scroll")]
    public partial class BakingSkillScroll : SkillScroll<BakingSkill, BakingSkillBook> {}


    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class BakingSkillBookRecipe : RecipeFamily
    {
        public BakingSkillBookRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Baking",  //noloc
                Localizer.DoStr("Eco+ Baking Skill Scroll"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CulinaryResearchPaperBasicItem), 100, typeof(CampfireCookingSkill)),
                    new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 50, typeof(CampfireCookingSkill)),
                    new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 100, typeof(CampfireCookingSkill)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BakingSkillScroll>(10)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(1);
            this.CraftMinutes = CreateCraftTimeValue(2f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Eco+ Baking Skill Scroll"), typeof(BakingSkillBookRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
