using DAL.EF.TableClasses;
using DAL.TableRepository;
using GTANetworkAPI;
using Inventory.Classes;
using Inventory.Classes.Items;
using System;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;
using System.Threading;
using DAL.EF.TableRepository;
using System.Linq;
using DAL.EF;

namespace Inventory
{
    public class InventoryMain : Script
    {
        private static Dictionary<string, Type> ItemDictionary = new Dictionary<string, Type>() {
            { "apple", typeof(Apple) },
            { "cartaligeiro", typeof(CartaLigeiro) },
            { "cartamota", typeof(CartaMota) },
            {"cartaocidadao",typeof(CartaoCidadao) },
            {"cartapesado",typeof(CartaPesado) },
            {"chavecarro",typeof(ChaveCarro) },
            {"chavepropriedade",typeof(ChavePropriedade) },
            {"garrafaagua",typeof(GarrafaAgua) }
        };
        public InventoryMain()
        {
            LoadDroppedItems();
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            using (DALContext mainContext = new DALContext())
            {
                mainContext.Database.EnsureCreated();
                mainContext.SaveChanges();
            }
        }

        public void LoadDroppedItems()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Auto
            };
            DroppedItemRepository repo = new DroppedItemRepository();
            foreach (DroppedItem droppedItem in repo.GetAll())
            {
                IItem item = JsonConvert.DeserializeObject<IItem>(droppedItem.Item, settings);
                GTANetworkAPI.Object obj = NAPI.Object.CreateObject(NAPI.Util.GetHashKey(item.DropObject), droppedItem.Position, new Vector3(0, 0, 0), dimension: droppedItem.Dimension);
                TextLabel label = NAPI.TextLabel.CreateTextLabel(item.DisplayName + "\nApanhar [E]", droppedItem.Position, 3, 1, 0, new Color(255, 255, 255), false, droppedItem.Dimension);
                obj.SetData("droppeditem:item", item);
                obj.SetData("droppeditem:itemid", droppedItem.Id);
                label.SetData("droppeditem:obj", obj.Handle.Value);
            }
        }

        [RemoteEvent("characterselected")]
        public void CharacterSelected(Client client)
        {
            CharacterRepository repo = new CharacterRepository();
            Character c = repo.GetByName(client.GetSharedData("character"));
            if (c != null)
            {
                client.SetData("inventory", new List<IItem>());
                LoadInventory(client,ParseInventory(c.Inventory));
            }
        }

        private void LoadInventory(Client client, List<IItem> inventory)
        {
            client.TriggerEvent("clearinventory");
            foreach (IItem item in inventory)
            {
                AddItem(client, item);
            }
        }

        [RemoteEvent("trypickupitem")]
        public void TryPickupItem(Client client)
        {
            var objects = NAPI.Pools.GetAllObjects().Where(x => x.Position.DistanceTo(client.Position) <= 3).OrderBy(x => x.Position.DistanceTo(client.Position));
            if (objects.Count() > 0)
            {
                GTANetworkAPI.Object obj = objects.First() ?? null;
                if (obj != null && obj.Position.DistanceTo(client.Position) <= 3)
                {
                    IItem item = obj.GetData("droppeditem:item");
                    TextLabel label = NAPI.Pools.GetAllTextLabels().Find(x => x.GetData("droppeditem:obj") == obj.Handle.Value);
                    if (label != null && obj != null && item != null)
                    {
                        AddItem(client, item);
                        DroppedItemRepository repo = new DroppedItemRepository();
                        DroppedItem itemDelete = repo.GetAllList().Find(x => x.Id == obj.GetData("droppeditem:itemid"));
                        if (itemDelete != null)
                            repo.Remove(itemDelete);
                        label.Delete();
                        obj.Delete();
                    }
                }
            }
        }

        /*[ServerEvent(Event.PlayerEnterColshape)]
        public void OnPlayerEnterColShape(ColShape shape, Client player)
        {
            if (shape.GetData("droppeditem") != null && shape.GetData("type") == "droppeditem")
            {
                player.SetData("CurrentDroppedItem", shape.GetData("droppeditem"));
            }

        }

        [ServerEvent(Event.PlayerExitColshape)]
        public void OnPlayerExitColShape(ColShape shape, Client player)
        {
            if (shape.GetData("droppeditem") != null)
            {
                player.SetData("CurrentDroppedItem", null);
            }
        }*/

        [Command("saveinv")]
        public void SaveInv(Client client)
        {
            CharacterRepository repo = new CharacterRepository();
            if (!string.IsNullOrEmpty(client.GetSharedData("character")))
            {
                Character c = repo.GetByName(client.GetSharedData("character"));
                if (c != null)
                {
                    c.Inventory = SerializeInventory(client.GetData("inventory"));
                    repo.Update(c);
                }
            }
        }

        public static void AddItem(Client client, string itemName)
        {
            if (client.GetData("inventory") != null)
            {

                List<IItem> inventory = client.GetData("inventory");

                if (ItemDictionary.ContainsKey(itemName.ToLower()))
                {
                    Type type = ItemDictionary[itemName];
                    IItem instance = (IItem)Activator.CreateInstance(type);
                    inventory.Add(instance);
                    CharacterRepository repo = new CharacterRepository();
                    if (client.GetSharedData("character") != null)
                    {
                        Character c = repo.GetByName(client.GetSharedData("character"));
                        if (c != null)
                        {
                            c.Inventory = SerializeInventory(inventory);
                            repo.Update(c);
                            client.TriggerEvent("additem", instance.DisplayName, 1, instance.Icon, instance.Info);
                        }
                    }
                }
                else
                {
                    client.TriggerEvent("shownotification", "Erro", "Item não encontrado.");
                    return;
                }
            }
        }

        public static void AddItem(Client client, IItem rawItem)
        {
            if (client.GetData("inventory") != null)
            {
                List<IItem> inventory = client.GetData("inventory");
                inventory.Add(rawItem);
                CharacterRepository repo = new CharacterRepository();
                Character c = repo.GetByName(client.GetSharedData("character"));
                c.Inventory = SerializeInventory(inventory);
                repo.Update(c);
                client.TriggerEvent("additem", rawItem.DisplayName, 1, rawItem.Icon, rawItem.Info);
            }
        }

        [Command("item")]
        public void GiveItemSelf(Client client, string itemName)
        {
            AddItem(client, itemName);
        }

        public List<IItem> ParseInventory(string inventory)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Auto
            };
            List<IItem> items = new List<IItem>();
            try
            {


                if (inventory != null)
                {

                    items = JsonConvert.DeserializeObject<List<IItem>>(inventory, settings);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return items;
        }

        public static string SerializeInventory(List<IItem> items)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Auto
            };
            return JsonConvert.SerializeObject(items, Formatting.Indented, settings);
        }

        public void SyncInventory(Client client, List<IItem> inventory)
        {
            client.TriggerEvent("clearinventory");
            foreach (IItem item in inventory)
            {
                client.TriggerEvent("additem", item.DisplayName, 1, item.Icon, item.Info);
            }
        }

        [RemoteEvent("switchitempos")]
        public void SwitchItemPos(Client client, object[] args)
        {
            if (args.Length == 4)
            {
                if (int.TryParse(args[0].ToString(), out int i) && int.TryParse(args[1].ToString(), out int j))
                {
                    string itemName1 = args[2].ToString();
                    string itemName2 = args[3].ToString();
                    if (client.GetData("inventory") != null)
                    {

                        List<IItem> items = client.GetData("inventory");
                        if (i < items.Count)
                        {
                            var temp = items[i];
                            if (items[i].DisplayName == itemName2 && items[j].DisplayName == itemName1)
                            {
                                items[i] = items[j];
                                items[j] = temp;
                            }
                            else
                            {
                                SyncInventory(client, items);
                                client.TriggerEvent("shownotification", "Erro", "Ocorreu um erro ao tentar mudar a posição de items no inventário. A sincronizar...");
                                client.SendChatMessage(itemName1 + "              " + itemName2);
                            }
                        }
                    }
                }
            }
        }

        [RemoteEvent("useitem")]
        public void UseItem(Client client, object[] args)
        {
            if (args.Length == 2)
            {
                if (int.TryParse(args[0].ToString(), out int i))
                {
                    string itemName = args[1].ToString();
                    if (client.GetData("inventory") != null)
                    {
                        List<IItem> items = client.GetData("inventory");
                        if (i < items.Count)
                        {
                            if (items[i].DisplayName == itemName)
                                items[i].Use(client);
                            else
                            {
                                SyncInventory(client, items);
                                client.TriggerEvent("shownotification", "Erro", "Ocorreu um erro ao tentar usar um item no inventário. A sincronizar...");
                            }
                        }
                    }
                }
            }
        }
        [RemoteEvent("dropitem")]
        public void DropItem(Client client, object[] args)
        {
            if (args.Length == 2)
            {
                if (int.TryParse(args[0].ToString(), out int i))
                {
                    string itemName = args[1].ToString();
                    if (client.GetData("inventory") != null)
                    {
                        List<IItem> items = client.GetData("inventory");
                        if (i < items.Count && i>= 0)
                        {
                            if (items[i].DisplayName == itemName)
                                items[i].Drop(client);
                            else
                            {
                                SyncInventory(client, items);
                                client.TriggerEvent("shownotification", "Erro", "Ocorreu um erro ao tentar dropar um item no inventário. A sincronizar...");
                            }
                        }
                    }
                }
            }

        }
        public enum ItemTypes
        {
            Usable
        }
    }
}
