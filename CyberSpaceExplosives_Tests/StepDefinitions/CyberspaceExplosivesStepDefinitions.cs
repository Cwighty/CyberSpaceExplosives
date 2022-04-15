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
            context.Add("input", input);
        }

        [When(@"decompressing the input")]
        public void WhenDecompressingTheInput()
        {
            var input = context.Get<string>("input");
            context.Add("output", Decompressor.Decompress(input));
        }

        [Then(@"we get (.*) with a length of (.*)")]
        public void ThenWeGetOutputWithALengthOf(string output, int length)
        {
            context.Get<string>("output").Should().Be(output);
            context.Get<string>("output").Length.Should().Be(length);
        }
    }
}
