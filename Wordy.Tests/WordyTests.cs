namespace Wordy.Tests;
using Wordy;

public class WordyTests
{
    [Fact]
    public void Just_a_number()
    {
        Assert.Equal(5, Parser.Answer("What is 5?"));
    }

    [Fact]
    public void Addition()
    {
        Assert.Equal(2, Parser.Answer("What is 1 plus 1?"));
    }

    [Fact]
    public void More_addition()
    {
        Assert.Equal(55, Parser.Answer("What is 53 plus 2?"));
    }

    [Fact]
    public void Addition_with_negative_numbers()
    {
        Assert.Equal(-11, Parser.Answer("What is -1 plus -10?"));
    }

    [Fact]
    public void Large_addition()
    {
        Assert.Equal(45801, Parser.Answer("What is 123 plus 45678?"));
    }

    [Fact]
    public void Subtraction()
    {
        Assert.Equal(16, Parser.Answer("What is 4 minus -12?"));
    }

    [Fact]
    public void Multiplication()
    {
        Assert.Equal(-75, Parser.Answer("What is -3 multiplied by 25?"));
    }

    [Fact]
    public void Division()
    {
        Assert.Equal(-11, Parser.Answer("What is 33 divided by -3?"));
    }

    [Fact]
    public void Multiple_additions()
    {
        Assert.Equal(3, Parser.Answer("What is 1 plus 1 plus 1?"));
    }

    [Fact]
    public void Addition_and_subtraction()
    {
        Assert.Equal(8, Parser.Answer("What is 1 plus 5 minus -2?"));
    }

    [Fact]
    public void Multiple_subtraction()
    {
        Assert.Equal(3, Parser.Answer("What is 20 minus 4 minus 13?"));
    }

    [Fact]
    public void Subtraction_then_addition()
    {
        Assert.Equal(14, Parser.Answer("What is 17 minus 6 plus 3?"));
    }

    [Fact]
    public void Multiple_multiplication()
    {
        Assert.Equal(-12, Parser.Answer("What is 2 multiplied by -2 multiplied by 3?"));
    }

    [Fact]
    public void Addition_and_multiplication()
    {
        Assert.Equal(-8, Parser.Answer("What is -3 plus 7 multiplied by -2?"));
    }

    [Fact]
    public void Multiple_division()
    {
        Assert.Equal(2, Parser.Answer("What is -12 divided by 2 divided by -3?"));
    }

    [Fact]
    public void Unknown_operation()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("What is 52 cubed?"));
    }

    [Fact]
    public void Non_math_question()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("Who is the President of the United States?"));
    }

    [Fact]
    public void Reject_problem_missing_an_operand()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("What is 1 plus?"));
    }

    [Fact]
    public void Reject_problem_with_no_operands_or_operators()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("What is?"));
    }

    [Fact]
    public void Reject_two_operations_in_a_row()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("What is 1 plus plus 2?"));
    }

    [Fact]
    public void Reject_two_numbers_in_a_row()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("What is 1 plus 2 1?"));
    }

    [Fact]
    public void Reject_postfix_notation()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("What is 1 2 plus?"));
    }
    
    [Fact]
    public void Reject_prefix_notation()
    {
        Assert.Throws<ArgumentException>(() => Parser.Answer("What is plus 1 2?"));
    }
}
