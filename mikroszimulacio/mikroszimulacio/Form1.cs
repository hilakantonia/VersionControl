using mikroszimulacio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mikroszimulacio
{
    public partial class Form1 : Form
    {
        Random rng = new Random(1234);
        public Form1()
        {
            InitializeComponent();
            List<Person> Population = new List<Person>();
            List<Birthprobability> BirthProbabilities = new List<Birthprobability>();
            List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            for (int year = 2005; year <= 2024; year++)
            {
               
                for (int i = 0; i < Population.Count; i++)
                {
                    // Ide jön a szimulációs lépés
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));

            }
        }

            public List<Person> GetPopulation(string csvpath)
            {
                List<Person> population = new List<Person>();

                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(';');
                        population.Add(new Person()
                        {
                            BirthYear = int.Parse(line[0]),
                            Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                            NbrOfChildren = int.Parse(line[2])
                        });
                    }
                }

                return population;
            }
            public List<Birthprobability> GetBirthProbabilities(string csvpath)
            {
                List<Birthprobability> population2 = new List<Birthprobability>();

                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(';');
                        population2.Add(new Birthprobability()
                        {
                            BirthYear = int.Parse(line[0]),
                            NbrOfChildren = int.Parse(line[1]),
                            P = double.Parse(line[2])
                        });
                    }
                }

                return population2;
            }
            public List<DeathProbability> GetDeathProbabilities(string csvpath)
            {
                List<DeathProbability> population3 = new List<DeathProbability>();

                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(';');
                        population3.Add(new DeathProbability()
                        {
                            Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                            BirthYear = int.Parse(line[1]),
                            P = double.Parse(line[2])
                        });
                    }
                }

                return population3;
            }

           
    }
}


