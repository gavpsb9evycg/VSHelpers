using FileManagement.Food;

namespace FileManagement.Tests.Food
{
    public class PerekrestokLogTests
    {
        private readonly string _testDataDirectory;

        public PerekrestokLogTests()
        {
            var baseDir = AppContext.BaseDirectory;
            var dir = new DirectoryInfo(baseDir);

            // Traverse up to find the Food\TestData directory
            while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, "Food", "TestData")))
            {
                dir = dir.Parent;
            }

            _testDataDirectory = dir != null
                ? Path.Combine(dir.FullName, "Food", "TestData")
                : Path.Combine(baseDir, "..", "..", "..", "..", "Food", "TestData");

            // Ensure ProductPrefixes.json is available for the static initializer in PerekrestokLog
            EnsureConfigFileExists(baseDir, dir);
        }

        private void EnsureConfigFileExists(string baseDir, DirectoryInfo? projectRoot)
        {
            if (projectRoot == null) return;

            var sourceConfig = Path.Combine(projectRoot.FullName, "Food", "ProductPrefixes.json");
            var targetDir = Path.Combine(baseDir, "Food");
            var targetConfig = Path.Combine(targetDir, "ProductPrefixes.json");

            if (File.Exists(sourceConfig) && !File.Exists(targetConfig))
            {
                Directory.CreateDirectory(targetDir);
                File.Copy(sourceConfig, targetConfig, overwrite: true);
            }
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("7")]
        [InlineData("8")]
        [InlineData("9")]
        [InlineData("10")]
        [InlineData("11")]
        [InlineData("12")]
        public void ProcessLines_ShouldCorrectlyFormatAndSortProducts(string testId)
        {
            // Arrange
            var inputFilePath = Path.Combine(_testDataDirectory, $"in{testId}.txt");
            var expectedOutputFilePath = Path.Combine(_testDataDirectory, $"out{testId}.txt");

            Assert.True(File.Exists(inputFilePath), $"Input file not found at {inputFilePath}. Ensure test data is copied to output directory or path is correct.");
            Assert.True(File.Exists(expectedOutputFilePath), $"Expected output file not found at {expectedOutputFilePath}.");

            var inputLines = File.ReadAllLines(inputFilePath);
            var expectedOutput = File.ReadAllText(expectedOutputFilePath).Trim();

            // Act
            var actualOutput = PerekrestokLog.ProcessLines(inputLines).Trim();

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ProcessLines_WithEmptyInput_ReturnsEmptyString()
        {
            // Arrange
            var inputLines = Array.Empty<string>();

            // Act
            var actualOutput = PerekrestokLog.ProcessLines(inputLines);

            // Assert
            Assert.Equal(string.Empty, actualOutput);
        }
    }
}