#if AllowUnsafeImplementation && NET6_0_OR_GREATER
namespace FastGenericNew.Tests.Units.ClrAllocatorTests;

public class ValueTypes
{
    [TestCaseSourceGeneric(typeof(TestData), nameof(TestData.CommonValueTypes))]
    [Parallelizable(ParallelScope.All)]
    public void CommonTypes<T>()
    {
        if (!ClrAllocator<T>.IsSupported) Assert.Ignore("Unsupported");
        var expected = Activator.CreateInstance<T>();
        var actual = FastNew<T>.CompiledDelegate();
        Assert.AreEqual(expected, actual);
    }
}
#endif