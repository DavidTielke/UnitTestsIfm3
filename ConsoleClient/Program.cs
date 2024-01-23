using System.Runtime.CompilerServices;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static void AssertDreieck(int a, int b, int c, DreieckTyp expected)
        {
            var oldColor = Console.ForegroundColor;

            var dreieck = new Dreieck();

            var actual = dreieck.GetTyp(a, b, c);

            if (expected == actual)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{a},{b},{c} ist {expected}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{a},{b},{c} ist nicht {expected} sondern {actual}");
            }

            Console.ForegroundColor = oldColor;
        }
    }


    public class Dreieck
    {
        public DreieckTyp GetTyp(int a, int b, int c)
        {
            var sidesOrderedDesc = new[] { a, b, c }.Order().ToArray();
            var minSide1 = sidesOrderedDesc[0];
            var minSide2 = sidesOrderedDesc[1];
            var maxSide = sidesOrderedDesc[2];

            var isNotConstructable = minSide1 + (long)minSide2 <= maxSide;
            if (isNotConstructable)
            {
                return DreieckTyp.Error;
            }

            if (a <= 0 || b <= 0 || c <= 0)
            {
                return DreieckTyp.Error;
            }

            if (a == b && b == c && c == a)
            {
                return DreieckTyp.Gleichseitiges;
            }

            if (a == b || b == c || c == a)
            {
                return DreieckTyp.Gleichschenklig;
            }

            return DreieckTyp.Normal;
        }
    }

    public enum DreieckTyp
    {
        Normal,
        Gleichschenklig,
        Gleichseitiges,
        Error
    }
}
