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
    [LocDisplayName("Kelpy Crab Roll")]
    [Weight(300)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class KelpyCrabRollItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Pieces of crab on a bed of rice rolled up and covered in kelp.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 13, Fat = 11, Protein = 16, Vitamins = 11};
    }


    [RequiresSkill(typeof(AdvancedCookingSkill), 3)]
    public partial class KelpyCrabRollRecipe : RecipeFamily
    {
        public KelpyCrabRollRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "KelpyCrabRoll",  //noloc
                Localizer.DoStr("Kelpy Crab Roll"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BoiledRiceItem), 8, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(KelpItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(CrabCarcassItem), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<KelpyCrabRollItem>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(KelpyCrabRollRecipe), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Kelpy Crab Roll"), typeof(KelpyCrabRollRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}