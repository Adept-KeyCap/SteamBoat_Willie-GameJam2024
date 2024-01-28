using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource catBomb_drop_SFX;
    [SerializeField] private AudioSource catBox_drop_SFX;
    [SerializeField] private AudioSource bombExplotion_SFX;
    [SerializeField] private AudioSource catDrag_SFX;
    [SerializeField] private AudioSource catSuperBomb_drop_SFX;
    [SerializeField] private AudioSource invincibility_SFX;
    [SerializeField] private AudioSource redCheese_SFX;
    [SerializeField] private AudioSource phantom_SFX;
    [SerializeField] private AudioSource mysteryBox_SFX;
    [SerializeField] private AudioSource click_SFX;
    [SerializeField] private AudioSource mouseHurt_SFX;
    [SerializeField] private AudioSource catEvilLaugh_SFX;
    [SerializeField] private AudioSource catPlayful_SFX;
    [SerializeField] private AudioSource catAngry_SFX;
    [SerializeField] private AudioSource catAndSrynge_SFX;
    [SerializeField] private AudioSource cheeseChomp_SFX;
    [SerializeField] private AudioSource catSheddredMode_SFX;
    [SerializeField] private AudioSource poof_SFX;

    public void Play_CatBomb_Drop()
    {
        catBomb_drop_SFX.Play();
    }

    public void Play_catBox_drop_SFX()
    {
        catBox_drop_SFX.Play();
    }

    public void Play_bombExplotion_SFX()
    {
        bombExplotion_SFX.Play();
    }

    public void Play_catDrag_SFX()
    {
        catDrag_SFX.Play();
    }

    public void Play_catSuperBomb_drop_SFX()
    {
        catSuperBomb_drop_SFX.Play();
    }

    public void Play_invincibility_SFX()
    {
        invincibility_SFX.Play();
    }

    public void Play_redCheese_SFX()
    {
        catBomb_drop_SFX.Play();
    }

    public void Play_phantom_SFX()
    {
        phantom_SFX.Play();
    }

    public void Play_mysteryBox_SFX()
    {
        mysteryBox_SFX.Play();
    }

    public void Play_click_SFX()
    {
        click_SFX.Play();
    }

    public void Play_mouseHurt_SFX()
    {
        mouseHurt_SFX.Play();
    }

    public void Play_catEvilLaugh_SFX()
    {
        catEvilLaugh_SFX.Play();
    }

    public void Play_catPlayful_SFX()
    {
        catPlayful_SFX.Play();
    }

    public void Play_catAngry_SFX()
    {
        catAngry_SFX.Play();
    }

    public void Play_catAndSrynge_SFX()
    {
        catAndSrynge_SFX.Play();
    }

    public void Play_cheeseChomp_SFX()
    {
        cheeseChomp_SFX.Play();
    }

    public void Play_catSheddredMode_SFX()
    {
        catSheddredMode_SFX.Play();
    }

    public void Play_poof_SFX()
    {
        poof_SFX.Play();
    }
}
