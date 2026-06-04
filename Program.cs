using Microsoft.SemanticKernel;
using SemanticKernelDemo;
// Populate values from your OpenAI deployment
var modelId = Environment.GetEnvironmentVariable("AZURE_OPENAI_MODEL_ID") ?? "gpt-5-chat";
var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT environment variable is not set.");
var apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") ?? throw new InvalidOperationException("AZURE_OPENAI_API_KEY environment variable is not set.");

// Create a kernel with Azure OpenAI chat completion
var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

// Build the kernel
Kernel kernel = builder.Build();

//Zero-shot learning
    // string prompt = $"""
    // Instructions: What is the intent of this request?
    // If you don't know the intent, don't guess; instead respond with "Unknown".
    // Choices: SendEmail, SendMessage, CompleteTask, CreateDocument, Unknown.
    // User Input: {request}
    // Intent: 
    // """;

//Few shot learning
    //string prompt = $"""
    // Instructions: What is the intent of this request?
    // If you don't know the intent, don't guess; instead respond with "Unknown".
    // Choices: SendEmail, SendMessage, CompleteTask, CreateDocument, Unknown.

    // User Input: Can you send a very quick approval to the marketing team?
    // Intent: SendMessage

    // User Input: Can you send the full update to the marketing team?
    // Intent: SendEmail

    // User Input: {request}
    // Intent:
    // """;

// string prompt = $"""
// A farmer has 150 apples and wants to sell them in baskets. Each basket can hold 12 apples. If any apples remain after filling as many baskets as possible, the farmer will eat them. How many apples will the farmer eat?
// Instructions: Explain your reasoning step by step before providing the answer.
// """;

string prompt = $"""
Instructions: A farmer has 150 apples and wants to sell them in baskets. Each basket can hold 12 apples. If any apples remain after filling as many baskets as possible, the farmer will eat them. How many apples will the farmer eat?

First, calculate how many full baskets the farmer can make by dividing the total apples by the apples per basket:
1. 

Next, subtract the number of apples used in the baskets from the total number of apples to find the remainder: 
1.

"Finally, the farmer will eat the remaining apples:
1.
""";

//Use personas in prompts
// string prompt = $"""
// You are a highly experienced software engineer. Explain the concept of asynchronous programming to a beginner.
// """;

//var result = await kernel.InvokePromptAsync(prompt);
//Console.WriteLine(result);

//await semantic_kernel_prompt_templates.RunAsync();
await Handlebars_prompt_templates.RunAsync();
