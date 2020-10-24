using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour{

    //platform
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] moving_Platforms;
    public GameObject breakablePlatform;

    //timer
    public float platform_Spawn_Timer = 1.2f;
    private float current_Platform_Spawn_Timer;

    private float time_passed = 1f;

    //stevec
    private int platform_Spawn_count;
    private int overall_num_of_platforms_spawned = 0;
    private int second_platform_chance = 2;

    //meje
    public float min_X = -2f, max_X = 2f;

    void Start(){
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    void Update(){
        SpawnPlatforms();
    }

    void SpawnPlatforms(){
        current_Platform_Spawn_Timer += Random.Range(1.5f, 2f) * Time.deltaTime * time_passed;

        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer){ //spawnamo platforme
            ++overall_num_of_platforms_spawned;

            //nastavimo cas
            time_passed = 1 + Timer.Score * 0.01f;

            platform_Spawn_count += (int)Random.Range(1f, 3f); //random sprememba za katera platforma se bo spawnala

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X); //med mejama

            GameObject newPlatform = null;
            //newPlatform.layer = 0;

            if (overall_num_of_platforms_spawned % second_platform_chance == 0){
                second_platform_chance = (int)Random.Range(time_passed * 3f, time_passed * 5f);

                Vector3 temp2 = transform.position;
                if (temp.x - min_X > max_X - temp.x){
                    temp2.x = Random.Range(min_X, temp.x - 1f); //med mejama
                }
                else{
                    temp2.x = Random.Range(temp.x + 1f, max_X); //med mejama
                }
                temp2.y -= 1.2f;// * time_passed;
                GameObject newPlatform2 = Instantiate(platformPrefab, temp2, Quaternion.identity);
                newPlatform2.GetComponent<PlatformScript>().move_Speed = time_passed;
                newPlatform2.transform.parent = transform;
            }

            if (platform_Spawn_count == 2){ //al bo navadna al premikajoca
                if (Random.Range(0, 2) > 0){
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                    newPlatform.layer = 4;
                }
                else{
                    newPlatform = Instantiate(moving_Platforms[Random.Range(0, moving_Platforms.Length)], temp, Quaternion.identity);
                    newPlatform.layer = 4;
                }
            }
            else if (platform_Spawn_count == 3){ //al bo navadna al bo spike
                if (Random.Range(0, 2) > 0){
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else{
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platform_Spawn_count == 4){ //al bo navadna al bo breakable
                if (Random.Range(0, 2) > 0){
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else{
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                } 
            }
            else{ //spawnamo navadno platformo //if (platform_Spawn_count < 2)
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }

            if (platform_Spawn_count > 5){
                platform_Spawn_count = 0; //resetiramo counter
            }

            if (newPlatform){
                //Vector2 histort1 = newPlatform.transform.position;
                //histort1.y *= (1 + time_passed) * 1f;
                //newPlatform.transform.position = histort1;
                newPlatform.GetComponent<PlatformScript>().move_Speed = time_passed;
                newPlatform.transform.parent = transform;
            }
            current_Platform_Spawn_Timer = 0f;
        }
    }
}
