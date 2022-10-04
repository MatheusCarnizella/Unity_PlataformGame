using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Velocidade;
    public float PuloF;
    private Rigidbody2D Rigido;
    public bool Pulando;
    public bool PuloDuplo;
    private Animator Animar;

    // Start is called before the first frame update
    void Start()
    {
        Rigido = GetComponent<Rigidbody2D>();
        Animar = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        Pulo();
    }

    void Movimentacao()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * Velocidade;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            Animar.SetBool("Walker", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            Animar.SetBool("Walker", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            Animar.SetBool("Walker", false);
        }
    }

    void Pulo()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!Pulando)
            {
                Rigido.AddForce(new Vector2(0f, PuloF), ForceMode2D.Impulse);
                PuloDuplo = true;
                Animar.SetBool("Jump", true);
            }
            else
            {
                if (PuloDuplo)
                {
                    Rigido.AddForce(new Vector2(0f, PuloF * 1.2f), ForceMode2D.Impulse);
                    PuloDuplo = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D Colidir)
    {
        if (Colidir.gameObject.layer == 8)
        {
            Pulando = false;
            Animar.SetBool("Jump", false);
        }

        if (Colidir.gameObject.tag == "Espinhos")
        {
            Controlador.Control.FimdoJogo();
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D Colidir)
    {
        if (Colidir.gameObject.layer == 8)
        {
            Pulando = true;
        }
    }
}
