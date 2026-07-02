public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new array of size 'length' to hold the multiples
        // 2. Loop from 0 to length-1
        // 3. For each iteration i, calculate the multiple: number * (i + 1)
        //    (i + 1 because we want 1x, 2x, 3x, etc., not 0x, 1x, 2x)
        // 4. Store each multiple in the array at index i
        // 5. Return the completed array

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. Extract the last 'amount' elements using GetRange
        //    (start index is data.Count - amount, count is amount)
        // 2. Remove those elements from the end of the list using RemoveRange
        //    (start index is data.Count - amount, count is amount)
        // 3. Insert the extracted elements at the beginning (index 0) using InsertRange
        // This shifts the last 'amount' elements to the front without changing their order

        int startIndex = data.Count - amount;
        List<int> lastElements = data.GetRange(startIndex, amount);
        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, lastElements);
    }
}
