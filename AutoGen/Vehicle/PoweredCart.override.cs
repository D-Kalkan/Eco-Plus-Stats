﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from VehicleTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Components.VehicleModules;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.Items;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Powered Cart")]
    [Weight(15000)]
    [AirPollution(0.1f)]
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true)]
    public partial class PoweredCartItem : WorldObjectItem<PoweredCartObject>, IPersistentData
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A three wheeled 9 horse power, cart for hauling sizable loads."); } }
        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren(CacheAs.Instance)] public object PersistentData { get; set; }
    }

    /// <summary>
    /// <para>Server side recipe definition for "PoweredCart".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [RequiresSkill(typeof(BasicEngineeringSkill), 3)]
    [Ecopedia("Crafted Objects", "Vehicles", subPageName: "PoweredCart Item")]
    public partial class PoweredCartRecipe : RecipeFamily
    {
        public PoweredCartRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "PoweredCart",  //noloc
                displayName: Localizer.DoStr("Powered Cart"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("WoodBoard", 30, typeof(BasicEngineeringSkill)), //noloc
                    new IngredientElement("Fabric", 20, typeof(BasicEngineeringSkill)), //noloc
                    new IngredientElement(typeof(CastIronStoveItem), 1, true),
                    new IngredientElement(typeof(IronWheelItem), 3, true),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<PoweredCartItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(BasicEngineeringSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(PoweredCartRecipe), start: 10, skillType: typeof(BasicEngineeringSkill));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Powered Cart"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Powered Cart"), recipeType: typeof(PoweredCartRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(WainwrightTableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(MinimapComponent))]           
    [Ecopedia("Crafted Objects", "Vehicles", subPageName: "PoweredCart Item")]
    public partial class PoweredCartObject : PhysicsWorldObject, IRepresentsItem
    {
        static PoweredCartObject()
        {
            WorldObject.AddOccupancy<PoweredCartObject>(new List<BlockOccupancy>(0));
        }
        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public override bool PlacesBlocks            => false;
        public override LocString DisplayName { get { return Localizer.DoStr("Powered Cart"); } }
        public Type RepresentedItemType { get { return typeof(PoweredCartItem); } }

        private static string[] fuelTagList = new string[]
        {
            "Charcoal",
        };
        private PoweredCartObject() { }
        protected override void Initialize()
        {
            base.Initialize();         
            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(35);
            this.GetComponent<AirPollutionComponent>().Initialize(0.1f);
            this.GetComponent<PublicStorageComponent>().Initialize(18, 3500000);
            this.GetComponent<MinimapComponent>().InitAsMovable();
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Vehicles"));
            this.GetComponent<VehicleComponent>().Initialize(12, 1.5f,1);
        }
    }
}
