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
    [LocDisplayName("Poke Bowl")]
    [Weight(400)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class PokeBowlItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A basic yet filling meal with a bite.");
        
        public override float Calories                  => 1100;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 13, Fat = 8, Protein = 14, Vitamins = 14};
    }


    [RequiresSkill(typeof(AdvancedCookingSkill), 3)]
    public partial class PokeBowlRecipe : RecipeFamily
    {
        public PokeBowlRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "PokeBowl",  //noloc
                Localizer.DoStr("Poke Bowl"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(RiceItem), 24, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(BeansItem), 24, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(KelpItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(TunaItem), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<PokeBowlItem>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PokeBowlRecipe), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Poke Bowl"), typeof(PokeBowlRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}