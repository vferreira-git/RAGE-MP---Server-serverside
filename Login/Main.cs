using DAL.EF;
using DAL.TableClasses;
using DAL.TableRepository;
using GTANetworkAPI;
using System;
using System.Linq;
using System.Net.Mail;

namespace Login
{
    public class Main : Script
    {
        public Main()
        {
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetDefaultSpawnLocation(new Vector3(-219, 6174, 31));
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

        [RemoteEvent("login")]
        public void Login(Client client, object[] args)
        {
            DALContext _context = new DALContext();
            Account byUsername = new PlayerRepository().GetByUsername(args[0].ToString());
            if (byUsername == null || !(byUsername.Password == args[1].ToString()))
            {
                client.TriggerEvent("shownotification", "Erro", "Nome de utilizador ou password errada.");
                return;
            }
            if (bool.Parse(args[2].ToString()))
                _context.Accounts.Find(args[0].ToString()).remember = true;
            _context.SaveChanges();
            client.TriggerEvent("OnLoginRegister");
            client.Name = byUsername.Username;
            client.SetSharedData("logged", true);
            ClientLoggedIn(client, byUsername);

        }

        public void ClientLoggedIn(Client client, Account acc)
        {
            client.TriggerEvent("callserverfunc", "showcharselect");
        }



        [RemoteEvent("register")]
        public void Register(Client client, object[] args)
        {
            PlayerRepository playerRepository = new PlayerRepository();
            if (playerRepository.GetByUsername(args[0].ToString()) != null)
            {
                Console.WriteLine("adwad");
                client.TriggerEvent("shownotification", "Erro", "Nome de utilizador já se encontra em uso.");
                return;
            }
            playerRepository.Add(new Account()
            {
                Username = args[0].ToString(),
                Password = args[1].ToString(),
                Email = args[2].ToString(),
                serial = client.Serial
            });
            client.Name = args[0].ToString();
            client.TriggerEvent("OnLoginRegister");
            client.TriggerEvent("callserverfunc", "showcharselect", "");
        }
        

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnect(Client client)
        {
            client.TriggerEvent("chat:show", false);
            client.Dimension = client.Handle.Value;
            try
            {
                DALContext _context = new DALContext();
                Account acc = _context.Accounts.SingleOrDefault(x => x.serial == client.Serial) ?? null;
                if (acc != null)
                {
                    if (acc.remember)
                    {
                        client.SetSharedData("logged", true);
                        ClientLoggedIn(client, acc);
                        client.TriggerEvent("autologgedin");
                    }
                    else
                    {
                        client.TriggerEvent("showlogin");
                        client.TriggerEvent("logincamera");
                    }
                }
                else
                {
                    client.TriggerEvent("showlogin");
                    client.TriggerEvent("logincamera");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
