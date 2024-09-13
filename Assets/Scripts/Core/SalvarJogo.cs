using UnityEngine;

public class ConfirmarSaída : MonoBehaviour
{
    public GameObject painelConfirmarSaida;

    // Método para mostrar o painel de confirmação depois de clicar no botão sair
    public void MostrarPainelConfirmacao()
    {
        painelConfirmarSaida.SetActive(true);
    }

    // Metodo que faz a aplicação parar: somente quando clicar no sim, deve ser colocado apenas no botão sim
    public void ConfirmarSaida()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Aplication.Quit();
#endif
    }

    // Método que cancela a saída e esconde o painel, somente quando o usuário clicar em cancelar/não
    public void CancelarSaida()
    {
        painelConfirmarSaida.SetActive(false);
    }
}
