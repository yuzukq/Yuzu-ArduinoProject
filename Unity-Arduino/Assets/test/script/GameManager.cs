using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //staticをつけるとインスタンス単位で生成されるのではなく，アプリ単位で一つだけ生成される．
    //->インスタンスの参照をせずに直接GameControllerにの関数，変数にアクセスできるようになる．

    private int totalScore = 0;  // 衝突回数を記録する変数
    float PlayTime = 0;
    float clearTime = 0;




    private void Awake()//Awake()はゲーム開始時にStart()より先に呼ばれる．
    {
        instance = this;
    }

    // スコアを増やす関数
    public void AddScore()
    {
        totalScore++;
        //Debug.Log($"子ペロロ撃破数: {totalScore}");
    }

    public void ReduceScore(){
        totalScore--;
    }

    // スコアを取得する関数
    public int GetScore()
    {
        return totalScore;
    }

    public int ResetScore()
    {
        return totalScore = 0;
    }

    private void Update()
    {
        PlayTime += Time.deltaTime;
    }

    public float GameClear()
    {
        clearTime = PlayTime;
        Debug.Log(clearTime);
        return clearTime;
    }
}
