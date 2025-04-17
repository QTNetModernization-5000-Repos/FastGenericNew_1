#if AllowUnsafeImplementation && NET6_0_OR_GREATER
namespace FastGenericNew.Tests.Units.ClrAllocatorTests;

public class ExceptionsTest
{
    [Test()]
    public void ExceptionInterface()
    {
        if (!ClrAllocator<IEnumerable>.IsSupported) Assert.Ignore("Unsupported");
        try
        {
            ClrAllocator<IEnumerable>.CreateInstance();
            Assert.Fail("The expected exception is not thrown.");
        }
        catch (Exception e)
        {
            Assert.IsTrue(e.Message.StartsWith("Cannot create an instance of an interface"));
        }
    }

    [Test()]
    public void ExceptionAbstract()
    {
        if (!ClrAllocator<Stream>.IsSupported) Assert.Ignore("Unsupported");
        try
        {
            ClrAllocator<Stream>.CreateInstance();
            Assert.Fail("The expected exception is not thrown.");
        }
        catch (MissingMethodException e)
        {
            Assert.IsTrue(e.Message.StartsWith("Cannot create an abstract class"));
        }
    }

    [Test()]
    public void ExceptionPLString()
    {
        if (!ClrAllocator<string>.IsSupported) Assert.Ignore("Unsupported");
        try
        {
            ClrAllocator<string>.CreateInstance();
            Assert.Fail("The expected exception is not thrown.");
        }
        catch (NotSupportedException)
        {
            // Marked as unsupported
            Assert.Pass();
        }
    }

    [Test()]
    public void ExceptionNotFoundNoParameter()
    {
        if (!ClrAllocator<DemoClassNoParamlessCtor>.IsSupported) Assert.Ignore("Unsupported");
        try
        {
            ClrAllocator<DemoClassNoParamlessCtor>.CreateInstance();
            Assert.Fail("The expected exception is not thrown.");
        }
        catch (Exception e)
        {
            Assert.IsTrue(e.Message.StartsWith("No match constructor found in type"));
        }
    }
}
#endif