using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using LuaInterface;

namespace WindowsFormsApplication1
{
    public class World
    {
        /// <summary>
        /// Collision Segments, aka paths 
        /// </summary>
        public ArrayList collision_segment = new ArrayList();
        
        /// <summary>
        /// Width of world
        /// </summary>
        public int width;

        /// <summary>
        /// Height of world
        /// </summary>
        public int height;
        
        /// <summary>
        /// Pixels per Unit
        /// </summary>
        public double ppu = 10;

        /// <summary>
        /// Units per pixel
        /// </summary>
        public double upp = 1 / 10;

        /// <summary>
        /// filename of world
        /// </summary>
        public string fname = "";
        
        /// <summary>
        /// Saves the world
        /// </summary>
        /// <param name="filename">save the world to a lua file</param>
        /// <returns></returns>
        public bool save(string filename)
        {
            string map = "world_data = {\n";
            map += "    width=" + width + ",\n";
            map += "    height=" + height + ",\n";
            map += "    paths = { ";
            foreach (ArrayList a in collision_segment)
            {
                string segment = "\n       {";
                foreach (Point p in a)
                {
                    segment += "{" + (p.X / ppu) + "," + ((p.Y) / ppu) + "},";
                }
                map += segment.Substring(0, segment.Length - 1) + "},";
            }
            map = map.Substring(0, map.Length - 1) + "\n  }";
            map += "}";
            StreamWriter writer = new StreamWriter(filename, false);
            writer.Write(map);
            writer.Close();
            return true;
            
        }

        /// <summary>
        /// Loads a world from a lua file
        /// </summary>
        /// <param name="filename">file to load the world from</param>
        /// <returns>true on success</returns>
        public bool load(string filename)
        {
            this.fname = filename;

            Lua lua = new Lua();
            var result = lua.DoFile(filename);
            foreach (DictionaryEntry member in lua.GetTable("world_data"))
            {
                if (member.Key.ToString() == "width")
                {
                    this.width = Convert.ToInt32(member.Value);
                }
                else if (member.Key.ToString() == "height")
                {
                    this.height = Convert.ToInt32(member.Value);
                }
                if (member.Key.ToString() == "paths")
                {
                    collision_segment = new ArrayList();
                    LuaTable paths = (LuaTable)member.Value;
                    foreach (DictionaryEntry path in paths)
                    {
                        ArrayList collision_path = new ArrayList();
                        LuaTable p = (LuaTable)path.Value;
                        foreach (DictionaryEntry point in p)
                        {
                            LuaTable point_data = (LuaTable)point.Value;
                            int x = Convert.ToInt32(point_data.Values.Cast<double>().ElementAt(0) * ppu);
                            int y = Convert.ToInt32(point_data.Values.Cast<double>().ElementAt(1) * ppu);
                            Console.WriteLine("X:" + x + ", Y:" + y);
                            collision_path.Add(new Point(x, y));
                        }
                        collision_segment.Add(collision_path);
                    }
                    
                }
            }
            return true;
        }
    }
}
