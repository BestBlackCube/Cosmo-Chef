using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class FoodDrop_Script : MonoBehaviour
{
    [SerializeField] GameObject[] FoodObject_prefab;
    [SerializeField] GameObject[] drop_inFieldObject;
    [SerializeField] Vector3[] Object_transform;

    [SerializeField] GameObject[] HitObject_prefab;
    [SerializeField] GameObject[] drop_WidthObject;
    [SerializeField] GameObject[] drop_HeightObject;

    [SerializeField] FoodTory_Script foodtory;

    [SerializeField] float drop_timer = 0;
    [SerializeField] float dropHeight_timer = 0;
    [SerializeField] float dropWidth_timer = 0;

    public string Box_name;

    public int copyHeightCount = 0;
    int copyWidthCount = 0;
    public bool dropFood = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dropFood == true)
        {
            if (drop_timer < 1f) drop_timer += Time.deltaTime;
            else
            {
                int transformCount = Random.Range(0, 11);
                int FoodCount = Random.Range(0, 3);
                switch(transformCount)
                {
                    case 0:
                        if (drop_inFieldObject[0] == null && Box_name != "Right4")
                            drop_inFieldObject[0] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[0], Quaternion.identity);
                        break;
                    case 1:
                        if (drop_inFieldObject[1] == null && Box_name != "Left4")
                            drop_inFieldObject[1] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[1], Quaternion.identity);
                        break;
                    case 2:
                        if (drop_inFieldObject[2] == null && Box_name != "Right10")
                            drop_inFieldObject[2] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[2], Quaternion.identity);
                        break;
                    case 3:
                        if (drop_inFieldObject[3] == null && Box_name != "Left10")
                            drop_inFieldObject[3] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[3], Quaternion.identity);
                        break;
                    case 4:
                        if (drop_inFieldObject[4] == null && Box_name != "Right7")
                            drop_inFieldObject[4] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[4], Quaternion.identity);
                        break;
                    case 5:
                        if (drop_inFieldObject[5] == null && Box_name != "Left7")
                            drop_inFieldObject[5] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[5], Quaternion.identity);
                        break;
                    case 6:
                        if (drop_inFieldObject[6] == null && Box_name != "Right2.5")
                            drop_inFieldObject[6] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[6], Quaternion.identity);
                        break;
                    case 7:
                        if (drop_inFieldObject[7] == null && Box_name != "Left2.5")
                            drop_inFieldObject[7] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[7], Quaternion.identity);
                        break;
                    case 8:
                        if (drop_inFieldObject[8] == null && Box_name != "Right8.5")
                            drop_inFieldObject[8] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[8], Quaternion.identity);
                        break;
                    case 9:
                        if (drop_inFieldObject[9] == null && Box_name != "Left8.5")
                            drop_inFieldObject[9] = Instantiate(FoodObject_prefab[FoodCount], Object_transform[9], Quaternion.identity);
                        break;

                    default:
                        break;
                }
                drop_timer = 0f;
            }
            if(foodtory.EndingCount > 2)
            {
                if (dropHeight_timer < 1f) dropHeight_timer += Time.deltaTime;
                else
                {
                    if (copyHeightCount > 9) copyHeightCount = 0;

                    int transformCount = Random.Range(-12, 13);
                    Vector3 Height_offset = new Vector3(transformCount, 8, 2);
                    if (drop_HeightObject[copyHeightCount] == null)
                        drop_HeightObject[copyHeightCount] = Instantiate(HitObject_prefab[0], Height_offset, Quaternion.identity);
                    copyHeightCount++;
                    dropHeight_timer = 0f;
                }
            }

            if (dropWidth_timer < 1.5f) dropWidth_timer += Time.deltaTime;
            else
            {
                if (copyWidthCount > 9) copyWidthCount = 0;

                int transformCount = Random.Range(-5, 7);
                Vector3 Width_offset = new Vector3(14, transformCount + 0.5f, 2);
                if (drop_WidthObject[copyWidthCount] == null)
                    drop_WidthObject[copyWidthCount] = Instantiate(HitObject_prefab[1], Width_offset, Quaternion.identity);
                copyWidthCount++;
                dropWidth_timer = 0f;
            }
        }
        else
        {
            for(int i = 0; i < 10; i++)
            {
                Destroy(drop_inFieldObject[i]);
                Destroy(drop_HeightObject[i]);
                Destroy(drop_WidthObject[i]);
                drop_inFieldObject[i] = null;
                drop_HeightObject[i] = null;
                drop_WidthObject[i] = null;
            }
        }
    }
}
