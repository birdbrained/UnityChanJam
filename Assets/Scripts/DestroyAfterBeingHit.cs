using UnityEngine;
using System.Collections;

public class DestroyAfterBeingHit : MonoBehaviour 
{
    [SerializeField]
    private string otherTag;
    [SerializeField]
    private float waitBeforeDestroying;
    private AudioSource hitSound;

    void Start()
    {
        hitSound = GetComponent<AudioSource>();
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
            //Debug.Log("Hit!");
            if (hitSound != null)
                hitSound.Play();
            StartCoroutine(Kill());
        }
    }
}
