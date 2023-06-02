using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anum;
    
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anum = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
          if(collision.gameObject.CompareTag("Trap")){
            Die();
          }
    }

    private void Die()
    {
       rb.bodyType = RigidbodyType2D.Static;
       anum.SetTrigger("death");
    }

    //reload the level after a short delay of when paler dies
    private void RestartLevel()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
