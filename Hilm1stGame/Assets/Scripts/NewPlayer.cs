using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 5;
    
    public int coinsCollected;
    public Text coinsText;

    public Image healthBar;
    public int health = 100;
    private int healthMax = 100;
    [SerializeField] private Vector2 healthBarOrigSize;

    // Start is called before the first frame update
    void Start()
    {
        healthBarOrigSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal")*maxSpeed, 0);

        //Jump once when grounded 
        if (Input.GetButtonDown("Jump") && grounded) 
        {
            velocity.y = jumpPower;
        }
    }

    //Update UI
    public void UpdateUI() 
    {
        // coinsUItext = coinsCollected
        coinsText.text = coinsCollected.ToString();

        //Set the healthBar width to a percentage of its original value. 
        //healthBarOrigSize.x * (health/maxHealth)
        //                                             (below this is equal to healthBar.rectTransform.sizeDelta.x, ....)
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health/(float)healthMax), healthBar.rectTransform.sizeDelta.y);
    }
}
