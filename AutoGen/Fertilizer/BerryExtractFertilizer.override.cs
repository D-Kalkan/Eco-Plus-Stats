﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using System.ComponentModel;
    using Eco.Core.Controller;


    /// <summary>
    /// <para>Server side recipe definition for "BerryExtractFertilizer".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [RequiresSkill(typeof(FertilizersSkill), 2)]
    public partial class BerryExtractFertilizerRecipe : RecipeFamily
    {
        public BerryExtractFertilizerRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "BerryExtractFertilizer",  //noloc
                displayName: Localizer.DoStr("Berry Extract Fertilizer"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(HuckleberriesItem), 40, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)),
                    new IngredientElement("FertilizerFiller", 1, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BerryExtractFertilizerItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(15, typeof(FertilizersSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(BerryExtractFertilizerRecipe), start: 0.3f, skillType: typeof(FertilizersSkill), typeof(FertilizersFocusedSpeedTalent), typeof(FertilizersParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Berry Extract Fertilizer"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Berry Extract Fertilizer"), recipeType: typeof(BerryExtractFertilizerRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    
    /// <summary>
    /// <para>Server side fertilizer item definition for the "BerryExtractFertilizer" item.</para>
    /// <para>More information about Item objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.FertilizerItem-1.html.</para>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    /// </summary>
    [Serialized] // Tells the save/load system this object needs to be serialized. 
    [LocDisplayName("Berry Extract Fertilizer")] // Defines the localized name of the item.
    [Weight(500)] // Defines how heavy BerryExtractFertilizer is.
    [Category("Tool")] // Gives this item the category of "Tool" for organization
    [Tag("Fertilizer", 1)] // Gives this item the Fertilizer tag for use in recipes
    [Ecopedia("Items", "Fertilizer", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        public partial class BerryExtractFertilizerItem : FertilizerItem<BerryExtractFertilizerItem>
    {
        /// <summary>The tooltip description for the item.</summary>
        public override LocString DisplayDescription { get { return Localizer.DoStr("An excellent fertilizer that provides a mix of nutrients, but especially potassium."); } }

        static BerryExtractFertilizerItem()
        {
            Nutrients = new List<NutrientElement>();
            Nutrients.Add(new NutrientElement("Nitrogen", 1));        // Defines the amount of Nitrogen added by this fertilizer item
            Nutrients.Add(new NutrientElement("Phosphorus", 3));    // Defines the amount of Phosphorus added by this fertilizer item
            Nutrients.Add(new NutrientElement("Potassium", 4.8f));      // Defines the amount of Potassium added by this fertilizer item
        }
    }
}
