using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueSentence
{
    public string name;
    [TextArea(3, 10)]
    public string sentence;
    public UnityEvent OnSentenceTrigger;
}

[System.Serializable]
public class Dialogue
{
    public DialogueSentence[] _sentences;
}
