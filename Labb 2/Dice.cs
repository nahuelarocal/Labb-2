namespace Labb_2
{
    public class Dice
    {
        private int numberOfDice;
        private int sidesPerDice;
        private int modifier;

        private Random random = new Random();

        public Dice(int numberOfDice, int sidesPerDice, int modifier)
        {
            this.numberOfDice = numberOfDice;
            this.sidesPerDice = sidesPerDice;
            this.modifier = modifier;
        }

        public int Throw()
        {
            int result = modifier;

            for (int i = 0; i < numberOfDice; i++)
            {
                result += random.Next(1, sidesPerDice + 1);
            }

            return result;
        }

        public override string ToString()
        {
            string result = numberOfDice + "d" + sidesPerDice;

            if (modifier > 0)
            {
                result += "+" + modifier;
            }
            else if (modifier < 0)
            {
                result += modifier;
            }

            return result;
        }
    }
}