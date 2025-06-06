namespace FlattenArray.Tests;

using FlattenArray;

public class FlattenArrayTests
{
    [Fact]
    public void Empty()
    {
        var array = Array.Empty<object?>();
        Assert.Empty(Flatter.Flatten(array));
    }

    [Fact]
    public void No_nesting()
    {
        object?[] array = new object?[] { 0, 1, 2 };
        object?[] expected = [0, 1, 2];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Flattens_a_nested_array()
    {
        object?[] array = new object?[] { new object?[] { Array.Empty<object?>() } };
        object?[] expected = [];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Flattens_array_with_just_integers_present()
    {
        object?[] array = new object?[] { 1, new object?[] { 2, 3, 4, 5, 6, 7 }, 8 };
        object?[] expected = [1, 2, 3, 4, 5, 6, 7, 8];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Five_level_nesting()
    {
        object?[] array = new object?[] { 0, 2, new object?[] { new object?[] { 2, 3 }, 8, 100, 4, new object?[] { new object?[] { new object?[] { 50 } } } }, -2 };
        object?[] expected = [0, 2, 2, 3, 8, 100, 4, 50, -2];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Six_level_nesting()
    {
        object?[] array = new object?[] { 1, new object?[] { 2, new object?[] { new object?[] { 3 } }, new object?[] { 4, new object?[] { new object?[] { 5 } } }, 6, 7 }, 8 };
        object?[] expected = [1, 2, 3, 4, 5, 6, 7, 8];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Null_values_are_omitted_from_the_final_result()
    {
        object?[] array = new object?[] { 1, 2, null };
        object?[] expected = [1, 2];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Consecutive_null_values_at_the_front_of_the_array_are_omitted_from_the_final_result()
    {
        object?[] array = new object?[] { null, null, 3 };
        object?[] expected = [3];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Consecutive_null_values_in_the_middle_of_the_array_are_omitted_from_the_final_result()
    {
        object?[] array = new object?[] { 1, null, null, 4 };
        object?[] expected = [1, 4];
        Assert.Equal(expected, Flatter.Flatten(array));
    }

    [Fact]
    public void Six_level_nested_array_with_null_values()
    {
        object?[] array = new object?[] { 0, 2, new object?[] { new object?[] { 2, 3 }, 8, new object?[] { new object?[] { 100 } }, null, new object?[] { new object?[] { null } } }, -2 };
        object?[] expected = [0, 2, 2, 3, 8, 100, -2];
        Assert.Equal(expected, Flatter.Flatten(array));
    }
    
    [Fact]
    public void All_values_in_nested_array_are_null()
    {
        object?[] array = new object?[] { null, new object?[] { new object?[] { new object?[] { null } } }, null, null, new object?[] { new object?[] { null, null }, null }, null };
        object?[] expected = [];
        Assert.Equal(expected, Flatter.Flatten(array));
    }
}
