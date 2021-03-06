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
    [LocDisplayName("Camas Paste")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CamasPasteItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Camas Paste");
        public override LocString DisplayDescription    => Localizer.DoStr("Pulverized camas works as an excellent thickener or flavour enhancer.");
        
        public override float Calories                  => 28;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 3, Fat = 10, Protein = 2, Vitamins = 0};
    }


    [RequiresSkill(typeof(MillingSkill), 1)]
    public partial class CamasPasteRecipe : RecipeFamily
    {
        public CamasPasteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CamasPaste",  //noloc
                Localizer.DoStr("Camas Paste"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CamasBulbItem), 4, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CamasPasteItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CamasPasteRecipe), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Camas Paste"), typeof(CamasPasteRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}