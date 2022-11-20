﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;

        
    /// <summary>
    /// <para>Server side recipe definition for "AgricultureResearchPaperModern".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    public partial class AgricultureResearchPaperModernRecipe : RecipeFamily
    {
        public AgricultureResearchPaperModernRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AgricultureResearchPaperModern",  //noloc
                displayName: Localizer.DoStr("Agriculture Research Paper Modern"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BerryExtractFertilizerItem), 5, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                    new IngredientElement(typeof(BloodMealFertilizerItem), 5, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                    new IngredientElement(typeof(HideAshFertilizerItem), 5, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                    new IngredientElement(typeof(PeltFertilizerItem), 5, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                    new IngredientElement("Raw Food", 200, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AgricultureResearchPaperModernItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 6; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(600);

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(1);

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Agriculture Research Paper Modern"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Agriculture Research Paper Modern"), recipeType: typeof(AgricultureResearchPaperModernRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ResearchTableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    
    /// <summary>
    /// <para>Server side item definition for the "AgricultureResearchPaperModern" item.</para>
    /// <para>More information about Item objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.Item.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [Serialized] // Tells the save/load system this object needs to be serialized. 
    [LocDisplayName("Agriculture Research Paper Modern")] // Defines the localized name of the item.
    [Weight(10)] // Defines how heavy AgricultureResearchPaperModern is.
    [Ecopedia("Items", "Research Papers", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Modern Research", 1)]
    [Tag("Research", 1)]
    public partial class AgricultureResearchPaperModernItem : Item
    {
        /// <summary>The tooltip description for the item.</summary>
        public override LocString DisplayDescription { get { return Localizer.DoStr("A document containing important research information. Used to discover new skills at the research table."); } }
    }
}