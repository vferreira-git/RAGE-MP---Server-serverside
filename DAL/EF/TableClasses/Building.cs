using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.TableClasses
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float EnterX { get; set; }
        public float EnterY { get; set; }
        public float EnterZ { get; set; }
        public float ExitX { get; set; }
        public float ExitY { get; set; }
        public float ExitZ { get; set; }
        public uint EnterDimension { get; set; }
        public int EnterInterior { get; set; }
        public int ExitInterior { get; set; }
        [NotMapped]
        public uint ExitDimension
        {
            get
            {
                return (uint)Id + 10000;
            }
        }

        [NotMapped]
        public Vector3 EnterPosition
        {
            get
            {
                return new Vector3(EnterX, EnterY, EnterZ);
            }
        }
        [NotMapped]
        public Vector3 ExitPosition
        {
            get
            {
                return new Vector3(ExitX, ExitY, ExitZ);
            }
        }
        public Building()
        {
            Name = "";
        }
    }
}
