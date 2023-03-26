using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public string getTime()
    {
        return time.ToString("0");
    }

    public void waitTime(float timeleft)
    {
        if (timeleft > 0)
        {
            time -= Time.deltaTime;
        } 
        else
        {
            return;
        }
    }
}
