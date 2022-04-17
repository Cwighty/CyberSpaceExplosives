using CyberSpaceExplosives;
using System;
using TechTalk.SpecFlow;

namespace CyberSpaceExplosives_Tests.StepDefinitions
{ 
    [Binding]
    public class CyberspaceExplosivesStepDefinitions
    {
        private ScenarioContext context;
        public CyberspaceExplosivesStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }
        [Given(@"the input (.*)")]
        public void GivenTheInput(string input)
        {
            var decompressor = new Decompressor();
            decompressor.SetFromFile(input);
            context.Add("decompressor", decompressor);
        }

        [When(@"decompressing the input")]
        public void WhenDecompressingTheInput()
        {
            var decompressor = context.Get<Decompressor>("decompressor");
            decompressor.Decompress();
        }

        [When(@"fully decompressing the input")]
        public void WhenFullyDecompressingTheInput()
        {
            var decompressor = context.Get<Decompressor>("decompressor");
            decompressor.DecompressUntilNoMoreCommandBlocks();
        }


        [Then(@"we get (.*) with a length of (.*)")]
        public void ThenWeGetOutputWithALengthOf(string output, int length)
        {
            var decompressor = context.Get<Decompressor>("decompressor");
            decompressor.GetDeompressedString().Should().Be(output);
            decompressor.GetLengthOfDecompressedString().Should().Be(length);
        }
    }
}
