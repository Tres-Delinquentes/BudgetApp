namespace Backend.UnitTest.Data.Converters;

public abstract class ATheoryData : IEnumerable<object[]>
{
    readonly List<object[]> data = new List<object[]>();

    protected void AddRow(params object[] values)
    {
        data.Add(values);
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
