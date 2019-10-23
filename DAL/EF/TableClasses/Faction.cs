using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.EF.TableClasses
{
    public class Faction
    {
        [Key]
        public string Faction_Name { get; set; }
        public string Faction_Owner { get; set; }
        // 0 - Normal , 1 - Policia , 2 - Hospital
        public int Faction_Type { get; set; }
        // Cargos da Faction - Máximo de 7 Cargos , Rank 1 = Líder.
        public string Faction_Rank1 { get; set; }
        public string Faction_Rank2 { get; set; }
        public string Faction_Rank3 { get; set; }
        public string Faction_Rank4 { get; set; }
        public string Faction_Rank5 { get; set; }
        public string Faction_Rank6 { get; set; }
        public string Faction_Rank7 { get; set; }
        // Faction Banco - Sugestão - Rank 3 + Pode mecher no dinheiro em caso de type normal.
        public int Faction_Banco { get; set; }
        // Faction Salarios - Ordenado por Ranks.
        public int Faction_Salary_1 { get; set; }
        public int Faction_Salary_2 { get; set; }
        public int Faction_Salary_3 { get; set; }
        public int Faction_Salary_4 { get; set; }
        public int Faction_Salary_5 { get; set; }
        public int Faction_Salary_6 { get; set; }
        public int Faction_Salary_7 { get; set; }
    }
}
