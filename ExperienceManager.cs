using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange ;

    public void AddExperience( int amount){
        OnExperienceChange?.Invoke(amount); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        
        }
        else{
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
