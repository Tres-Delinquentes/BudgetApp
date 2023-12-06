namespace Backend.UnitTest.Data;

public class TheoryData<T1> : ATheoryData
{
    /// <summary>
    /// Adds data to the theory data set.
    /// </summary>
    /// <param name="p1">The first data value.</param>
    ///// <param name="p2">The second data value.</param>
    ///// <param name="p3">The third data value.</param>
    public void Add(T1 p1)
    {
        if (p1 != null)            
            AddRow(p1);
        
    }
}
