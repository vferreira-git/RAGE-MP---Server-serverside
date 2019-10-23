using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Inventory.InventoryMain;

namespace Inventory.Classes.Items
{
    public class ChaveCarro : IItem
    {
        public override string DisplayName { get; set; } = "Chave ( Veículo )";
        public override string Name { get; set; } = "chavecarro";
        public override string Icon { get; set; } = "chaveveiculo.png";
        public const ItemTypes Type = ItemTypes.Usable;
        public override int Amount { get; set; }

        public override void Use(Client client)
        {
            

        }
    }
}
