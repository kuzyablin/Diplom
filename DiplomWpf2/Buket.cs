using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2
{
    public class Buket
    {
        private static Buket _instance;
        public static Buket Instance => _instance ??= new Buket();
        public int IdTovar { get; set; }

        public int Kolvo { get; set; }
        public string NameTovar { get; set; }


        public int IdTypeTovar { get; set; }

        public decimal PriceTovar { get; set; }
        public int IdKrossBuket { get; set; }
        private List<Buket> _bukets = new List<Buket>();
        public Buket() { }

        public void Add(Buket buket)
        {
            _bukets.Add(buket);
        }
        public void Delete(Buket buket)
        {
            _bukets.Remove(buket);
        }


        // Пример метода для получения всех букетов
        public List<Buket> GetAllBukets()
        {
            return _bukets;
        }
    }
}
