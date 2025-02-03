using UnityEngine;

public class SetCharacterCount : MonoBehaviour
{
    public void SetCharCount(int n)
    {
        FindFirstObjectByType<CharacterManager>().SetTotalCharCount(n);
    }
}
