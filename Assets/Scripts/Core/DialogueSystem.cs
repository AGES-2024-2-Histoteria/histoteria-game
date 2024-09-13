using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;   // Caixa de texto do di�logo
    public TextMeshProUGUI characterNameText;  // Caixa de texto do nome do personagem

    public CharacterImageManager characterImageManager;  // Refer�ncia ao CharacterImageManager

    [System.Serializable]
    public class Dialogue
    {
        public string characterName;  // Nome do personagem
        [TextArea(3, 10)]
        public string[] sentences;  // Falas do personagem
    }

    public Dialogue[] dialogues;
    private int currentDialogueIndex = 0;
    private int currentSentenceIndex = 0;

    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        currentSentenceIndex = 0;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentSentenceIndex < dialogues[currentDialogueIndex].sentences.Length)
        {
            // Atualiza o nome do personagem na interface
            string currentCharacter = dialogues[currentDialogueIndex].characterName;
            characterNameText.text = currentCharacter;

            // Troca a imagem do personagem conforme o nome
            characterImageManager.ShowCharacter(currentCharacter);

            // Exibe a fala atual
            dialogueText.text = dialogues[currentDialogueIndex].sentences[currentSentenceIndex];
            currentSentenceIndex++;
        }
        else
        {
            // Avan�a para o pr�ximo di�logo
            currentDialogueIndex++;
            if (currentDialogueIndex < dialogues.Length)
            {
                currentSentenceIndex = 0;
                DisplayNextSentence();
            }
            else
            {
                // Finaliza o di�logo
                Debug.Log("Di�logo conclu�do.");
                dialogueText.text = "";  // Limpa o texto de di�logo
            }
        }
    }
}
