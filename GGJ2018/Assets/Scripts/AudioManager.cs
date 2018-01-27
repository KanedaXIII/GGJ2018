using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    private static AudioManager instance = null;
    
   public List<GameObject> soundSourceList = new List<GameObject>();
  
    public static AudioManager Instance
    {
        get
        {
            return AudioManager.instance;
        }
       
    }

    void Awake()
    {
        if (AudioManager.instance == null)
            AudioManager.instance = this;
        else if (AudioManager.instance != this)
            AudioManager.Destroy(this.gameObject);
        // No destruir con los cambios de escena
        AudioManager.DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    //hacer que suene cada vez que andas 
    void Update() {

    }

    public void PlaySound(AudioSource audS,bool check)
    {
        if (check == true)
            audS.Play();
        //else    audS.Stop();
    }

    public void WhiteNoise(bool deafB)
    {
        if (deafB)
        {
            foreach (GameObject g in soundSourceList) {
                g.GetComponent<AudioSource>().volume = 0.0f;
            }
        }
        else
        {
            foreach (GameObject g in soundSourceList)
            {
                g.GetComponent<AudioSource>().volume = GameManager.Instance.volumeAudio ;
                
            }
        }
    }
}
