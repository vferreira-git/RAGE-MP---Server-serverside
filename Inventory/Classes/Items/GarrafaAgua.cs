using DAL.EF.TableClasses;
using DAL.TableRepository;
using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Inventory.InventoryMain;

namespace Inventory.Classes.Items
{
    public class GarrafaAgua : IItem
    {
        public override string DisplayName { get; set; } = "Garrafa de Água";
        public override string Name { get; set; } = "garrafaagua";
        public override string Icon { get; set; } = "garrafaagua.png";
        public const ItemTypes Type = ItemTypes.Usable;
        public override string Info
        {
            get
            {
                return "Quantidade: " + Amount.ToString() + "<br /> <i>Essencial à vida.</i>";
            }
            set
            {
                base.Info = value;
            }
        }

        public override void Use(Client client)
        {
            CharacterRepository repo = new CharacterRepository();
            if (client.GetSharedData("character") != null)
            {
                Character c = repo.GetByName(client.GetSharedData("character"));
                if (c != null)
                {
                    client.Health += 5;
                    c.Thirst += 30;
                    RemoveItem(client);
                }
            }

        }
    }
}
