using ConsoleClient;

namespace UnitTests;

[TestFixture]
public class TestClass
{
    [Test]
    public void GetTyp_A3B3C3_Gleichschenklig()
    {
        var dreieck = new Dreieck();
        var a = 3;
        var b = 3;
        var c = 3;
        var expected = DreieckTyp.Gleichschenklig;

        var actual = dreieck.GetTyp(a, b, c);

        Assert.AreEqual(expected, actual, "Dreieck war nicht gleichschenjklig");
    }

    [Test]
    public void Test3()
    {
        var dreieck = new Dreieck();
        var a = 3;
        var b = 3;
        var c = 3;
        var expected = DreieckTyp.Gleichschenklig;

        var actual = dreieck.GetTyp(a, b, c);

        Assert.AreEqual(expected, actual, "Dreieck war nicht gleichschenjklig");
    }

    [Test]
    public void Test2()
    {
    }
}