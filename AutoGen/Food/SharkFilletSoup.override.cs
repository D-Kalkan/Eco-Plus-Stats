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
    [LocDisplayName("Shark Fillet Soup")]
    [Weight(600)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SharkFilletSoupItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A texture all of its own.");
        
        public override float Calories                  => 1400;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 10, Fat = 11, Protein = 17, Vitamins = 2};
    }


    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class SharkFilletSoupRecipe : RecipeFamily
    {
        public SharkFilletSoupRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "SharkFilletSoup",  //noloc
                Localizer.DoStr("Shark Fillet Soup"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(MeatStockItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    new IngredientElement(typeof(BlueSharkItem), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SharkFilletSoupItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SharkFilletSoupRecipe), 2, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Shark Fillet Soup"), typeof(SharkFilletSoupRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}