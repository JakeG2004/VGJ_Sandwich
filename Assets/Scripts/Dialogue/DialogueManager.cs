using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    [SerializeField] private Animator _anim;

    private Queue _sentences;
    private DialogueSentence _currentSentence;

    void Start()
    {
        _sentences = new Queue();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _anim.SetBool("IsOpen", true);

        // Get rid of any remaining sentences
        _sentences.Clear();

        // Add all of them from dialogue object
        foreach(DialogueSentence sentence in dialogue._sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        _currentSentence = (DialogueSentence)_sentences.Dequeue();
        _nameText.text = _currentSentence.name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(_currentSentence.sentence));

        _currentSentence?.OnSentenceTrigger?.Invoke();
    }

    IEnumerator TypeSentence(string sentence)
    {
        _dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        _anim.SetBool("IsOpen", false);
    }
}
