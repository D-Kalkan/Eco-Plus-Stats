﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
	using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;

    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(SelectionStorageComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    [RequireComponent(typeof(ModularVehicleComponent))]
    public partial class SteamTractorObject : PhysicsWorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Steam Tractor"); } }
		public override TableTextureMode TableTexture => TableTextureMode.Metal;

        static SteamTractorObject()
        {
            WorldObject.AddOccupancy<SteamTractorObject>(new List<BlockOccupancy>(0));
        }

        private static readonly string[] FuelTagList = new string[]
        {
            "Coke",
        };

        private SteamTractorObject() { }

		private static readonly Type[] SegmentTypeList = Array.Empty<Type>();
        private static readonly Type[] AttachmentTypeList = new Type[]
        {
            typeof(SteamTractorPlowItem), typeof(SteamTractorHarvesterItem), typeof(SteamTractorSowerItem)
        };

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<SelectionStorageComponent>().CreateInventory(12, 2500000, VehicleUtilities.GetInventoryRestriction(this));
            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<FuelSupplyComponent>().Initialize(2, FuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);
            this.GetComponent<AirPollutionComponent>().Initialize(0.05f);
            this.GetComponent<VehicleComponent>().Initialize(9, 1, 2);
            this.GetComponent<VehicleComponent>().HumanPowered(2);
            this.GetComponent<ModularVehicleComponent>().Initialize(0, 1, SegmentTypeList, AttachmentTypeList);
        }
    }
}
