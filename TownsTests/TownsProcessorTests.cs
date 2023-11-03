using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towns;

namespace TownsTests
{
    public class TownsProcessorTests
    {
        [Test]

        public void Test_ExecuteCommand_InvalidOperation()
        {
            var townProcessor = new TownsProcessor();

            var actual = townProcessor.ExecuteCommand("Alabala");

            Assert.That(actual, Is.EqualTo("Invalid command: Alabala"));
        }

        [Test]

        public void Test_ExecuteCommand_CREATE()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE Paris, London";
            var actual = townProcessor.ExecuteCommand(createCommand);

            Assert.That(actual, Is.EqualTo("Successfully created collection of towns."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]

        public void Test_ExecuteCommand_PRINT()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var printCommand = "PRINT";

            var actual = townProcessor.ExecuteCommand(printCommand);

            Assert.That(actual, Is.EqualTo("Towns: Paris, London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]

        public void Test_ExecuteCommand_ADD()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommand = "ADD Sofia";

            var actual = townProcessor.ExecuteCommand(addCommand);

            Assert.That(actual, Is.EqualTo("Successfully added: Sofia"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }

        [Test]

        public void Test_ExecuteCommand_TryADDExisting()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommand = "ADD London";

            var actual = townProcessor.ExecuteCommand(addCommand);

            Assert.That(actual, Is.EqualTo("Cannot add: London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]

        public void Test_RemoveAt_ValidIndex()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var removeCommand = "REMOVE 1";

            var actual = townProcessor.ExecuteCommand(removeCommand);

            Assert.That(actual, Is.EqualTo("Successfully removed from index: 1"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(1));
        }

        [Test]

        public void Test_Reverse_TwoTowns()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var reverseCommand = "REVERSE";

            var actual = townProcessor.ExecuteCommand(reverseCommand);

            Assert.That(actual, Is.EqualTo("Collection of towns reversed."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]

        public void Test_RemoveAt_InValidIndex()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var removeCommand = "REMOVE 2";

            var actual = townProcessor.ExecuteCommand(removeCommand);

            var expected = "Invalid operation.";

        }

        [Test]

        public void Test_Reverse_NullTowns()
        {
            var townProcessor = new TownsProcessor();

            var createCommand = "CREATE ";
            townProcessor.ExecuteCommand(createCommand);

            var reverseCommand = "REVERSE";

            var actual = townProcessor.ExecuteCommand(reverseCommand);

            var expected = "Cannot reverse a collection of towns with less than 2 items.";

            Assert.AreEqual(expected, actual);
           
        }

    }
}
