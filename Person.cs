using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_256_Intermediate
{
    public class Person
    {
        public HatColour HatWorn { get; private set; }
        public HatColour HatGuess { get; set; }

        public Person(string inHat)
        {
	  		if(inHat.ToLowerInvariant().Equals("black"))
				this.HatWorn = HatColour.Black;
            else if (inHat.ToLowerInvariant().Equals("white"))
                this.HatWorn = HatColour.White;
            this.HatGuess = HatColour.Und;
        }

        public bool GuessHatColour(bool isBlackOdd, List<Person> visibleHats)
        {
			int blackCnt = visibleHats.Where(P => P.HatWorn == HatColour.Black).Count();
            bool isVisibleBlackOdd =  (blackCnt > 0)? blackCnt % 2 != 0 : false;
            if (isBlackOdd)
				if(isVisibleBlackOdd)
					 this.HatGuess = HatColour.White;
				else
                    this.HatGuess = HatColour.Black;
            else
                if (isVisibleBlackOdd)
                    this.HatGuess = HatColour.Black;
                else
                    this.HatGuess = HatColour.White;
            return isVisibleBlackOdd;
        }
    }
}
