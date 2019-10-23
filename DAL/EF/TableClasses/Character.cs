using DAL.TableClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace DAL.EF.TableClasses
{
    public class Character
    {
        public string Account { get; set; }
        public string AccountSerial { get; set; }
        public string Skin { get; set; }
        public int Dinheiro { get; set; }
        public int Banco { get; set; }
        public int Faction { get; set; }
        [Key]
        public string Name { get; set; }

        public float LastX { get; set; }
        public float LastY { get; set; }
        public float LastZ { get; set; }
        public uint Dimension { get; set; }
        public float Rotation { get; set; }
        public string Inventory { get; set; }
        public bool CartaLigeiros { get; set; }
        public bool CartaPesados { get; set; }
        public bool CartaMota { get; set; }
        public int Health { get; set; }
        public float Hunger { get; set; }
        public float Thirst { get; set; }

        [NotMapped]
        public Vector3 LeavePosition
        {
            get
            {
                return new Vector3(LastX, LastY, LastZ);
            }
            set
            {
                LeavePosition = value;
            }
        }
    }
}
