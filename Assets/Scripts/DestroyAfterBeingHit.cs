using UnityEngine;
using System.Collections;

public class DestroyAfterBeingHit : MonoBehaviour 
{
    [SerializeField]
    private string otherTag;
    [SerializeField]
    private float waitBeforeDestroying;
    private AudioSource boxHitSound;

    void Start()
    {
        boxHitSound = GetComponent<AudioSource>();
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(waitBeforeDestroying);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == otherTag)
        {
            if (boxHitSound != null)
                boxHitSound.Play();
            StartCoroutine(Kill());
        }
    }
}
