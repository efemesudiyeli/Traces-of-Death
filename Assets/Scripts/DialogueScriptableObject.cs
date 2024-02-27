using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Detective/DialogueSO", order = 0)]
public class DialogueScriptableObject : ScriptableObject
{
    public Dialogues[] dialogueLines;

    [System.Serializable]
    public class Dialogue
    {
        public Dialogue(string line, string person)
        {
            this.person = person;
            this.line = line;
        }

        public string person;
        public string line;
    }

    [System.Serializable]
    public class Dialogues
    {
        public Dialogue[] lines;
    }

}