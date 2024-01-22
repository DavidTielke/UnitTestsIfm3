using System.Runtime.CompilerServices;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dreieck = new Dreieck();

            AssertDreieck(1,1,1,DreieckTyp.Gleichseitiges);
            AssertDreieck(1,2,1,DreieckTyp.Gleichschenklig);
            AssertDreieck(3,2,1,DreieckTyp.Normal);
            AssertDreieck(0,1,2, DreieckTyp.Error);
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
