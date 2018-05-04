using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerGUI.Controlers    
{
    
    public class ImageControler
    {
        public InitWindow InitWindow { get; set; }
        public InputFormControler InputFormControler { get; set; }

        public ImageControler(InputFormControler inputFormControler)
        {
            InputFormControler = inputFormControler;
            InitWindow = new InitWindow(this);
        }

        



    }
}
