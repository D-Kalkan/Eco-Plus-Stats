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
    [LocDisplayName("Mochi")]
    [Weight(100)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MochiItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Watch your hands!");
        
        public override float Calories                  => 800;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 25, Fat = 0, Protein = 0, Vitamins = 5};
    }


    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class MochiRecipe : RecipeFamily
    {
        public MochiRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Mochi",  //noloc
                Localizer.DoStr("Mochi"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(RiceFlourItem), 16, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    new IngredientElement(typeof(SugarItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    new IngredientElement(typeof(CornmealItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MochiItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MochiRecipe), 2, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mochi"), typeof(MochiRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}