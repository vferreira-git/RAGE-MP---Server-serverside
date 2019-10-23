using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Inventory.InventoryMain;
using static Main.Main;

namespace Inventory.Classes.Items
{
    public class CartaoCidadao : IItem
    {
        public override string DisplayName { get; set; } = "Cartão de Cidadão";
        public override string Name { get; set; } = "cartaocidadao";
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
            MeMessage(client, "mostra um cartão de cidadão (" + Proprietario + ").");
        }
    }
}
