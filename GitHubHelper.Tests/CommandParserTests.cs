namespace GitHubHelper.Tests
{
    using System.Collections.Generic;
    using GitHubHelper.Commands;
    using Xunit;

    /// <summary>
    /// Tests for CommandParser.
    /// </summary>
    public class CommandParserTests
    {
        /// <summary>
        /// Tests parse command without parameters.
        /// </summary>
        [Fact]
        public void TestParseCommandWhithNoParameters()
        {
            // arrange
            string command = "repo create";
            string area = "repo";
            string action = "create";

            // act
            CommandData testData = CommandParser.ParseCommand(command);

            // assert
            Assert.Empty(testData.Parameters);
            Assert.Equal(area, testData.DataType);
            Assert.Equal(action, testData.Action);
        }

        /// <summary>
        /// Tests parsing command with full parameters.
        /// </summary>
        [Fact]
        public void TestParseCommandWithParams()
        {
            // arrange
            string command = "repo create --name testrepo --description description";
            string area = "repo";
            string action = "create";
            string nameParamName = "name";
            string nameParamValue = "testrepo";
            string descriptionParamName = "description";
            string descriptionParamValue = "description";

            // act
            CommandData testData = CommandParser.ParseCommand(command);

            // assert
            Assert.Equal(area, testData.DataType);
            Assert.Equal(action, testData.Action);
            Assert.True(testData.Parameters.ContainsKey(nameParamName));
            Assert.Equal(
                testData.Parameters.GetValueOrDefault(nameParamName), 
                nameParamValue);
            Assert.True(testData.Parameters.ContainsKey(descriptionParamName));
            Assert.Equal(
                testData.Parameters.GetValueOrDefault(descriptionParamName),
                descriptionParamValue);
        }

        /// <summary>
        /// Tests parsing command with empty parameters.
        /// </summary>
        [Fact]
        public void TestPatrseCommandWithEmptyParam()
        {
            // arrange
            string command = "repo create --name --description";
            string area = "repo";
            string action = "create";
            string nameParamName = "name";
            string descriptionParamName = "description";

            // act
            CommandData testData = CommandParser.ParseCommand(command);

            // assert
            Assert.Equal(area, testData.DataType);
            Assert.Equal(action, testData.Action);
            Assert.True(testData.Parameters.ContainsKey(nameParamName));
            Assert.Equal(
                testData.Parameters.GetValueOrDefault(nameParamName),
                string.Empty);
            Assert.True(testData.Parameters.ContainsKey(descriptionParamName));
            Assert.Equal(
                testData.Parameters.GetValueOrDefault(descriptionParamName),
                string.Empty);
        }

        /// <summary>
        /// Tests parsing command with parameters with short names.
        /// </summary>
        [Fact]
        public void TestParseCommandWithShortParams()
        {
            // arrange
            string command = "repo create -n testName -d testDescr";
            string area = "repo";
            string action = "create";
            string nameParamName = "n";
            string nameParamValue = "testName";
            string descriptionParamName = "d";
            string descriptionParamValue = "testDescr";

            // act
            CommandData testData = CommandParser.ParseCommand(command);

            // assert
            Assert.Equal(area, testData.DataType);
            Assert.Equal(action, testData.Action);
            Assert.True(testData.Parameters.ContainsKey(nameParamName));
            Assert.Equal(
                testData.Parameters.GetValueOrDefault(nameParamName),
                nameParamValue);
            Assert.True(testData.Parameters.ContainsKey(descriptionParamName));
            Assert.Equal(
                testData.Parameters.GetValueOrDefault(descriptionParamName),
                descriptionParamValue);
        }
    }
}
