using UnityEngine;

public enum AIProviderType { OpenAI, Gemini }

public class AIManager : MonoBehaviour
{
    public AIProviderType provider;
    public SceneExecutor executor;

    OpenAIProvider openAI = new OpenAIProvider();
    GeminiProvider gemini = new GeminiProvider();

    public async void Send(string message)
    {
        string json = provider == AIProviderType.OpenAI
            ? await openAI.Ask(message)
            : await gemini.Ask(message);

        executor.Execute(json);
    }

    public void SwitchProvider()
    {
        provider = provider == AIProviderType.OpenAI ? AIProviderType.Gemini : AIProviderType.OpenAI;
    }
}
