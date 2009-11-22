using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;

namespace WindowsFormsApplication1
{
    public class World
    {
        public ArrayList collision_segment = new ArrayList();
        public int width;
        public int height;
        public double ppu = 10;
        public double upp = 1 / 10;
        public string fname = "";
        
        public bool saveworld(string filename)
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
                    segment += "{" + (p.X / ppu) + "," + ((p.Y-this.height) / ppu) + "},";
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
    }
}
