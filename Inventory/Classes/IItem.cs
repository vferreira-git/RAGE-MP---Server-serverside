using DAL.EF.TableClasses;
using DAL.EF.TableRepository;
using DAL.TableRepository;
using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static Inventory.InventoryMain;

namespace Inventory.Classes
{
    public abstract class IItem
    {
        public virtual string DisplayName { get; set; } = "Default Item Name";
        public virtual string Name { get; set; } = "defaultitem";
        public virtual string Icon { get; set; } = "defaulticon.png";
        public virtual string DropObject { get; set; } = "prop_cardbordbox_05a";
        public virtual string Info { get; set; } = "...";
        public virtual int Amount { get; set; } = 1;

        public abstract void Use(Client client);
        internal void RemoveItem(Client client)
        {
            List<IItem> items = client.GetData("inventory");
            int item = items.FindIndex(x => x.Equals(this));
            items.RemoveAt(item);
            CharacterRepository repo = new CharacterRepository();
            Character c = repo.GetByName(client.GetSharedData("character"));
            c.Inventory = SerializeInventory(items);
            repo.Update(c);
            client.TriggerEvent("removeitem", item);
        }
        public void Drop(Client client)
        {
            GTANetworkAPI.Object obj = NAPI.Object.CreateObject(NAPI.Util.GetHashKey(DropObject), client.Position - new Vector3(0, 0, 1), new Vector3(0, 0, 0), dimension: client.Dimension);
            TextLabel label = NAPI.TextLabel.CreateTextLabel(DisplayName + "\nApanhar [E]", client.Position, 3, 1, 0, new Color(255, 255, 255), false, client.Dimension);
            obj.SetData("droppeditem:item", this);
            label.SetData("droppeditem:obj", obj.Handle.Value);
            DroppedItemRepository repo = new DroppedItemRepository();
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Auto
            };
            DroppedItem item = new DroppedItem
            {
                Dimension = client.Dimension,
                Item = JsonConvert.SerializeObject(this, Formatting.Indented, settings),
                PosX = client.Position.X,
                PosY = client.Position.Y,
                PosZ = client.Position.Z - 1
            };
            repo.Add(item);
            obj.SetData("droppeditem:itemid", item.Id);

            RemoveItem(client);
        }
    }
}
