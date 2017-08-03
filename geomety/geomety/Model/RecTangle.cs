using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace geomety.Model
{
    public class Rectangle
    {
        public string Fill { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string CanvasLeft { get; set; }
        public string CanvasTop { get; set; }

        public Rectangle()
        {
            Fill = "#FFE01B8F";
            Height = "50";
            Width = "50";
            CanvasTop = "200";
            CanvasLeft = "0";
            
        }

        public void CanvasLeftValue()
        {
            for (int i = 0; i < 900; i++)
            {
                CanvasLeft = "i + 10";
                Task.Delay(1000);
            }
        }
    }
}
