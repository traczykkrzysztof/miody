using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Helpers.FileHandling
{
    public sealed class Pylek //nie mozna po  niej dziedziczyc
    {
        public static readonly Pylek Rzepakowy = new Pylek(1, "Rzepakowy", KnownColor.Pink);

        public static readonly Pylek Spadziowy = new Pylek(2, "Spadziowy", KnownColor.Cyan);

        public static readonly Pylek Lipowy = new Pylek(3, "Lipowy", KnownColor.DeepPink);

        public static readonly Pylek Akacjowy = new Pylek(4, "Akacjowy", KnownColor.Gold);

        public static readonly Pylek Mniszkowy = new Pylek(5, "Mniszkowy", KnownColor.Gray);

        public static readonly Pylek Wrzosowy = new Pylek(6, "Wrzosowy", KnownColor.Indigo);

        public static readonly Pylek Gryczany = new Pylek(7, "Gryczany", KnownColor.Green);

        public static readonly Pylek Faceliowy = new Pylek(8, "Faceliowy", KnownColor.Coral);

        public static readonly Pylek Malinowy = new Pylek(9, "Malinowy", KnownColor.Magenta);

        public static readonly Pylek Nostrzykowy = new Pylek(10, "Nostrzykowy", KnownColor.Lime);

        public static readonly Pylek Nawłociowy = new Pylek(11, "Nawłociowy", KnownColor.Navy);

        public static readonly Pylek Koniczynowy = new Pylek(12, "Koniczynowy", KnownColor.Orange);

        public static readonly Pylek Leśny = new Pylek(13, "Leśny", KnownColor.SeaGreen);

        public static readonly Pylek Bławatkowy = new Pylek(14, "Bławatkowy", KnownColor.Teal);

        public static readonly Pylek Cząbrowy = new Pylek(15, "Cząbrowy", KnownColor.Maroon);

        public static readonly Pylek Manuka = new Pylek(16, "Manuka", KnownColor.SkyBlue);

        public static readonly Pylek Sadowniczy = new Pylek(17, "Sadowniczy", KnownColor.Olive);



        //z czego zmieniamy w co
        public static readonly SortedList<KnownColor, Pylek> KolorPylkowList = new SortedList<KnownColor, Pylek>();
        public static readonly SortedList<string, Pylek> NazwyPylkowList = new SortedList<string, Pylek>();
        public static readonly SortedList<int, Pylek> NumberList = new SortedList<int, Pylek>();

        private readonly int numer;
        private readonly string name;
        private readonly KnownColor color;


        private Pylek(int numer, string name, KnownColor color)
        {
            this.numer = numer;
            this.name = name;
            this.color = color;
            KolorPylkowList.Add(color, this);
            NazwyPylkowList.Add(name, this);
            NumberList.Add(numer, this);
        }


        public static implicit operator Pylek(KnownColor color) //zamieniamy  color->pylek
        {
            return KolorPylkowList[color];
        }


        public static implicit operator KnownColor(Pylek pylek) //zamieniamy pylek->color
        {
            return pylek.color;
        }


        public static implicit operator Pylek(int numer) //zamieniamy  int->pylek
        {
            return NumberList[numer];
        }

        public static implicit operator int(Pylek pylek) //zamieniamy  pylek->int
        {
            return pylek.numer;
        }

        public static implicit operator Pylek(string name) //zamieniamy  string_name->pylek
        {
            return NazwyPylkowList[name];
        }

        public static implicit operator string(Pylek pylek) //zamieniamy  pylek->string_name
        {
            return pylek.name;
        }

    }
}
