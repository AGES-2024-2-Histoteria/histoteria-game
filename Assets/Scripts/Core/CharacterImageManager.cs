using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageManager : MonoBehaviour
{
    // Referência para a UI Image que exibirá o personagem
    public Image characterImage;

    // Lista de personagens e suas imagens (sprites)
    [System.Serializable]
    public class CharacterSprite
    {
        public string characterName;  // Nome do personagem
        public Sprite characterSprite;  // Sprite do personagem
    }

    public CharacterSprite[] characterSprites;  // Array para configurar no Unity Inspector
    private Dictionary<string, Sprite> characterDictionary;  // Dicionário para mapear nome -> sprite

    void Start()
    {
        // Inicializa o dicionário e associa os nomes aos sprites
        characterDictionary = new Dictionary<string, Sprite>();
        foreach (var character in characterSprites)
        {
            characterDictionary.Add(character.characterName, character.characterSprite);
        }
    }

    // Método para exibir a imagem de acordo com o nome do personagem
    public void ShowCharacter(string characterName)
    {
        if (characterDictionary.ContainsKey(characterName))
        {
            characterImage.sprite = characterDictionary[characterName];
        }
        else
        {
            Debug.LogWarning("Personagem não encontrado: " + characterName);
        }
    }
}
