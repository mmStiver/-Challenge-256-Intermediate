using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Challenge_256_Intermediate
{
    public class Challenge256
    {
        private List<Person> People;

        public Challenge256()
        {
            this.People = new List<Person>();
        }

        private void ProcessGuesses() {
            int blackCnt = (People.GetRange(1, People.Count() - 1).Where(P => P.HatWorn == HatColour.Black).Count());
            bool isBlackOdd = (blackCnt > 0) ? blackCnt % 2 != 0 : false; 
            for (int i = 0; i < People.Count; i++)
            {
                isBlackOdd = People[i].GuessHatColour(isBlackOdd, People.GetRange(i+1, People.Count()-(i+1)));
            }
        }
        private void ParseInput(string fileName)
        {
                string lineOfText = string.Empty;
                var filestream = new System.IO.FileStream(fileName,
                                              System.IO.FileMode.Open,
                                              System.IO.FileAccess.Read,
                                              System.IO.FileShare.ReadWrite);
                using (var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128))
                {
                    while ((lineOfText = file.ReadLine()) != null)
                    {
                        People.Add(new Person(lineOfText));
                    }
                }
            
        }
        private void PrintResult() { 
            foreach(var peep in this.People){
                Console.Write(peep.HatWorn.ToString() + " guessed " +peep.HatGuess.ToString());
                if (peep.HatGuess == peep.HatWorn)
                    Console.WriteLine(" - > Success!");
                else
                    Console.WriteLine(" - > Fail!");
            }
            Console.WriteLine(this.People.Where(P => P.HatGuess == P.HatWorn).Count() + " correct out of " + this.People.Count );
        }

        public void Initialize(string[] args)
        {
            this.ParseInput(args[0]);
        }

        public void Run()
        {
            var watch = Stopwatch.StartNew();
            ProcessGuesses();
            watch.Stop();
            var elapsedMs = watch.Elapsed.Seconds;
            
            PrintResult();
            Console.WriteLine();
            Console.WriteLine(elapsedMs + "s");
            Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            if (args.Length <= 0)
                return;

            var pgm = new Challenge256();
            pgm.Initialize(args);
            pgm.Run();
        }
    }
}
