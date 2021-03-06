﻿using BeholderCaolho.AttributeManagerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var attrManager = new AttributeManager();
            attrManager
                .Add("Str", 10)
                .Add("modStr", 0)
                .AddDependency("modStr", "Str")
                .SetUpdate("modStr", () => { return (int)CalcMod(attrManager, "Str"); })
                .Add("Dex", 18)
                .Add("modDex", 0)
                .AddDependency("modDex", "Dex")
                .SetUpdate("modDex", () => { return (int)CalcMod(attrManager, "Dex"); })
                .Add("Con", 10)
                .Add("modCon", 0)
                .AddDependency("modCon", "Con")
                .SetUpdate("modCon", () => { return (int)CalcMod(attrManager, "Con"); })
                .Add("Int", 14)
                .Add("modInt", 0)
                .AddDependency("modInt", "Int")
                .SetUpdate("modInt", () => { return (int)CalcMod(attrManager, "Int"); })
                .Add("Wis", 14)
                .Add("modWis", 0)
                .AddDependency("modWis", "Wis")
                .SetUpdate("modWis", () => { return (int)CalcMod(attrManager, "Wis"); })
                .Add("Cha", 12)
                .Add("modCha", 0)
                .AddDependency("modCha", "Cha")
                .SetUpdate("modCha", () => { return (int)CalcMod(attrManager, "Cha"); })
                .Add("ArmorClass", 10)
                .SetUpdate("Classe de Armadura", () => 10 + attrManager["modDex"])
                .UpdateAll();

            attrManager.AddModifier("Dex", 4);

            Console.WriteLine("Str:\t{0}\t{1}", attrManager["Str"], attrManager["modStr"]);
            Console.WriteLine("Dex:\t{0}\t{1}", attrManager["Dex"], attrManager["modDex"]);
            Console.WriteLine("Con:\t{0}\t{1}", attrManager["Con"], attrManager["modCon"]);
            Console.WriteLine("Int:\t{0}\t{1}", attrManager["Int"], attrManager["modInt"]);
            Console.WriteLine("Wis:\t{0}\t{1}", attrManager["Wis"], attrManager["modWis"]);
            Console.WriteLine("Cha:\t{0}\t{1}", attrManager["Cha"], attrManager["modCha"]);

            Console.ReadKey();
        }

        private static float CalcMod(AttributeManager attrManager, string Attr)
        {
            return (float)Math.Floor((attrManager[Attr] - 10) / 2);
        }
    }
}
