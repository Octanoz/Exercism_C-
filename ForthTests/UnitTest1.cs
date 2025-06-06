namespace ForthTests;

public class ForthTests
{
    [Fact]
    public void Parsing_and_numbers_numbers_just_get_pushed_onto_the_stack()
    {
        Assert.Equal("1 2 3 4 5", Forth.ForthMethods.Evaluate(new[] { "1 2 3 4 5" }));
    }
    [Fact]
    public void Parsing_and_numbers_pushes_negative_numbers_onto_the_stack()
    {
        Assert.Equal("-1 -2 -3 -4 -5", Forth.ForthMethods.Evaluate(new[] { "-1 -2 -3 -4 -5" }));
    }
    [Fact]
    public void Addition_can_add_two_numbers()
    {
        Assert.Equal("3", Forth.ForthMethods.Evaluate(new[] { "1 2 +" }));
    }
    [Fact]
    public void Addition_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "+" }));
    }
    [Fact]
    public void Addition_errors_if_there_is_only_one_value_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "1 +" }));
    }
    [Fact]
    public void Subtraction_can_subtract_two_numbers()
    {
        Assert.Equal("-1", Forth.ForthMethods.Evaluate(new[] { "3 4 -" }));
    }
    [Fact]
    public void Subtraction_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "-" }));
    }
    [Fact]
    public void Subtraction_errors_if_there_is_only_one_value_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "1 -" }));
    }
    [Fact]
    public void Multiplication_can_multiply_two_numbers()
    {
        Assert.Equal("8", Forth.ForthMethods.Evaluate(new[] { "2 4 *" }));
    }
    [Fact]
    public void Multiplication_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "*" }));
    }
    [Fact]
    public void Multiplication_errors_if_there_is_only_one_value_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "1 *" }));
    }
    [Fact]
    public void Division_can_divide_two_numbers()
    {
        Assert.Equal("4", Forth.ForthMethods.Evaluate(new[] { "12 3 /" }));
    }
    [Fact]
    public void Division_performs_integer_division()
    {
        Assert.Equal("2", Forth.ForthMethods.Evaluate(new[] { "8 3 /" }));
    }
    [Fact]
    public void Division_errors_if_dividing_by_zero()
    {
        Assert.Throws<DivideByZeroException>(() => Forth.ForthMethods.Evaluate(new[] { "4 0 /" }));
    }
    [Fact]
    public void Division_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "/" }));
    }
    [Fact]
    public void Division_errors_if_there_is_only_one_value_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "1 /" }));
    }
    [Fact]
    public void Combined_arithmetic_addition_and_subtraction()
    {
        Assert.Equal("-1", Forth.ForthMethods.Evaluate(new[] { "1 2 + 4 -" }));
    }
    [Fact]
    public void Combined_arithmetic_multiplication_and_division()
    {
        Assert.Equal("2", Forth.ForthMethods.Evaluate(new[] { "2 4 * 3 /" }));
    }
    [Fact]
    public void Dup_copies_a_value_on_the_stack()
    {
        Assert.Equal("1 1", Forth.ForthMethods.Evaluate(new[] { "1 dup" }));
    }
    [Fact]
    public void Dup_copies_the_top_value_on_the_stack()
    {
        Assert.Equal("1 2 2", Forth.ForthMethods.Evaluate(new[] { "1 2 dup" }));
    }
    [Fact]
    public void Dup_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "dup" }));
    }
    [Fact]
    public void Drop_removes_the_top_value_on_the_stack_if_it_is_the_only_one()
    {
        Assert.Equal("", Forth.ForthMethods.Evaluate(new[] { "1 drop" }));
    }
    [Fact]
    public void Drop_removes_the_top_value_on_the_stack_if_it_is_not_the_only_one()
    {
        Assert.Equal("1", Forth.ForthMethods.Evaluate(new[] { "1 2 drop" }));
    }
    [Fact]
    public void Drop_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "drop" }));
    }
    [Fact]
    public void Swap_swaps_the_top_two_values_on_the_stack_if_they_are_the_only_ones()
    {
        Assert.Equal("2 1", Forth.ForthMethods.Evaluate(new[] { "1 2 swap" }));
    }
    [Fact]
    public void Swap_swaps_the_top_two_values_on_the_stack_if_they_are_not_the_only_ones()
    {
        Assert.Equal("1 3 2", Forth.ForthMethods.Evaluate(new[] { "1 2 3 swap" }));
    }
    [Fact]
    public void Swap_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "swap" }));
    }
    [Fact]
    public void Swap_errors_if_there_is_only_one_value_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "1 swap" }));
    }
    [Fact]
    public void Over_copies_the_second_element_if_there_are_only_two()
    {
        Assert.Equal("1 2 1", Forth.ForthMethods.Evaluate(new[] { "1 2 over" }));
    }
    [Fact]
    public void Over_copies_the_second_element_if_there_are_more_than_two()
    {
        Assert.Equal("1 2 3 2", Forth.ForthMethods.Evaluate(new[] { "1 2 3 over" }));
    }
    [Fact]
    public void Over_errors_if_there_is_nothing_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "over" }));
    }
    [Fact]
    public void Over_errors_if_there_is_only_one_value_on_the_stack()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "1 over" }));
    }
    [Fact]
    public void User_defined_words_can_consist_of_built_in_words()
    {
        Assert.Equal("1 1 1", Forth.ForthMethods.Evaluate(new[] { ": dup-twice dup dup ;", "1 dup-twice" }));
    }
    [Fact]
    public void User_defined_words_execute_in_the_right_order()
    {
        Assert.Equal("1 2 3", Forth.ForthMethods.Evaluate(new[] { ": countup 1 2 3 ;", "countup" }));
    }
    [Fact]
    public void User_defined_words_can_override_other_user_defined_words()
    {
        Assert.Equal("1 1 1", Forth.ForthMethods.Evaluate(new[] { ": foo dup ;", ": foo dup dup ;", "1 foo" }));
    }
    [Fact]
    public void User_defined_words_can_override_built_in_words()
    {
        Assert.Equal("1 1", Forth.ForthMethods.Evaluate(new[] { ": swap dup ;", "1 swap" }));
    }
    [Fact]
    public void User_defined_words_can_override_built_in_operators()
    {
        Assert.Equal("12", Forth.ForthMethods.Evaluate(new[] { ": + * ;", "3 4 +" }));
    }
    [Fact]
    public void User_defined_words_can_use_different_words_with_the_same_name()
    {
        Assert.Equal("5 6", Forth.ForthMethods.Evaluate(new[] { ": foo 5 ;", ": bar foo ;", ": foo 6 ;", "bar foo" }));
    }
    [Fact]
    public void User_defined_words_can_define_word_that_uses_word_with_the_same_name()
    {
        Assert.Equal("11", Forth.ForthMethods.Evaluate(new[] { ": foo 10 ;", ": foo foo 1 + ;", "foo" }));
    }
    [Fact]
    public void User_defined_words_cannot_redefine_non_negative_numbers()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { ": 1 2 ;" }));
    }
    [Fact]
    public void User_defined_words_cannot_redefine_negative_numbers()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { ": -1 2 ;" }));
    }
    [Fact]
    public void User_defined_words_errors_if_executing_a_non_existent_word()
    {
        Assert.Throws<InvalidOperationException>(() => Forth.ForthMethods.Evaluate(new[] { "foo" }));
    }
    [Fact]
    public void User_defined_words_only_defines_locally()
    {
        Assert.Equal("0", Forth.ForthMethods.Evaluate(new[] { ": + - ;", "1 1 +" }));
        Assert.Equal("2", Forth.ForthMethods.Evaluate(new[] { "1 1 +" }));
    }
    [Fact]
    public void Case_insensitivity_dup_is_case_insensitive()
    {
        Assert.Equal("1 1 1 1", Forth.ForthMethods.Evaluate(new[] { "1 DUP Dup dup" }));
    }
    [Fact]
    public void Case_insensitivity_drop_is_case_insensitive()
    {
        Assert.Equal("1", Forth.ForthMethods.Evaluate(new[] { "1 2 3 4 DROP Drop drop" }));
    }
    [Fact]
    public void Case_insensitivity_swap_is_case_insensitive()
    {
        Assert.Equal("2 3 4 1", Forth.ForthMethods.Evaluate(new[] { "1 2 SWAP 3 Swap 4 swap" }));
    }
    [Fact]
    public void Case_insensitivity_over_is_case_insensitive()
    {
        Assert.Equal("1 2 1 2 1", Forth.ForthMethods.Evaluate(new[] { "1 2 OVER Over over" }));
    }
    [Fact]
    public void Case_insensitivity_user_defined_words_are_case_insensitive()
    {
        Assert.Equal("1 1 1 1", Forth.ForthMethods.Evaluate(new[] { ": foo dup ;", "1 FOO Foo foo" }));
    }
    [Fact]
    public void Case_insensitivity_definitions_are_case_insensitive()
    {
        Assert.Equal("1 1 1 1", Forth.ForthMethods.Evaluate(new[] { ": SWAP DUP Dup dup ;", "1 swap" }));
    }
}