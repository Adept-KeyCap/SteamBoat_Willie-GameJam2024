using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCheesyManager : MonoBehaviour
{
    public int status = 0;
    private Animator anim;
    private PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<PlayerManager>();
        status = 0;
        anim = GetComponent<Animator>();
        anim.Play("Idle");
    }

    // Update is called once per frame
  

    public void Idle()
    {
        anim.Play("Idle");
    }

    public void HappyScream()
    {
        
    }

    public void Angry()
    {
        
    }

    public void Playful()
    {
        
    }

    public void Syringe()
    {
        
    }

    public void Shredded()
    {
        
    }
}
