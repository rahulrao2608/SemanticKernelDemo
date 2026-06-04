# Semantic Kernel Demo

A .NET console application exploring core prompting techniques and prompt templating features of [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel) with Azure OpenAI.

## What's Covered

| Technique | Description |
|---|---|
| Zero-shot prompting | Ask the model directly with no examples |
| Few-shot prompting | Guide the model with input/output examples |
| Chain-of-thought prompting | Break a problem into step-by-step reasoning |
| Persona prompting | Assign a role to shape the model's response style |
| SK prompt templates | Parameterized prompts using `{{$variable}}` syntax |
| Handlebars prompt templates | Richer templates using the Handlebars format, loaded from inline strings or YAML files |

## Project Structure

```
SemanticKernelDemo/
├── Program.cs                          # Entry point; prompt technique examples
├── semantic kernel prompt templates.cs # SK built-in template demo
├── Handlebars prompt templates.cs      # Handlebars template demo
├── HandlebarsPrompt.yaml               # Vision chat prompt (loaded at runtime)
└── SemanticKernelDemo.csproj
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- An Azure OpenAI resource with a deployed model

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/rahulrao2608/SemanticKernelDemo.git
   cd SemanticKernelDemo
   ```

2. Set the required environment variables:

   **Windows (PowerShell)**
   ```powershell
   $env:AZURE_OPENAI_ENDPOINT = "https://<your-resource>.cognitiveservices.azure.com/"
   $env:AZURE_OPENAI_API_KEY  = "<your-api-key>"
   $env:AZURE_OPENAI_MODEL_ID = "gpt-5-chat"   # or your deployed model name
   ```

   **macOS / Linux**
   ```bash
   export AZURE_OPENAI_ENDPOINT="https://<your-resource>.cognitiveservices.azure.com/"
   export AZURE_OPENAI_API_KEY="<your-api-key>"
   export AZURE_OPENAI_MODEL_ID="gpt-5-chat"
   ```

3. Run the project:
   ```bash
   dotnet run
   ```

## Dependencies

| Package | Version |
|---|---|
| `Microsoft.SemanticKernel` | 1.30.0 |
| `Microsoft.SemanticKernel.PromptTemplates.Handlebars` | 1.30.0 |

## Claude Code Integration

This repo is configured with [Claude Code](https://claude.ai/code) via GitHub Actions. Mention `@claude` in any issue or pull request comment to get AI assistance directly in the repo.

To enable it, add your `ANTHROPIC_API_KEY` under **Settings → Secrets and variables → Actions**.
