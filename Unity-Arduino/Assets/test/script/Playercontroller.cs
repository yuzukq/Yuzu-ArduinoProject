<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed = 0.05f;
    public float RotationSpeed = 0.5f;
    public GameObject Effect;
    public AudioSource audioSource;// 音の発信源
    public AudioClip GetSE; //音源
    public AudioClip FailSE;

    //speed変数に三次元x,y,zの値の入れ物を用意
    Vector3 speed = Vector3.zero;   //キャラクタの座標を格納する変数
    Vector3 playerRote = Vector3.zero; //キャラクタの向きを格納する変数

    public Animator PlayerAnimator;
    bool isEmoteStun; //アニメーションのフラグ

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        Move();
        Rotation();
        Camera.transform.position = transform.position;
        emote();
    }

    void Move()
    {
        speed = Vector3.zero;   //キャラクタの座標を格納する変数
        playerRote = Vector3.zero; //キャラクタの向きを格納する変数

        if (Input.GetKey(KeyCode.W))
        {
            isEmoteStun = false; //動いたらアニメーションのフラグをオフ
            playerRote.y = 0;   //前を向く(角度軸y=0
            MoveSet();
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRote.y = 180; //後ろ向く
            MoveSet();
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRote.y = 90;
            MoveSet();
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRote.y = -90;
            MoveSet();
        }

        transform.Translate(speed);


    }

    void MoveSet()
    {
        speed.z = PlayerSpeed;  //transform(0, 0, PlayerSpeed)
                                //プレイやの向いてる方向= カメラの向いてる方向　＋　プレイやの向き
        transform.eulerAngles = Camera.transform.eulerAngles + playerRote;
    }

    void emote()
    {

        if (Input.GetKeyDown(KeyCode.E)) //Eキーを押したら
        {
            isEmoteStun = true; //アニメーションのフラグをオン
        }

        PlayerAnimator.SetBool("emoteStun", isEmoteStun); //アニメータのパラメータに反映
    }

    void Rotation()
    {
        var rspeed = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            rspeed.y = -RotationSpeed;  //transform(0, 0, PlayerSpeed)

        if (Input.GetKey(KeyCode.RightArrow))
            rspeed.y = RotationSpeed;

        Camera.transform.eulerAngles += rspeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enegy")
        {
            GameManager.instance.AddScore(); //攻撃回数加算
            
            var effect = Instantiate(Effect); //effect変数(エフェクトが発生する座標の入れ物)
            effect.transform.position = other.transform.position;//other(敵)の座標をエフェクトの座標に渡す
            Destroy(effect, 5);

            audioSource.PlayOneShot(GetSE);//音の発信源で一回鳴らす
            Destroy(other.gameObject);
        }

        if (other.tag == "DIP")
        {
            GameManager.instance.ReduceScore(); //攻撃回数加算
            //Debug.Log("衝突を検知");
            var effect = Instantiate(Effect); //effect変数(エフェクトが発生する座標の入れ物)
            effect.transform.position = other.transform.position;//other(敵)の座標をエフェクトの座標に渡す
            Destroy(effect, 5);

            audioSource.PlayOneShot(FailSE);//音の発信源で一回鳴らす
            Destroy(other.gameObject);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed = 0.05f;
    public float RotationSpeed = 0.5f;
    public GameObject Effect;
    public AudioSource audioSource;// 音の発信源
    public AudioClip GetSE; //音源
    public AudioClip FailSE;

    //speed変数に三次元x,y,zの値の入れ物を用意
    Vector3 speed = Vector3.zero;   //キャラクタの座標を格納する変数
    Vector3 playerRote = Vector3.zero; //キャラクタの向きを格納する変数

    public Animator PlayerAnimator;
    bool isEmoteStun; //アニメーションのフラグ

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        Move();
        Rotation();
        Camera.transform.position = transform.position;
        emote();
    }

    void Move()
    {
        speed = Vector3.zero;   //キャラクタの座標を格納する変数
        playerRote = Vector3.zero; //キャラクタの向きを格納する変数

        if (Input.GetKey(KeyCode.W))
        {
            isEmoteStun = false; //動いたらアニメーションのフラグをオフ
            playerRote.y = 0;   //前を向く(角度軸y=0
            MoveSet();
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRote.y = 180; //後ろ向く
            MoveSet();
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRote.y = 90;
            MoveSet();
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRote.y = -90;
            MoveSet();
        }

        transform.Translate(speed);


    }

    void MoveSet()
    {
        speed.z = PlayerSpeed;  //transform(0, 0, PlayerSpeed)
                                //プレイやの向いてる方向= カメラの向いてる方向　＋　プレイやの向き
        transform.eulerAngles = Camera.transform.eulerAngles + playerRote;
    }

    void emote()
    {

        if (Input.GetKeyDown(KeyCode.E)) //Eキーを押したら
        {
            isEmoteStun = true; //アニメーションのフラグをオン
        }

        PlayerAnimator.SetBool("emoteStun", isEmoteStun); //アニメータのパラメータに反映
    }

    void Rotation()
    {
        var rspeed = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            rspeed.y = -RotationSpeed;  //transform(0, 0, PlayerSpeed)

        if (Input.GetKey(KeyCode.RightArrow))
            rspeed.y = RotationSpeed;

        Camera.transform.eulerAngles += rspeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enegy")
        {
            GameManager.instance.AddScore(); //攻撃回数加算
            
            var effect = Instantiate(Effect); //effect変数(エフェクトが発生する座標の入れ物)
            effect.transform.position = other.transform.position;//other(敵)の座標をエフェクトの座標に渡す
            Destroy(effect, 5);

            audioSource.PlayOneShot(GetSE);//音の発信源で一回鳴らす
            Destroy(other.gameObject);
        }

        if (other.tag == "DIP")
        {
            GameManager.instance.ReduceScore(); //攻撃回数加算
            //Debug.Log("衝突を検知");
            var effect = Instantiate(Effect); //effect変数(エフェクトが発生する座標の入れ物)
            effect.transform.position = other.transform.position;//other(敵)の座標をエフェクトの座標に渡す
            Destroy(effect, 5);

            audioSource.PlayOneShot(FailSE);//音の発信源で一回鳴らす
            Destroy(other.gameObject);
        }
    }
}
>>>>>>> 2650526daaf1c78647f74a33a7ab50ec622371f3
