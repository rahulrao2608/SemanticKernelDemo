using Microsoft.SemanticKernel;

namespace SemanticKernelDemo
{
    public class semantic_kernel_prompt_templates
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

            string city = "Rome";
            var prompt = "I'm visiting {{$city}}. What are some activities I should do today?";

            var activitiesFunction = kernel.CreateFunctionFromPrompt(prompt);
            var arguments = new KernelArguments { ["city"] = city };

            // InvokeAsync on the KernelFunction object
            var result = await activitiesFunction.InvokeAsync(kernel, arguments);
            Console.WriteLine(result);

            // InvokeAsync on the kernel object
            result = await kernel.InvokeAsync(activitiesFunction, arguments);
            Console.WriteLine(result);
        }
    }
}
