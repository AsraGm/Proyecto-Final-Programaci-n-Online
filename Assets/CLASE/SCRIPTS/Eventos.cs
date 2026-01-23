using System;
using UnityEngine;
using UnityEngine.Events;

public class Eventos : MonoBehaviour
{
    public event Action eventos;
    PhotonManager photonManager;

    private void OnEnable()
    { eventos += Evento1;eventos += Evento2;eventos += Evento3; }
    private void OnDiseable()
    { eventos -= Evento1; eventos -= Evento2; eventos -= Evento3; }
    void Start()
    {
        eventos.Invoke();    
    }
    public void Evento1()
    { Debug.Log("Evento1");}
    public void Evento2()
    { Debug.Log("Evento2"); }
    public void Evento3()
    { Debug.Log("Evento3"); }

    void Update()
    {
        
    }
}
