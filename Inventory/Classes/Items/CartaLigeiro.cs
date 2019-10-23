using GTANetworkAPI;
using Main;
using System;
using System.Collections.Generic;
using System.Text;
using static Inventory.InventoryMain;
using static Main.Main;

namespace Inventory.Classes.Items
{
    public class CartaLigeiro : IItem
    {
        public override string DisplayName { get; set; } = "Carta de Condução - Ligeiros";
        public override string Name { get; set; } = "cartaligeiros";
        public override string Info
        {
            get
            {
                return "Proprietário: " + Proprietario;
            }
            set
            {
                base.Info = value;
            }
        }
        public override string Icon { get; set; } = "carta.png";
        public const ItemTypes Type = ItemTypes.Usable;
        public string Proprietario { get; set; }

        public override void Use(Client client)
        {
            MeMessage(client, "mostra uma carta de condução de ligeiros (" + Proprietario + ").");
        }
    }
}
