using DAL.Classes;
using DAL.EF.TableClasses;
using DAL.TableClasses;
using DAL.TableRepository;
using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class Extensions
    {
        public static Character GetCharacter(this Client client)
        {
            if (client.GetSharedData("character") != null)
            {
                CharacterRepository repo = new CharacterRepository();
                Character c = repo.GetByName(client.GetSharedData("character"));
                return c;
            }
            else
                return null;
        }

        public static Account GetAccount(this Client client)
        {
            PlayerRepository repo = new PlayerRepository();
            Account c = repo.GetBySerial(client.Serial);
            if (c != null)
            {
                return c;
            }
            else
                return null;
        }

        public static bool IsLogged(this Client client)
        {
            if (client.GetData("logged") != null)
            {
                if (client.GetData("logged"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool UpdateCharacter(this Client client, Character character)
        {
            if (character != null)
            {
                try
                {
                    CharacterRepository repo = new CharacterRepository();
                    repo.Update(character);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        public static bool CreateCharacter(this Client client, Character character)
        {
            if (character != null)
            {
                try
                {
                    CharacterRepository repo = new CharacterRepository();
                    repo.Add(character);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        public static List<IItem> GetInventory(this Client client)
        {
            Character c = client.GetCharacter();
            if (c != null)
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
                    if (string.IsNullOrEmpty(c.Inventory))
                    {

                        return JsonConvert.DeserializeObject<List<IItem>>(c.Inventory, settings);
                    }
                    else
                        return new List<IItem>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            else
                return null;
        }

        public static void AddItem(this Client client, IItem item)
        {
            List<IItem> inventory = client.GetInventory();
            if (inventory != null)
            {
                inventory.Add(item);
            }
        }
    }
}
