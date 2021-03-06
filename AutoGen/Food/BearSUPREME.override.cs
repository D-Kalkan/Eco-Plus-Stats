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
    [LocDisplayName("Bear S U P R E M E")]
    [Weight(500)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BearSUPREMEItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Just because the name has 'bear' in it doesn't mean it actually contains bear.");
        
        public override float Calories                  => 1200;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 8, Fat = 22, Protein = 20, Vitamins = 10};
    }


    [RequiresSkill(typeof(AdvancedCookingSkill), 3)]
    public partial class BearSUPREMERecipe : RecipeFamily
    {
        public BearSUPREMERecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "BearSUPREME",  //noloc
                Localizer.DoStr("Bear S U P R E M E"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PrimeCutItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(VegetableMedleyItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(MeatStockItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(InfusedOilItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BearSUPREMEItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BearSUPREMERecipe), 8, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bear S U P R E M E"), typeof(BearSUPREMERecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}