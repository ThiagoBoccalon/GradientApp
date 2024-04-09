using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace GradientApp
{    
    public static class ColorControls
    {
        public static List<Color> GetColours(Color from, Color to ,int totalNumberColours)
        {
            List<double> stepsToGetColours = new List<double>();
            List<Color> listColours = new List<Color>();

            if(totalNumberColours < 2)
                throw new ArgumentException("Gradient cannot have less than two colors.", "totalNumberOfColors");

            int total = totalNumberColours - 1;

            ColoursWithElementsSeparate colour = 
                new ColoursWithElementsSeparate(
                    ((to.A - from.A) / (double) total),
                    ((to.R - from.R) / (double) total),
                    ((to.G - from.G) / (double) total),
                    ((to.B - from.B) / (double) total));
                        

            int start = 1;
            listColours.Add(from);

            while(start < total)
            {
                listColours.Add(
                    Color.FromArgb(
                    thisColour(from.A, colour.alpha),
                    thisColour(from.R, colour.red),
                    thisColour(from.G, colour.green),
                    thisColour(from.B, colour.blue)));

                start += 1;
            }

            listColours.Add(to);
            return listColours;

            int thisColour(int fromColour, double stepColour)
            {
                return (int)Math.Round((double)fromColour + stepColour * (double)start);
            }                
        }
    }

    

    public struct ColoursWithElementsSeparate
    {
        public double alpha;
        public double red;
        public double green;
        public double blue;

        public ColoursWithElementsSeparate(double a, 
            double r, double g, double b)
        {
            alpha = CheckIsRight(a);
            red = CheckIsRight(r);
            green = CheckIsRight(g);
            blue = CheckIsRight(b);
        }

        private double CheckIsRight(double value)
        {
            if (value < 0)
                value = value;

            return value;
        }
    }
}
