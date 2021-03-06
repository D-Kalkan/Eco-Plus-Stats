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
    [LocDisplayName("Macaroons")]
    [Weight(200)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MacaroonsItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Macaroons");
        public override LocString DisplayDescription    => Localizer.DoStr("A small circular biscuit with a sweet huckleberry filling.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 20, Fat = 14, Protein = 7, Vitamins = 16};
    }


    [RequiresSkill(typeof(AdvancedBakingSkill), 2)]
    public partial class MacaroonsRecipe : RecipeFamily
    {
        public MacaroonsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Macaroons",  //noloc
                Localizer.DoStr("Macaroons"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PastryDoughItem), 4, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement(typeof(SugarItem), 10, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement(typeof(HuckleberryExtractItem), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MacaroonsItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedBakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MacaroonsRecipe), 3, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Macaroons"), typeof(MacaroonsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}