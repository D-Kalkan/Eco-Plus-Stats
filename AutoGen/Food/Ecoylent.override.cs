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
    [LocDisplayName("Ecoylent")]
    [Weight(10000)]
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class EcoylentItem : Item
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A huge bottle of Nutrient Paste, made from a multitude of meals that got blended together. Tastes bland and boring. Eat only in emergencies.");
    }
	
	public partial class EcoylentRecipe : RecipeFamily
    {
        public EcoylentRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Ecoylent",  //noloc
                Localizer.DoStr("Ecoylent"),
                new List<IngredientElement>
                {
					new IngredientElement(typeof(AgoutiEnchiladasItem), 70, true),
					new IngredientElement(typeof(BearclawItem), 60, true),
					new IngredientElement(typeof(BearSUPREMEItem), 40, true),
					new IngredientElement(typeof(BisonChowFunItem), 40, true),
					new IngredientElement(typeof(BoiledSausageItem), 80, true),
					new IngredientElement(typeof(PokeBowlItem), 40, true),
					new IngredientElement(typeof(CornFrittersItem), 100, true),
					new IngredientElement(typeof(CrimsonSaladItem), 40, true),
					new IngredientElement(typeof(ElkTacoItem), 80, true),
					new IngredientElement(typeof(ElkWellingtonItem), 40, true),
					new IngredientElement(typeof(FantasticForestPizzaItem), 40, true),
					new IngredientElement(typeof(FishNChipsItem), 50, true),
					new IngredientElement(typeof(FriedHareHaunchesItem), 70, true),
					new IngredientElement(typeof(FruitTartItem), 60, true),
					new IngredientElement(typeof(BanhXeoItem), 30, true),
					new IngredientElement(typeof(HeartyHometownPizzaItem), 40, true),
					new IngredientElement(typeof(HosomakiItem), 80, true),
					new IngredientElement(typeof(KelpyCrabRollItem), 70, true),
					new IngredientElement(typeof(KelpySalmonRollItem), 70, true),
					new IngredientElement(typeof(MacaroonsItem), 70, true),
					new IngredientElement(typeof(MillionairesSaladItem), 40, true),
					new IngredientElement(typeof(PineappleFriendRiceItem), 80, true),
					new IngredientElement(typeof(PirozhokItem), 60, true),
					new IngredientElement(typeof(SearedMeatItem), 80, true),
					new IngredientElement(typeof(SeededCamasRollItem), 40, true),
					new IngredientElement(typeof(SensuousSeaPizzaItem), 40, true),
					new IngredientElement(typeof(SpikyRollItem), 40, true),
					new IngredientElement(typeof(StuffedTurkeyItem), 30, true),
					new IngredientElement(typeof(SweetSaladItem), 40, true),
					new IngredientElement(typeof(TastyTropicalPizzaItem), 40, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<EcoylentItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(10000);
            this.CraftMinutes = CreateCraftTimeValue(60);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Ecoylent"), typeof(EcoylentRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}