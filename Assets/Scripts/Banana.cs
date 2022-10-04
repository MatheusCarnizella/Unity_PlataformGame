using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private SpriteRenderer Render;
    private CircleCollider2D Colisor;
    public GameObject Coletado;
    public int Pontuacao;

    // Start is called before the first frame update
    void Start()
    {
        Render = GetComponent<SpriteRenderer>();
        Colisor = GetComponent<CircleCollider2D>();        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Render.enabled = false;
            Colisor.enabled = false;
            Coletado.SetActive(true);

            Pontuar.Pontos.PontosTotal += Pontuacao;
            Pontuar.Pontos.AtualizarPontos();

            Destroy(gameObject, 0.5f);
        }
    }
}
