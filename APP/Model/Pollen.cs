using System.Collections.Generic;
using System.Drawing;
using System.Windows.Markup;

namespace APP.Model
{
    public sealed class     Pollen //nie mozna po  niej dziedziczyc
    {
        public static readonly SortedList<KnownColor, Pollen> KolorPylkowList = new SortedList<KnownColor, Pollen>();
        public static readonly SortedList<string, Pollen> NazwyPylkowList = new SortedList<string, Pollen>();
        public static readonly SortedList<int, Pollen> NumberList = new SortedList<int, Pollen>();

        private static readonly HashSet<Pollen> _values = new HashSet<Pollen>();

        public static IEnumerable<Pollen> Values
        {
            get { return _values; }
        }


        public static readonly Pollen Rzepakowy = new Pollen(1, "Rzepakowy", KnownColor.Pink);

        public static readonly Pollen Spadziowy = new Pollen(2, "Spadziowy", KnownColor.Cyan);

        public static readonly Pollen Lipowy = new Pollen(3, "Lipowy", KnownColor.DeepPink);

        public static readonly Pollen Akacjowy = new Pollen(4, "Akacjowy", KnownColor.Gold);

        public static readonly Pollen Mniszkowy = new Pollen(5, "Mniszkowy", KnownColor.Gray);

        public static readonly Pollen Wrzosowy = new Pollen(6, "Wrzosowy", KnownColor.Indigo);

        public static readonly Pollen Gryczany = new Pollen(7, "Gryczany", KnownColor.Green);

        public static readonly Pollen Faceliowy = new Pollen(8, "Faceliowy", KnownColor.Coral);

        public static readonly Pollen Malinowy = new Pollen(9, "Malinowy", KnownColor.Magenta);

        public static readonly Pollen Nostrzykowy = new Pollen(10, "Nostrzykowy", KnownColor.Lime);

        public static readonly Pollen Nawłociowy = new Pollen(11, "Nawłociowy", KnownColor.Navy);

        public static readonly Pollen Koniczynowy = new Pollen(12, "Koniczynowy", KnownColor.Orange);

        public static readonly Pollen Leśny = new Pollen(13, "Leśny", KnownColor.SeaGreen);

        public static readonly Pollen Bławatkowy = new Pollen(14, "Bławatkowy", KnownColor.Teal);

        public static readonly Pollen Cząbrowy = new Pollen(15, "Cząbrowy", KnownColor.Maroon);

        public static readonly Pollen Manuka = new Pollen(16, "Manuka", KnownColor.SkyBlue);

        public static readonly Pollen Sadowniczy = new Pollen(17, "Sadowniczy", KnownColor.Olive);


        private readonly int _numer;
        private readonly string _name;
        private readonly KnownColor _color;


        private Pollen(int numer, string name, KnownColor color)
        {
            this._numer = numer;
            this._name = name;
            this._color = color;
            KolorPylkowList.Add(color, this);
            NazwyPylkowList.Add(name, this);
            NumberList.Add(numer, this);

            _values.Add(this);
        }


        public static Pollen TryPrase(KnownColor color) //zamieniamy  color->pylek
        {
            if (KolorPylkowList.ContainsKey(color))
            {
                return KolorPylkowList[color];
            }
            return null;
        }


        public static explicit operator KnownColor(Pollen pylek) //zamieniamy pylek->color
        {
            return pylek._color;
        }


        public static Pollen TryPrase(Color color) //zamieniamy  color->pylek
        {
            if (KolorPylkowList.ContainsKey(color.ToKnownColor()))
            {
                return KolorPylkowList[color.ToKnownColor()];
            }
            return null;
        }


        public static explicit operator Color(Pollen pylek) //zamieniamy pylek->color
        {
            return Color.FromKnownColor(pylek._color);
        }


        public static implicit operator Pollen(int numer) //zamieniamy  int->pylek
        {
            return NumberList[numer];
        }

        public static implicit operator int(Pollen pylek) //zamieniamy  pylek->int
        {
            return pylek._numer;
        }

        public static implicit operator Pollen(string name) //zamieniamy  string_name->pylek
        {
            return NazwyPylkowList[name];
        }

        public static implicit operator string(Pollen pylek) //zamieniamy  pylek->string_name
        {
            return pylek._name;
        }
    }
}