using ConsoleClient;

namespace UnitTests;

[TestFixture]
public class DreieckTests
{
    private Dreieck _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new Dreieck();
    }

    [TearDown]
    public void TearDown()
    {
        _sut = null;
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {

    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {

    }

    [Test]
    public void GetTyp_EineSeiteNull([Values(0,1)] int a, [Values(0,1)] int b, [Values(0, 1)] int c)
    {
        if (a == 1 && b == 1 && c == 1) return;

        var expected = DreieckTyp.Error;

        var actual = _sut.GetTyp(a, b, c);

        Assert.AreEqual(expected, actual, "Dreieck war nicht gleichschenjklig");
    }

    [TestCase(-1, 1, 1)]
    [TestCase(1, -1, 1)]
    [TestCase(1, 1, -1)]
    [TestCase(-1, -1, -1)]
    public void GetTyp_EineSeiteNegativ(int a, int b, int c)
    {
        var expected = DreieckTyp.Error;

        var actual = _sut.GetTyp(a, b, c);

        Assert.AreEqual(expected, actual, "Dreieck war nicht gleichschenjklig");
    }
    
    [TestCase(1, 2, 1)]
    [TestCase(1, 3, 1)]
    public void GetTyp_NichtKonstruierbar(int a, int b, int c)
    {
        var expected = DreieckTyp.Error;

        var actual = _sut.GetTyp(a, b, c);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetTyp_AMinBMinCMin_Error()
    {
        var expected = DreieckTyp.Error;
        var a = int.MinValue;
        var b = int.MinValue;
        var c = int.MinValue;

        var actual = _sut.GetTyp(a, b, c);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetTyp_AMaxBMayCMax_Error()
    {
        var expected = DreieckTyp.Gleichseitiges;
        var a = int.MaxValue;
        var b = int.MaxValue;
        var c = int.MaxValue;

        var actual = _sut.GetTyp(a, b, c);

        Assert.AreEqual(expected, actual);
    }
}