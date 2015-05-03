using System.Collections.Generic;
using System.Linq;

namespace APP.Model
{
    public class Mask
    {
        public Mask(int height, int width)
        {
            Height = height;
            Width = width;
            var tempMaskMap = Pylek.Values.ToDictionary(value => value, value => new bool[height, width]);
            MaskMap = tempMaskMap;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public IReadOnlyDictionary<Pylek,bool[,]>  MaskMap  { get; private set; }
    }
}
