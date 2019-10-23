using GTANetworkAPI;
using GTANetworkMethods;
using DAL.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EF.TableClasses;
using DAL.TableRepository;

namespace Main
{
    public class Main : Script
    {
        public Main()
        {
            NAPI.Server.SetGlobalServerChat(false);
            NAPI.Task.Run(StatsRequest, 60000);
        }

        private void StatsRequest()
        {
            foreach (Client client in NAPI.Pools.GetAllPlayers())
            {
                if (client != null)
                {
                    client.TriggerEvent("requeststats");
                    NAPI.Task.Run(StatsRequest, 60000);
                }
            }
        }

        [Command("restartall")]
        public void Restart(Client client)
        {
            foreach (string s in NAPI.Resource.GetRunningResources())
            {
                NAPI.Resource.StopResource(s);
                NAPI.Resource.StartResource(s);
            }
        }

        [Command("time")]
        public void Time(Client client, int time)
        {
            NAPI.World.SetTime(time,0,0);
        }

        [Command("weather")]
        public void Weather(Client client, int weather)
        {
            NAPI.World.SetWeather(Enum.GetName(typeof(GTANetworkAPI.Weather),weather));
        }

        [RemoteEvent("updatehungerthirst")]
        public void UpdateHungerThirst(Client client, object[] args)
        {
            if (float.TryParse(args[0].ToString(), out float i) && float.TryParse(args[1].ToString(), out float j))
            {
                CharacterRepository repo = new CharacterRepository();
                if (client.GetSharedData("character") != null)
                {
                    Character c = repo.GetByName(client.GetSharedData("character"));
                    if (c != null)
                    {
                        c.Hunger = i;
                        c.Thirst = j;
                        repo.Update(c);
                    }
                }
            }
        }

        [Command("car")]
        public void createcar(Client client, string model)
        {
            if (NAPI.Util.GetHashKey(model) != 0)
            {
                GTANetworkAPI.Vehicle vehicle = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(model), client.Position, 0.0f, 255, 255, "", 255, false, true, 0);
                NAPI.Player.SetPlayerIntoVehicle(client, vehicle, -1);
                client.TriggerEvent("shownotification", "Crias-te o veiculo " + model + " com sucesso!");
            }
        }

        [Command("ks")]
        public void KillSelf(Client client)
        {
            client.Kill();
        }

        [Command("goto")]
        public void GoTo(Client client, string name)
        {
            Client c = NAPI.Pools.GetAllPlayers().Find(x => x.Name.ToLower().Contains(name.ToLower()));
            if (c != null)
                client.Position = c.Position + new Vector3(5, 0, 0);
        }

        [ServerEvent(Event.ChatMessage)]
        public void OnChatMessage(Client player, string message)
        {
            player.SendChatMessage("!{255,255,171,255}" + player.Name + ": !{255,255,255,255}" + message);
            IEnumerable<GTANetworkAPI.Client> playersNear = NAPI.Pools.GetAllPlayers().Where(x => x.Position.DistanceTo(player.Position) <= 30);
            foreach (Client c in playersNear)
            {
                if (player.Serial != c.Serial)
                {
                    int color = (int)(255 - ((c.Position.DistanceTo(player.Position) / 30) * 180));
                    NAPI.Chat.SendChatMessageToPlayer(c, "!{255, 255, 171,255}" + player.Name + ": !{" + color.ToString() + "," + color.ToString() + "," + color.ToString() + ",255}" + message);
                }
            }
            return;
        }

        [Command("mod")]
        public void carmod(Client client, int modType, int modIndex)
        {
            client.Vehicle.SetMod(modType, modIndex);
        }

        [Command("cameracoords")]
        public void CameraCoords(Client client)
        {
            client.SendChatMessage("Coordenadas: X:" + client.Position.X + "  Y:" + client.Position.Y + "  Z:" + client.Position.Z);
            client.SendChatMessage("Rotaçao: X:" + client.Rotation.X + "  Y:" + client.Rotation.Y + "  Z:" + client.Rotation.Z);
        }

        [RemoteEvent("gf:me")]
        [Command("me", GreedyArg = true)]
        public static void MeMessage(Client client, string message)
        {
            IEnumerable<GTANetworkAPI.Client> playersNear = NAPI.Pools.GetAllPlayers().Where(x => x.Position.DistanceTo(client.Position) <= 30);
            foreach (Client c in playersNear)
            {
                NAPI.Chat.SendChatMessageToPlayer(client, "!{206, 69, 255,255}" + client.Name + " " + message);
            }
        }

        [Command("test")]
        public void Test(Client client,int i)
        {
            client.TriggerEvent("test", i);
            NAPI.Native.SendNativeToPlayer(client, 0x8B7FD87F0DDB421E, false);
        }

        [Command("test2")]
        public void Test2(Client client,int i)
        {
            client.TriggerEvent("test2", i);

        }

        [Command("tentar", GreedyArg = true)]
        public static void TentarMessage(Client client, string message)
        {
            IEnumerable<GTANetworkAPI.Client> playersNear = NAPI.Pools.GetAllPlayers().Where(x => x.Position.DistanceTo(client.Position) <= 30);
            foreach (Client c in playersNear)
            {
                Random rand = new Random();
                double d = rand.NextDouble();
                NAPI.Chat.SendChatMessageToPlayer(client, "!{206, 69, 255,255}" + client.Name + " tenta " + message + " e " + (d <= 0.5 ? "falha." : "consegue."));
            }
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

        [ServerEvent(Event.VehicleDeath)]
        public void OnVehicleDeath(GTANetworkAPI.Vehicle vehicle)
        {
            vehicle.Delete();
        }

        [Command("weapon")]
        public void WeaponCommand(Client sender, WeaponHash hash)
        {
            NAPI.Player.GivePlayerWeapon(sender, hash, 500);
        }
    }
}