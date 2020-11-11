using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace OlympicWheels
{
    class CustomCanvas : Canvas
    {

        protected override void OnRender(DrawingContext dc)
        {
            List<SolidColorBrush> list = new List<SolidColorBrush>() { Brushes.Cyan, Brushes.Yellow, Brushes.Black, Brushes.Green, Brushes.Red };
            SolidColorBrush pensseli = new SolidColorBrush();    
            System.Windows.Point piste = new System.Windows.Point();
            piste.X = Width/3;      
            
            bool up = true;
            foreach (SolidColorBrush elem in list)
            {
                piste.Y = Height / 3;
                Pen kyna = new Pen();
                kyna.Thickness = 8;
                kyna.Brush = elem;
                if (up)
                {
                    dc.DrawEllipse(pensseli, kyna, piste, 50, 50);
                    up = false;
                } else
                {
                    piste.Y += 50;
                    dc.DrawEllipse(pensseli, kyna, piste, 50, 50);
                    up = true;
                }
                piste.X += 55;
               
            }
            
        }    

    }
}
