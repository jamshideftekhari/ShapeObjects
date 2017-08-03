using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geomety.Model
{
    class Ellips
    {
        public string Fill { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string CanvasLeft { get; set; }
        public string CanvasTop { get; set; }

        public Ellips()
        {
            Fill = "#FFE01B8F";
            Height = "50";
            Width = "50";
            CanvasTop = "250";
            CanvasLeft = "200";

        }

        public Ellips(int top, int left)
        {
            Fill = "#FFE01B8F";
            Height = "50";
            Width = "50";
            CanvasLeft = (left).ToString();
            CanvasTop = (top).ToString();
        }

        public void SetCoordinate(int top, int left)
        {
            CanvasLeft = (int.Parse(CanvasLeft) + left).ToString();
            if (int.Parse(CanvasLeft) > 420)
                CanvasLeft = "0";
            CanvasTop = (int.Parse(CanvasTop) + top).ToString();
            if (int.Parse(CanvasTop) > 393)
                CanvasTop = "0";

        }
    }
}
