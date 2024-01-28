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
        if (anim.GetBool("IsPlayful") == false)
        {
            anim.Play("CheesyCatHappyScream");
        }
    }

    public void Angry()
    {
        if (anim.GetBool("IsPlayful") == false)
        {
            anim.Play("CheesyCatAngry");
        }
    }

    public void Playful()
    {
        anim.Play("CheesyCatPlayful");
        anim.SetBool("IsPlayful", true);
    }

    public void Syringe()
    {
        anim.SetBool("IsSyringe", true);
        anim.Play("CheesyCatSyringe");
    }

    public void Shredded()
    {
        anim.SetBool("IsShredded", true);
        anim.Play("CheesyCatShredded");
    }

    public void ShreddedOff()
    {
        anim.SetBool("IsShredded", false);
    }
    
}
