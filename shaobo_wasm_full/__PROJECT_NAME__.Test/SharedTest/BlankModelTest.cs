using Xunit;

using __PROJECT_NAME__.Shared;

namespace __PROJECT_NAME__.Test.SharedTest;

public class BlankModelTest
{
    [Fact]
    public void MeaninglessMethodTest__int__void()
    {
        BlankModel model = new BlankModel();
        int actual = model.MeaninglessMethod();
        Assert.Equal<int>(expected: 23323, actual: actual);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(-1, -2)]
    public void MeaninglessMethodTest__int__int(int input, int expectedOutput)
    {
        BlankModel model = new BlankModel();
        int actual = model.MeaninglessMethod(input);
        Assert.Equal<int>(expected: expectedOutput, actual: actual);
    }
}