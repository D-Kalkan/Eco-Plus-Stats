﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Plants;
    using Eco.Shared.Math;
    using Eco.Simulation;
    using Eco.Shared.Serialization;
    using Eco.Simulation.WorldLayers;
    using System.Text;
    using Eco.Gameplay.DynamicValues;
    using Eco.Shared.Localization;

    [Serialized]
    [LocDisplayName("Soil Sampler")]
    [Category("Tools")]
    [Tag("Tool", 1)]
    [Tag("Primitive Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    [Weight(1000)]
    public class SoilSamplerItem : ToolItem
    {
        public override LocString DisplayDescription   { get { return Localizer.DoStr("Beaker and measuring tools for detecting the factors influencing plants in the environment."); } }
        public override LocString LeftActionDescription { get { return Localizer.DoStr("Sample soil"); } }

        public override float DurabilityRate { get { return 0; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(4);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock)
            {
                var target        = context.BlockPosition.Value + context.Normal;
                var plantPosition = context.Block is PlantBlock ? context.BlockPosition.Value : context.BlockPosition.Value + Vector3i.Up;
                var plant         = EcoSim.PlantSim.GetPlant(plantPosition);
                var title         = new StringBuilder();
                var text          = new StringBuilder();
                if (plant != null)
                {
                    title.Append($"{plant.Species.DisplayName} {context.BlockPosition}");
                    text.Append(plant.GetEcosystemInfo() + "\n" + text);
                }
                else
                {
                    title.Append(context.Block.GetType().Name + " " + context.BlockPosition.ToString());
                }
                text.AppendLine(WorldLayerManager.Obj.DescribePos(target.Value.XZ));

                context.Player.LargeInfoBox(title.ToString(), text.ToString());

                this.BurnCaloriesNow(context.Player);
            }

            return base.OnActLeft(context);
        }
    }
}
