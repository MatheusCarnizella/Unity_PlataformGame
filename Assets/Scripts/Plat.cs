using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat : MonoBehaviour
{
    public float TempoCair;
    private TargetJoint2D Alvo;
    private BoxCollider2D Caixa;
    // Start is called before the first frame update
    void Start()
    {
        Alvo = GetComponent<TargetJoint2D>();
        Caixa = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D Colidir)
    {
        if (Colidir.gameObject.tag == "Player")
        {
            Invoke("Cair", TempoCair);
        }

    }
    
    void OnTriggerEnter2D(Collider2D Colidir)
    {
        if (Colidir.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Cair()
    {
        Alvo.enabled = false;
        Caixa.isTrigger = true;
    }
}
