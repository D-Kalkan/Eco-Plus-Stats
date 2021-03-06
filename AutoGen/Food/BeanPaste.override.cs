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
    [LocDisplayName("Bean Paste")]
    [Weight(200)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeanPasteItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Bean Paste");
        public override LocString DisplayDescription    => Localizer.DoStr("Smashed beans can work as a thickener or flavour enhancer.");
        
        public override float Calories                  => 42;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 3, Fat = 7, Protein = 5, Vitamins = 0};
    }


    [RequiresSkill(typeof(MillingSkill), 2)]
    public partial class BeanPasteRecipe : RecipeFamily
    {
        public BeanPasteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "BeanPaste",  //noloc
                Localizer.DoStr("Bean Paste"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BeansItem), 6, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BeanPasteItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeanPasteRecipe), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bean Paste"), typeof(BeanPasteRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}