using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.PromptTemplates.Handlebars;
//using Microsoft.SemanticKernel.Connectors.AI.OpenAI; // Azure OpenAI connector
using Microsoft.SemanticKernel.PromptTemplates; // For prompt template configuration
using System; // For Console and basic types
using System.Collections.Generic; // For Dictionary and KernelArguments
using System.IO; // For file operations (e.g., loading YAML)
using System.Threading.Tasks; // For async/await support


namespace SemanticKernelDemo
{
    public class Handlebars_prompt_templates
    {
        public static async Task RunAsync()
        {
            var modelId = Environment.GetEnvironmentVariable("AZURE_OPENAI_MODEL_ID") ?? "gpt-5-chat";
            var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT environment variable is not set.");
            var apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") ?? throw new InvalidOperationException("AZURE_OPENAI_API_KEY environment variable is not set.");

            // Create a kernel with Azure OpenAI chat completion
            var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

            // Build the kernel
            Kernel kernel = builder.Build();

            //const string HandlebarsTemplate = """
            // <message role="system">You are an AI assistant designed to help with image recognition tasks.</message>
            // <message role="user">
            // <text>{{request}}</text>
            // <image>{{imageData}}</image>
            // </message>
            // """;

            //// Create the prompt template configuration
            //var templateFactory = new HandlebarsPromptTemplateFactory();
            //var promptTemplateConfig = new PromptTemplateConfig()
            //{
            //    Template = HandlebarsTemplate,
            //    TemplateFormat = "handlebars",
            //    Name = "Vision_Chat_Prompt",
            //};

            //// Create a function from the Handlebars template configuration
            //var function = kernel.CreateFunctionFromPrompt(promptTemplateConfig, templateFactory);

            //var arguments = new KernelArguments(new Dictionary<string, object?>
            //{
            //    {"request","Describe this image:"},
            //    {"imageData", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAAXNSR0IArs4c6QAAACVJREFUKFNj/KTO/J+BCMA4iBUyQX1A0I10VAizCj1oMdyISyEAFoQbHwTcuS8AAAAASUVORK5CYII="}
            //});

            //var response = await kernel.InvokeAsync(function, arguments);
            //Console.WriteLine(response);


            // Load prompt from resource
            // var handlebarsPromptYaml = EmbeddedResource.Read("SemanticKernelDemo.HandlebarsPrompt.yaml");
            //var handlebarsPromptYaml = await File.ReadAllTextAsync(Path.Combine(AppContext.BaseDirectory, "SemanticKernelDemo", "HandlebarsPrompt.yaml"));
            var yamlPath = Path.Combine(AppContext.BaseDirectory, "HandlebarsPrompt.yaml");
            // Create the prompt function from the YAML resource
            var templateFactory1 = new HandlebarsPromptTemplateFactory();
            //var function1 = kernel.CreateFunctionFromPromptYaml(handlebarsPromptYaml, templateFactory);

            var function1 = kernel.CreateFunctionFromPrompt(
                yamlPath,
                templateFormat: "handlebars"
             );

            // Input data for the prompt rendering and execution
            var arguments1 = new KernelArguments(new Dictionary<string, object?>
            {
                {"request","Describe this image:"},
                {"imageData", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAAXNSR0IArs4c6QAAACVJREFUKFNj/KTO/J+BCMA4iBUyQX1A0I10VAizCj1oMdyISyEAFoQbHwTcuS8AAAAASUVORK5CYII="}
            });

            // Invoke the prompt function
            var response1 = await kernel.InvokeAsync(function1, arguments1);

        }
    }
}
