using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Dialogue dialogue;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSen();

    }


    public void DisplayNextSen()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    public void EndDialogue()
    {
        PlayerPrefs.SetInt("DialogueFinished", 1);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    
}
