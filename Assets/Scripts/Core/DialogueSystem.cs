using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;   // Caixa de texto do diálogo
    public TextMeshProUGUI characterNameText;  // Caixa de texto do nome do personagem

    public CharacterImageManager characterImageManager;  // Referência ao CharacterImageManager

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
            // Avança para o próximo diálogo
            currentDialogueIndex++;
            if (currentDialogueIndex < dialogues.Length)
            {
                currentSentenceIndex = 0;
                DisplayNextSentence();
            }
            else
            {
                // Finaliza o diálogo
                Debug.Log("Diálogo concluído.");
                dialogueText.text = "";  // Limpa o texto de diálogo
            }
        }
    }
}
