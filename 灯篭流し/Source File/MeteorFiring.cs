using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MeteorFiring : MonoBehaviour
{
    public bool goal = false;//ゴールについたか
    public GameObject Prefab;//流星
    [SerializeField]
    private Clear clearScript;
    [SerializeField]
    private int instantiateCount;
    private bool randFlag;
    private bool production;

    [HideInInspector]
    public bool firstcreate = false;//一回つくったか
    private float randX, randY, randZ;//流星の位置指定用のランダム
    [SerializeField]
    private float coolTimer;

    // Use this for initialization
    void Start()
    {
        production = true;
        //this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ゴールに到達しているか？
        if (goal == true && firstcreate == false)
        {
            if (production)
            {
                randFlag = true;

                if (randFlag)
                {
                    InstantiateStarPrefab();
                    production = false;
                    randFlag = false;
                    //listClear = true;
                }
            }

            // ゴールに到達した灯篭の数と生成した流星の数が一緒なら
            if (instantiateCount == clearScript.ClearTourou)
            {
                coolTimer = 0.0f;
                firstcreate = true;
                production = false;
            }

            // ゴールに到達した灯篭の数より生成した流星の数少なかったら
            if (instantiateCount < clearScript.ClearTourou)
            {
                coolTimer += Time.deltaTime;

                if (coolTimer >= 3.0f)
                {
                    production = true;
                    coolTimer = 0.0f;
                }
            }
        }
    }

    /// <summary>
    /// 乱数生成
    /// </summary>
    void RandomCreate()
    {
        randX = Random.Range(-10.0f, 10.0f);
        randY = Random.Range(0.0f, 20.0f);
        randZ = Random.Range(-20.0f, 20.0f);
    }

    /// <summary>
    /// 流星の生成
    /// </summary>
    private void InstantiateStarPrefab()
    {
        // 流星を１～５個の間でランダム生成させる
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            RandomCreate();

            // ゴールに到達した灯篭の数より生成した流星の数少なかったら
            if (instantiateCount < clearScript.ClearTourou)
            {
                // 流星の生成と生成する位置
                GameObject obj = Instantiate(Prefab);
                obj.gameObject.transform.position = this.transform.position;
                obj.gameObject.transform.position += new Vector3(randX, randY, randZ);

                // 流星の生成数
                instantiateCount = instantiateCount + 1;
            }

            // ゴールに到達した灯篭の数より生成した流星の数が多く生成されそうなら
            if (instantiateCount > clearScript.ClearTourou)
            {
                // ゴールに到達した灯篭の数より多くは生成しない
                GameObject.Instantiate(null);
            }
        }
    }
}
