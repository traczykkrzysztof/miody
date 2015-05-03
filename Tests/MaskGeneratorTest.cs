using System.IO;
using System.Linq;
using System.Drawing;
using APP.Helpers;
using APP.Helpers.FileHandling;
using APP.Model;
using Xunit;

namespace Tests
{
    public class MaskGeneratorTest
    {
        [Fact]
        public void SimpleTest()
        {
            // przygotowanie testu 
            IBitmapHandler handler = new BitmapHandler();
            Contour contour = handler.LoadBitmap(new Bitmap(@"..\..\Images\conturUnclosed.png"));
            MaskGenerator generator = new MaskGenerator();
            



            // wykonanie akcji 
            var a = generator.GenerateMask(contour);

            //sprawdzenie (asercje)
            

           

        }
    }
}
