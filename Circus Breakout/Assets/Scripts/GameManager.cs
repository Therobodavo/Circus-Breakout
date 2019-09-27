using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Animal> animals = new List<Animal>();

    private int currentAnimal = 0;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);

        animals[0].isUnderControl = true;
        animals[1].isUnderControl = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchAnimal();
        }
    }

    void SwitchAnimal()
    {
        if(currentAnimal == 0)
        {
            currentAnimal = 1;
            animals[1].isUnderControl = true;
            animals[0].isUnderControl = false;
        }
        else
        {
            currentAnimal = 0;
            animals[0].isUnderControl = true;
            animals[1].isUnderControl = false;
        }
    }
}
