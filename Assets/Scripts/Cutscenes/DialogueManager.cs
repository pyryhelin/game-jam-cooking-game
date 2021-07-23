using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    private Queue<string> sentences;
    private string sentence;
    private string[] names;

    // Start is called before the first frame update
    void Start()
    {
        //sentences = new Queue<string>();
        GetComponent<TextMeshProUGUI>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences = new Queue<string>();
        nameText.SetText(dialogue.name[0]);
        names = dialogue.name;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //Debug.Log(sentences.Count);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("function run");
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        sentence = sentences.Dequeue();
        string[] checkChange = sentence.Split(':');

        if (checkChange[0] == "NAME")
        {
            ChangeName(checkChange[1]);
            sentence = sentences.Dequeue();
        }
        if (checkChange[0] == "IMAGE")
        {
            //ChangeImage(checkChange[1], checkChange[2]);
            sentence = sentences.Dequeue();
        }

        dialogueText.SetText(sentence);
        //Debug.Log("set text");
    }

    private void ChangeName(string foundName)
    {
        foreach(string name in names)
        {
            if (name == foundName)
            {
                nameText.SetText(foundName);
                return;
            }
        }
    }

    private void ChangeImage(string name, int num)
    {

    }

    void EndDialogue()
    {
        Debug.Log("End conversation");
    }

}
