using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Inventory.InventoryMain;

namespace Inventory.Classes.Items
{
    public class ChavePropriedade : IItem
    {
        public override string DisplayName { get; set; } = "Chave ( Propriedade )";
        public override string Name { get; set; } = "chavepropriedade";
        public override string Icon { get; set; } = "chavepropriedade.png";
        public const ItemTypes Type = ItemTypes.Usable;
        public override int Amount { get; set; }

        public override void Use(Client client)
        {
            
        }
    }
}
