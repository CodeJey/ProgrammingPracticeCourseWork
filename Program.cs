using System;
using System.Collections.Generic;

namespace ProgrammingPracticeCourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Galaxy> galList = new List<Galaxy>();
            List<Star> starList = new List<Star>();
            List<Planet> planetList = new List<Planet>();
            List<Moon> moonList = new List<Moon>();
            for (;;)
            {
                string inp = (Console.ReadLine()).Trim();
                string[] input = (inp.Split(' '));
                if (input[0] == "add")
                {
                    switch(input[1])
                    {
                        case "galaxy":
                            string[] posGalTypes = {"elliptical", "lenticular", "spiral", "irregular"};
                            Galaxy newGal = new Galaxy();
                            newGal.Name = inp.Split('[')[1].Split(']')[0];
                            if (Array.Exists(posGalTypes, element => element == inp.Split(']')[1].Split(' ')[1]))
                            {
                                newGal.Type = inp.Split(']')[1].Split(' ')[1];
                            }
                            else 
                            {
                                newGal.Type = "unknown";
                            }
                            newGal.Age = (inp.Split(']')[1].Split(' ')[2]);
                            galList.Add(newGal);
                                break;
                        case "star":
                            Star newStar = new Star();
                            newStar.ParentName = inp.Split('[')[1].Split(']')[0];
                            newStar.Name = inp.Split('[')[2].Split(']')[0];
                            newStar.Clas = inp.Split(']')[2].Trim();
                            starList.Add(newStar);
                                break;
                        case "planet":
                            string[] posPlTypes = {"terrestrial", "giant planet", "ice giant", "mesoplanet", "mini-neptune", "planetar", "super-earth", "super-jupiter", "sub-earth"};
                            Planet newPlanet = new Planet();
                            newPlanet.ParentName = inp.Split('[')[1].Split(']')[0];
                            newPlanet.Name = inp.Split('[')[2].Split(']')[0];
                            string dat = inp.Split(']')[2].Trim();
                            if (Array.Exists(posPlTypes, val => val == dat.Remove(dat.Length-3).Trim()))
                            {
                                newPlanet.Data = dat;
                            }
                            else 
                            {
                                newPlanet.Data = "unknown " + dat.Split(' ')[dat.Split(' ').Length - 1];
                            }
                            planetList.Add(newPlanet);
                                break;
                        case "moon": 
                            Moon newMoon = new Moon();
                            newMoon.ParentName = inp.Split('[')[1].Split(']')[0];
                            newMoon.Name = inp.Split('[')[2].Split(']')[0];
                            moonList.Add(newMoon);
                            break;
                        default: 
                            continue;
                    }
                }
                else if(input[0] == "stats")
                {
                    Console.WriteLine("--- Stats ---");
                    Console.WriteLine($"Galaxies: {galList.Count}");
                    Console.WriteLine($"Stars: {starList.Count}");
                    Console.WriteLine($"Planets: {planetList.Count}");
                    Console.WriteLine($"Moons: {moonList.Count}");
                    Console.WriteLine("--- End of stats ---");
                }
                else if(input[0] == "list")
                {
                    string allObjFromType = "";
                    switch(input[1])
                    {
                        case "galaxies": 
                            Console.WriteLine("--- List of all researched galaxies ---");
                            foreach (var g in galList){allObjFromType += g.Name +  ", ";}
                            Console.WriteLine(allObjFromType.Remove(allObjFromType.Length - 2, 2));
                            Console.WriteLine("--- End of galaxies list ---");
                            break;
                        case "stars":
                            Console.WriteLine("--- List of all researched stars ---");
                            foreach (var s in starList){allObjFromType += s.Name +  ", ";}
                            Console.WriteLine(allObjFromType.Remove(allObjFromType.Length - 2, 2));
                            Console.WriteLine("--- End of stars list ---");
                            break;
                        case "planets":
                            Console.WriteLine("--- List of all researched planets ---");
                            foreach (var p in planetList){allObjFromType += p.Name +  ", ";}
                            Console.WriteLine(allObjFromType.Remove(allObjFromType.Length - 2, 2));
                            Console.WriteLine("--- End of planets list ---");
                            break;
                        case "moons":
                            Console.WriteLine("--- List of all researched moons ---");
                            foreach (var m in moonList){allObjFromType += m.Name +  ", ";}
                            Console.WriteLine(allObjFromType.Remove(allObjFromType.Length - 2, 2));
                            Console.WriteLine("--- End of moons list ---");
                            break;
                        default:
                            Console.WriteLine("none");
                            break;
                    }
                }
                else if (input[0] == "print")
                {
                    string gal = inp.Split('[')[1].Split(']')[0];
                    if(galList.Exists(f => f.Name == gal))
                    {
                        Galaxy foundG = galList.Find(g => g.Name == gal);
                        Console.WriteLine($"--- Data for {gal} galaxy ---");
                        Console.WriteLine("Type: " + foundG.Type);
                        Console.WriteLine("Age: " + foundG.age);    
                        Console.WriteLine("Stars: ");
                        if (!starList.Exists(s => s.ParentName == gal)) 
                        {
                            Console.WriteLine("      none");
                            Console.WriteLine("      Planets:");
                            Console.WriteLine("              none");
                            Console.WriteLine("              Moons: ");
                            Console.WriteLine("                    none");
                        }
                        else 
                        {
                            foreach(Star st in starList)
                            {
                                if(st.ParentName == gal)
                                {
                                    Console.WriteLine("      Name: " + st.Name);
                                    Console.WriteLine("      Class: " + st.Clas);
                                    Console.WriteLine("      Planets:");
                                    if (!planetList.Exists(p => p.ParentName == st.Name)) 
                                    {
                                    Console.WriteLine("              none");
                                        Console.WriteLine("              Moons: ");
                                        Console.WriteLine("                    none");
                                    }
                                    else 
                                    {
                                        foreach(Planet pl in planetList)
                                        {
                                            if(pl.ParentName == st.Name)
                                            {
                                        Console.WriteLine("              Name: " + pl.Name);
                                        Console.WriteLine("              Type: " + pl.Data.Remove(pl.Data.Length-3).Trim());
                                        Console.WriteLine("              Support life: " + pl.Data.Split(' ')[pl.Data.Split(' ').Length - 1]);
                                        Console.WriteLine("              Moons: ");
                                                if (!moonList.Exists(m => m.ParentName == pl.Name)) Console.WriteLine("                    none");
                                                else
                                                {
                                                    foreach(Moon mn in moonList)
                                                    {
                                                        if(mn.ParentName == pl.Name)
                                                        {
                                                            Console.WriteLine("                    " + mn.Name);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }  
                            }
                        }
                        Console.WriteLine($"--- End of data for {gal} galaxy ---");
                    }
                    else Console.WriteLine("none");
                }
                else if (input[0] == "exit") break;
            }
        }
    }
}
