using DAL.EF;
using DAL.TableClasses;
using DAL.TableRepository;
using GTANetworkAPI;
using System;
using System.Collections.Generic;
using static Interiors.InteriorsMain;

namespace Buildings
{
    public class BuildingsMain : Script
    {
        public BuildingsMain()
        {
            LoadBuildings();

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

        private void LoadBuildings()
        {
            BuildingRepository repo = new BuildingRepository();
            foreach (Building b in repo.GetAllList())
            {
                Marker EnterMarker = NAPI.Marker.CreateMarker(1, new Vector3(b.EnterX, b.EnterY, b.EnterZ - 1), new Vector3(), new Vector3(), 1.5f, new Color(255, 255, 255), true, 0);
                Marker ExitMarker = NAPI.Marker.CreateMarker(1, new Vector3(b.ExitX, b.ExitY, b.ExitZ - 1), new Vector3(), new Vector3(), 1.5f, new Color(255, 255, 255), true, b.ExitDimension);
                ColShape EnterShape = NAPI.ColShape.CreateCylinderColShape(new Vector3(b.EnterX, b.EnterY, b.EnterZ - 1), 1.5f, 1.5f, b.EnterDimension);
                ColShape ExitShape = NAPI.ColShape.CreateCylinderColShape(new Vector3(b.ExitX, b.ExitY, b.ExitZ - 1), 1.5f, 1.5f, b.ExitDimension);
                TextLabel EnterLabel = NAPI.TextLabel.CreateTextLabel(b.Name, b.EnterPosition, 10, 1, 0, new Color(255, 255, 255), true, b.EnterDimension);
                TextLabel ExitLabel = NAPI.TextLabel.CreateTextLabel("[SAIDA]", b.ExitPosition, 10, 1, 0, new Color(255, 255, 255), true, b.ExitDimension);

                EnterMarker.SetData("buildingid", b.Id);
                EnterMarker.SetData("isentrance", true);
                ExitMarker.SetData("buildingid", b.Id);
                ExitMarker.SetData("isentrance", false);
                EnterShape.SetData("buildingid", b.Id);
                EnterShape.SetData("isentrance", true);
                EnterShape.SetData("type", "building");
                ExitShape.SetData("buildingid", b.Id);
                ExitShape.SetData("isentrance", false);
                ExitShape.SetData("type", "building");
                EnterLabel.SetData("buildingid", b.Id);
                EnterLabel.SetData("isentrance", true);
                ExitLabel.SetData("buildingid", b.Id);
                ExitLabel.SetData("isentrance", false);
            }
        }

        [Command("dimension")]
        public void SetDimension(Client client, uint dimension)
        {
            client.Dimension = dimension;
        }

        [Command("createbuilding")]
        public void CreateBuilding(Client client, string Name, uint interior)
        {
            BuildingRepository repo = new BuildingRepository();
            Building b = new Building();
            b.Name = Name;
            b.ExitInterior = (int)interior;
            b.EnterInterior = int.Parse(client.GetData("CurrentInterior") != null ? ((int)client.GetData("CurrentInterior")).ToString() : "-1");
            Vector3 EnterPos = client.Position;
            Vector3 ExitPos = GetInteriorPos(interior);
            b.EnterX = EnterPos.X;
            b.EnterY = EnterPos.Y;
            b.EnterZ = EnterPos.Z;
            b.ExitX = ExitPos.X;
            b.ExitY = ExitPos.Y;
            b.ExitZ = ExitPos.Z;
            b.EnterDimension = client.Dimension;
            repo.Add(b);

            Marker EnterMarker = NAPI.Marker.CreateMarker(1, new Vector3(b.EnterX, b.EnterY, b.EnterZ - 1), new Vector3(), new Vector3(), 1.5f, new Color(255, 255, 255), true, b.EnterDimension);
            Marker ExitMarker = NAPI.Marker.CreateMarker(1, new Vector3(b.ExitX, b.ExitY, b.ExitZ - 1), new Vector3(), new Vector3(), 1.5f, new Color(255, 255, 255), true, b.ExitDimension);
            ColShape EnterShape = NAPI.ColShape.CreateCylinderColShape(new Vector3(b.EnterX, b.EnterY, b.EnterZ - 1), 1.5f, 1.5f, b.EnterDimension);
            ColShape ExitShape = NAPI.ColShape.CreateCylinderColShape(new Vector3(b.ExitX, b.ExitY, b.ExitZ - 1), 1.5f, 1.5f, b.ExitDimension);
            TextLabel EnterLabel = NAPI.TextLabel.CreateTextLabel(b.Name, b.EnterPosition, 10, 1, 0, new Color(255, 255, 255), true, b.EnterDimension);
            TextLabel ExitLabel = NAPI.TextLabel.CreateTextLabel("[SAIDA]", b.ExitPosition, 10, 1, 0, new Color(255, 255, 255), true, b.ExitDimension);

            EnterMarker.SetData("buildingid", b.Id);
            EnterMarker.SetData("isentrance", true);
            ExitMarker.SetData("buildingid", b.Id);
            ExitMarker.SetData("isentrance", false);
            EnterShape.SetData("buildingid", b.Id);
            EnterShape.SetData("isentrance", true);
            EnterShape.SetData("type", "building");
            ExitShape.SetData("buildingid", b.Id);
            ExitShape.SetData("isentrance", false);
            ExitShape.SetData("type", "building");
            EnterLabel.SetData("buildingid", b.Id);
            EnterLabel.SetData("isentrance", true);
            ExitLabel.SetData("buildingid", b.Id);
            ExitLabel.SetData("isentrance", false);

        }



        [Command("setbuildingentrance")]
        public void SetBuildingEntrance(Client client, int building)
        {
            BuildingRepository repo = new BuildingRepository();
            Building b = repo.GetByIndex(building);
            if (b != null)
            {
                b.EnterX = client.Position.X;
                b.EnterY = client.Position.Y;
                b.EnterZ = client.Position.Z;
                b.EnterDimension = client.Dimension;

                List<ColShape> shapes = NAPI.Pools.GetAllColShapes();
                ColShape shape = shapes.Find(x => x.GetData("buildingid") == b.Id && x.GetData("isentrance") == true);
                if (shape != null)
                {
                    shape.Delete();
                    ColShape EnterShape = NAPI.ColShape.CreateCylinderColShape(new Vector3(b.EnterX, b.EnterY, b.EnterZ - 1), 1.5f, 1.5f, b.EnterDimension);
                    EnterShape.SetData("buildingid", b.Id);
                    EnterShape.SetData("isentrance", true);
                    EnterShape.SetData("type", "building");
                }


                List<Marker> markers = NAPI.Pools.GetAllMarkers();
                Marker marker = markers.Find(x => x.GetData("buildingid") == b.Id && x.GetData("isentrance") == true);
                if (marker != null)
                {
                    marker.Position = b.EnterPosition - new Vector3(0, 0, 1);
                    marker.Dimension = b.EnterDimension;
                }

                List<TextLabel> labels = NAPI.Pools.GetAllTextLabels();
                TextLabel label = labels.Find(x => x.GetData("buildingid") == b.Id && x.GetData("isentrance") == true);
                if (label != null)
                {
                    label.Delete();
                    TextLabel EnterLabel = NAPI.TextLabel.CreateTextLabel(b.Name, b.EnterPosition, 10, 1, 0, new Color(255, 255, 255), true, b.EnterDimension);
                    EnterLabel.SetData("buildingid", b.Id);
                    EnterLabel.SetData("isentrance", true);
                }
                repo.Update(b);
            }
        }

        [Command("getbuildingid")]
        public void GetBuildingId(Client client)
        {
            if (client.GetData("CurrentBuilding") >= 0)
            {
                client.SendChatMessage("Building Id: " + client.GetData("CurrentBuilding"));
            }
        }

        [Command("setbuildingexit")]
        public void SetBuildingExit(Client client, int building)
        {
            BuildingRepository repo = new BuildingRepository();
            Building b = repo.GetByIndex(building) ?? null;
            if (b != null)
            {
                b.ExitX = client.Position.X;
                b.ExitY = client.Position.Y;
                b.ExitZ = client.Position.Z;

                List<ColShape> shapes = NAPI.Pools.GetAllColShapes();
                ColShape shape = shapes.Find(x => x.GetData("buildingid") == b.Id && x.GetData("isentrance") == false);
                if (shape != null)
                {
                    shape.Delete();
                    ColShape ExitShape = NAPI.ColShape.CreateCylinderColShape(new Vector3(b.ExitX, b.ExitY, b.ExitZ - 1), 1.5f, 1.5f, b.ExitDimension);
                    ExitShape.SetData("buildingid", b.Id);
                    ExitShape.SetData("isentrance", false);
                    ExitShape.SetData("type", "building");
                }

                List<Marker> markers = NAPI.Pools.GetAllMarkers();
                Marker marker = markers.Find(x => x.GetData("buildingid") == b.Id && x.GetData("isentrance") == false);
                if (marker != null)
                {
                    marker.Position = b.ExitPosition - new Vector3(0, 0, 1);
                    marker.Dimension = b.ExitDimension;
                }

                List<TextLabel> labels = NAPI.Pools.GetAllTextLabels();
                TextLabel label = labels.Find(x => x.GetData("buildingid") == b.Id && x.GetData("isentrance") == false);
                if (label != null)
                label.Delete();

                TextLabel ExitLabel = NAPI.TextLabel.CreateTextLabel("[SAIDA]", b.ExitPosition, 10, 1, 0, new Color(255, 255, 255), true, b.ExitDimension);
                ExitLabel.SetData("buildingid", b.Id);
                ExitLabel.SetData("isentrance", false);

                repo.Update(b);
            }

        }

        [Command("buildings")]
        public void GetBuildings(Client client)
        {
            BuildingRepository repo = new BuildingRepository();
            foreach (Building b in repo.GetAll())
            {
                client.SendChatMessage($"Building Name:{b.Name}  Id:{b.Id}");
            }
        }

        [Command("deletebuilding")]
        public void DeleteBuilding(Client client, int id = -5)
        {
            BuildingRepository repo = new BuildingRepository();
            int buildingid = id >= 0 ? id : (client.GetData("CurrentBuilding") >= 0 ? client.GetData("CurrentBuilding") : -5);
            if (buildingid < 0)
            {
                client.TriggerEvent("shownotification", "Erro", "Fornece um ID de um edifício ou fica em cima da entrada/saída de um.");
                return;
            }
            Building b = repo.GetByIndex(buildingid) ?? null;
            if (b == null)
            {
                client.TriggerEvent("shownotification", "Erro", "ID inválido.");
                return;
            }
            repo.Remove(b);

            foreach (Marker m in NAPI.Pools.GetAllMarkers().FindAll(x => x.GetData("buildingid") == b.Id))
            {
                m.Delete();
            }
            foreach (ColShape m in NAPI.Pools.GetAllColShapes().FindAll(x => x.GetData("buildingid") == b.Id))
            {
                m.Delete();
            }
            foreach (TextLabel m in NAPI.Pools.GetAllTextLabels().FindAll(x => x.GetData("buildingid") == b.Id))
            {
                m.Delete();
            }
            foreach (Building child in repo.GetAllList().FindAll(x => x.EnterDimension == b.ExitDimension))
            {
                foreach (Marker m in NAPI.Pools.GetAllMarkers().FindAll(x => x.GetData("buildingid") == child.Id))
                {
                    m.Delete();
                }
                foreach (ColShape m in NAPI.Pools.GetAllColShapes().FindAll(x => x.GetData("buildingid") == child.Id))
                {
                    m.Delete();
                }
                foreach (TextLabel m in NAPI.Pools.GetAllTextLabels().FindAll(x => x.GetData("buildingid") == child.Id))
                {
                    m.Delete();
                }
                repo.Remove(child);
            }
            client.TriggerEvent("shownotification", "Edifício apagado com sucesso!");
        }


        [ServerEvent(Event.PlayerEnterColshape)]
        public void OnPlayerEnterColShape(ColShape shape, Client player)
        {
            if (shape.GetData("buildingid") != null && shape.GetData("type") == "building")
            {
                player.SetData("CurrentBuilding", shape.GetData("buildingid"));
                player.SetData("IsBuildingEntrance", shape.GetData("isentrance"));
            }

        }

        [ServerEvent(Event.PlayerExitColshape)]
        public void OnPlayerExitColShape(ColShape shape, Client player)
        {
            if (shape.GetData("buildingid") != null)
            {
                player.SetData("CurrentBuilding", -5);
            }
        }

        [Command("gotointerior")]
        public void GotoInterior(Client client, uint i)
        {
            TeleportInterior(client, i);
        }

        [RemoteEvent("checkbuilding")]
        public void CheckOnBuilding(Client client)
        {
            if (client.GetData("CurrentBuilding") >= 0)
            {
                BuildingRepository repo = new BuildingRepository();
                Building b = repo.GetByIndex(client.GetData("CurrentBuilding")) ?? null;
                if (b != null)
                {
                    if (client.GetData("IsBuildingEntrance"))
                    {
                        LoadInterior(client, (uint)b.ExitInterior);
                        client.Position = b.ExitPosition;
                        client.Dimension = b.ExitDimension;
                        client.SetData("CurrentInterior", b.ExitInterior);
                    }
                    else
                    {
                        if (b.EnterInterior >= 0)
                            LoadInterior(client, (uint)b.EnterInterior);
                        client.Dimension = b.EnterDimension;
                        client.Position = b.EnterPosition;
                        client.SetData("CurrentInterior", b.EnterInterior);
                    }
                }
            }
        }
    }
}
