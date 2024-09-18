using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmarSa�da : MonoBehaviour
{
    public GameObject painelConfirmarSaida;

    // M�todo para mostrar o painel de confirma��o depois de clicar no bot�o sair
    public void MostrarPainelConfirmacao()
    {
        painelConfirmarSaida.SetActive(true);
    }

    // Metodo que faz a aplica��o parar: somente quando clicar no sim, deve ser colocado apenas no bot�o sim
    public void ConfirmarSaida()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Aplication.Quit();
#endif
    }

    // M�todo que cancela a sa�da e esconde o painel, somente quando o usu�rio clicar em cancelar/n�o
    public void CancelarSaida()
    {
        painelConfirmarSaida.SetActive(false);
    }
}
