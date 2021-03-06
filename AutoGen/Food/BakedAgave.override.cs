// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Baked Agave")]
    [Weight(300)]
    [Tag("BakedVegetable", 1)]
    [Tag("BakedFood", 1)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BakedAgaveItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Charred agave leaves are too fiberous to eat entirely, but you can certainly chew them.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 12, Fat = 6, Protein = 2, Vitamins = 8};
    }


    [RequiresSkill(typeof(BakingSkill), 1)]
    public partial class BakedAgaveRecipe : RecipeFamily
    {
        public BakedAgaveRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "BakedAgave",  //noloc
                Localizer.DoStr("Baked Agave"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(AgaveLeavesItem), 40, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BakedAgaveItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(BakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BakedAgaveRecipe), 2, typeof(BakingSkill), typeof(BakingFocusedSpeedTalent), typeof(BakingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Baked Agave"), typeof(BakedAgaveRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}