using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuar : MonoBehaviour
{
    public int PontosTotal;
    public static Pontuar Pontos;
    public Text TextoPonto;

    // Start is called before the first frame update
    void Start()
    {
        Pontos = this;
    }

    public void AtualizarPontos()
    {
        TextoPonto.text = PontosTotal.ToString();
    }
}
