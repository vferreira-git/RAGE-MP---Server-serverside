using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using CharacterCustomization.Classes;
using System.Collections.Generic;
using DAL.EF;
using DAL.TableRepository;
using DAL.EF.TableClasses;
using DAL.TableClasses;

namespace CharacterCustomization
{
    public class Main : Script
    {
        public Main()
        {

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

        [RemoteEvent("finishcc")]
        public void FinishCC(Client client, object[] args)
        {
            CharacterRepository repo = new CharacterRepository();
            PlayerRepository pRepo = new PlayerRepository();
            Character c = new Character();
            Account a = pRepo.GetBySerial(client.Serial);
            if (a != null)
            {
                c.Skin = args[0].ToString();
                c.Name = args[1].ToString();
                c.Account = a.Username;
                c.AccountSerial = a.serial;
                repo.Add(c);
                client.TriggerEvent("closecc");
                ShowCharSelect(client);

            }
        }

        [Flags]
        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        }

        [RemoteEvent("IdleAnim")]
        public void IdleAnim(Client client)
        {
            //client.PlayAnimation("mp_arresting", "idle",)
            //    NAPI.Player.PlayPlayerAnimation(client, AnimationFlags.Loop);
        }

        [RemoteEvent("selectchar")]
        public void SelectCharacter(Client client, object[] args)
        {
            string charname = args[0].ToString();
            CharacterRepository repo = new CharacterRepository();
            Character c = repo.GetByName(charname);
            if (c.Skin != null)
                LoadClientSkin(client, c.Skin);
            else
                LoadDefaultSkin(client);
            client.TriggerEvent("closecc");
            client.Name = c.Name;
            client.Nametag = c.Name;
            client.SetSharedData("character", c.Name);
            client.Health = c.Health;
            client.TriggerEvent("initialhungerthirst", c.Hunger, c.Thirst);
            if (c.LastX == 0 && c.LastY == 0 && c.LastZ == 0)
            {
                client.Position = new Vector3(-279, 6271, 31);
                client.Rotation = new Vector3(0, 0, 224);
                client.Dimension = 0;
            }
            else
            {
                client.Position = new Vector3(c.LastX, c.LastY, c.LastZ);
                client.Rotation = new Vector3(0, 0, c.Rotation);
                client.Dimension = c.Dimension;
            }
            client.TriggerEvent("characterselected");
            client.TriggerEvent("chat:show", true);
            client.SetSharedData("spawned", true);
        }

        [RemoteEvent("checkcharname")]
        public void CheckCharName(Client client, object[] args)
        {
            CharacterRepository repo = new CharacterRepository();
            if (repo.GetByName(args[0].ToString()) != null)
            {
                client.TriggerEvent("shownotification", "Erro", "Esse nome de personagem já se encontra em uso,");
                return;
            }
            client.TriggerEvent("cc");
        }

        [RemoteEvent("showcharselect")]
        public void ShowCharSelect(Client client)
        {
            CharacterRepository repo = new CharacterRepository();
            PlayerRepository pRepo = new PlayerRepository();
            List<string> charNames = new List<string>();
            foreach (Character ch in repo.GetAllByAccount(pRepo.GetBySerial(client.Serial)))
            {
                charNames.Add(ch.Name);
            }
            client.TriggerEvent("showcharselect", charNames);
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Client client, DisconnectionType type, string reason)
        {
            try
            {

                if (client.GetSharedData("spawned"))
                {
                    CharacterRepository repo = new CharacterRepository();
                    Character c = repo.GetByName(client.GetSharedData("character"));
                    c.LastX = client.Position.X;
                    c.LastY = client.Position.Y;
                    c.LastZ = client.Position.Z;
                    repo.Update(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        [RemoteEvent("loaddefaultskin")]
        private void LoadDefaultSkin(Client client)
        {
            Dictionary<int, GTANetworkAPI.HeadOverlay> headoverlays = new Dictionary<int, GTANetworkAPI.HeadOverlay>();
            for (int i = 0; i < 13; i++)
            {
                headoverlays.Add(i, new GTANetworkAPI.HeadOverlay());
            }
            client.SetCustomization(true, new HeadBlend() { }, 0, 0, 0, new float[20], headoverlays, new Decoration[0]);
            Dictionary<int, GTANetworkAPI.ComponentVariation> clothes = new Dictionary<int, GTANetworkAPI.ComponentVariation>();
            for (int i = 0; i < 12; i++)
            {
                clothes.Add(i, new GTANetworkAPI.ComponentVariation());
            }
            client.SetClothes(clothes);
        }

        [RemoteEvent("loadskin")]
        public void LoadClientSkin(Client client, string skinJson)
        {
            Skin skin = JsonConvert.DeserializeObject<Skin>(skinJson);
            Dictionary<int, GTANetworkAPI.HeadOverlay> headoverlays = new Dictionary<int, GTANetworkAPI.HeadOverlay>();
            int i = 0;
            foreach (Classes.HeadOverlay ho in skin.headOverlay)
            {
                headoverlays.Add(i, new GTANetworkAPI.HeadOverlay() { Index = (byte)ho.index, Opacity = 1, Color = (byte)ho.color1, SecondaryColor = (byte)ho.color2 });
                i++;
            }
            client.SetCustomization(skin.isMale, new HeadBlend() { }, 0, (byte)skin.hairColor, (byte)skin.hairColor2, skin.faceFeature.ToArray(), headoverlays, new Decoration[0]);
            Dictionary<int, GTANetworkAPI.ComponentVariation> clothes = new Dictionary<int, GTANetworkAPI.ComponentVariation>();
            i = 0;
            foreach (Classes.ComponentVariation cv in skin.componentVariation)
            {
                clothes.Add(i, new GTANetworkAPI.ComponentVariation() { Drawable = cv.drawableId, Texture = cv.textureId });
                i++;
            }
            client.SetClothes(clothes);
            i = 0;
            foreach (PropIndex pi in skin.propIndex)
            {
                client.SetAccessories(i, pi.drawableId, pi.textureId);
                i++;
            }
        }


    }
}
