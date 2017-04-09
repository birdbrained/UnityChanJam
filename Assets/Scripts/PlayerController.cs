using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class PlayerController : MonoBehaviour 
{
    public float health;
    private float maxHealth;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Image speedRing;
    private Rigidbody rb;

    private Color safeSpeedColor = new Color(0.302f, 0.855f, 1f, 1f);
    private Color highSpeedColor = new Color(1f, 0.663f, 0.302f, 1f);

    [SerializeField]
    private GameObject explosionObject;
    private bool canExplode = true;
    //[SerializeField]
    private Material blownupMaterial;

    [SerializeField]
    private float immortalTime;
    public bool immortal = false;
    public bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }
    

    /*
    private bool timerActive = false;
    private float timer = 15f;
    [SerializeField]
    private Text timerText;
    */

    // Use this for initialization
	void Start () 
    {
        //GameManager.Instance.Health = health;
        maxHealth = health;
        rb = GetComponent<Rigidbody>();
        SwapCar sc = GameManager.Instance.gameObject.GetComponent<SwapCar>();
        blownupMaterial = sc.carBlownupMaterials[SwapCar.index];
        //blownupMaterial 
    }

    // Update is called once per frame
	void Update () 
    {
        if (healthText != null)
            healthText.text = health.ToString("F2");
        if (healthBar != null)
            healthBar.fillAmount = (health / maxHealth);
        if (speedText != null)
            speedText.text = rb.velocity.magnitude.ToString("F2");
        if (speedRing != null)
        {
            speedRing.fillAmount = (rb.velocity.magnitude / 35);
            if (rb.velocity.magnitude < 20f)
                speedRing.color = safeSpeedColor;
            else
                speedRing.color = highSpeedColor;
        }
        /*if (timerActive && timerText != null)
        {
            timerText.text = "0:" + timer.ToString("00");
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timerActive = false;
                Debug.Log("Time's up!");
            }
        }
        else if (!timerActive && timerText != null)
            timerText.text = "";
        */
        //Debug.Log("Player velocity: " + rb.velocity.magnitude.ToString());
        if (transform.position.y < -40f)
        {
            health = 0;
        }
        if (health <= 0f && canExplode)
        {
            Explode();
        }
        else if (health <= 0)
        {
            rb.velocity *= 0.9f;
        }
	}

    public void Explode()
    {
        //CarUserControl.Instance.CanMove = false;
        CarUserControl car = GetComponent<CarUserControl>();
        car.CanMove = false;
        //rb.velocity *= 0.8f;
        if (explosionObject != null)
        {
            Instantiate(explosionObject, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (blownupMaterial != null)
            GetComponentInChildren<Renderer>().material = blownupMaterial;
        canExplode = false;
        //timerActive = true;
        GameManager.Instance.TimerActive = true;
    }

    private IEnumerator IndicateImmortality()
    {
        MeshRenderer myMesh;

        while (immortal)
        {
            foreach (Transform child in transform)
            {
                myMesh = child.GetComponent<MeshRenderer>();
                if (myMesh != null)
                    myMesh.enabled = false;
            }

            yield return new WaitForSeconds(0.1f);

            foreach (Transform child in transform)
            {
                myMesh = child.GetComponent<MeshRenderer>();
                if (myMesh != null)
                    myMesh.enabled = true;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TakeDamage(float damage, bool canBeImmortal)
    {
        if (!immortal)
        {
            health -= damage;
            if (!IsDead && canBeImmortal)
            {
                immortal = true;
                StartCoroutine(IndicateImmortality());
                yield return new WaitForSeconds(immortalTime);
                immortal = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        int canGiveScore = 0;
        bool canBeImmortal = false;

        GameObject other = c.collider.gameObject;

        //Debug.Log("HIT: " + other.gameObject.name + ", tag: " + other.gameObject.tag);
        float damage = 0;
        if (other.gameObject.tag == "Object")
        {
            damage = other.gameObject.GetComponent<Rigidbody>().mass * rb.velocity.magnitude;
            canGiveScore = 1;
        }
        else if (other.gameObject.tag == "Front")
        {
            if (rb.velocity.magnitude >= 20f)
            {
                damage = health;
            }
            else
            {
                damage = other.gameObject.GetComponentInParent<Rigidbody>().mass * rb.velocity.magnitude;
                canGiveScore = 1;
            }
        }
        else if (other.gameObject.tag == "Wall")
        {
            damage = other.gameObject.GetComponent<Rigidbody>().mass * rb.velocity.magnitude;
            canBeImmortal = true;
        }
        //Debug.Log("Damage: " + damage.ToString("F2"));
        //Hurt other object
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            //If the enemy still has health left, damage them
            if (enemy.getHealth() > 0f)
            {
                enemy.setHealth(enemy.getHealth() - damage);
            }
            else
            {
                canGiveScore = 0;
            }
            //...but if they are already dead, you can't get more score from them
        }

        //health -= damage;
        StartCoroutine(TakeDamage(damage, canBeImmortal));
        if (canGiveScore == 1)
        {
            GameManager.Instance.Score += (int)damage * 1000;
            GameManager.Instance.ThisLevelScore += (int)damage * 1000;
        }
    }
}
