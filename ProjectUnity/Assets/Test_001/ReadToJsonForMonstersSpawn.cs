using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

[Serializable]
public class MonsterJson
{
    public MonsterJson(float _spawnTime, float _spawnPosX, float _moveSpeed)
    {
        spawnTime = _spawnTime;
        spawnPosX = _spawnPosX;
        moveSpeed = _moveSpeed;
    }

    public float SpawnTime
    {
        get { return spawnTime; }
        set { spawnTime = value; }
    }

    public float SpawnPosX
    {
        get { return spawnPosX; }
        set { spawnPosX = value; }
    }

    public float SpawnSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    //json object 이기때문에 public 선언
    public float spawnTime;
    public float spawnPosX;
    public float moveSpeed;
}


public class ReadToJsonForMonstersSpawn : MonoBehaviour
{
    //파일 경로
    private string strFilePath;
    public string strFileName = "/testText.txt";

    //json 출력용 문자열
    private string json = "";

    void Awake()
    {
        strFilePath = Application.dataPath; //aditor;project asset folder
    }

    // Start is called before the first frame update
    void Start()
    {
        MonsterJson monster = new MonsterJson(1f, 5f, 5f);
        print(monster.SpawnTime + ", " + monster.SpawnPosX + ", " + monster.SpawnSpeed);        
            
        json += JsonUtility.ToJson(monster) + "\n";
        json += JsonUtility.ToJson(monster) + "\n";
        print(json);



        //WriteFile(); //쓰기
        ReadFile(); //읽기
    }


    void WriteFile()
    {
        StreamWriter sw = new StreamWriter(strFilePath + strFileName, false, System.Text.Encoding.Default);
        //기본형 StreamWriter(파일경로);
        //사용오버로드 StreamWriter(파일경로, 덮어쓰기유무-false때 덮어씀, 인코딩방식)

        sw.WriteLine(json); //쓰기
        
        sw.Flush(); //버퍼를 스트림에 입력 후 버퍼 비움
        sw.Close();
    }



    void ReadFile()
    {
        string[] text = File.ReadAllLines(strFilePath + strFileName, System.Text.Encoding.Default);
        //파일열고 읽어 저장, 라인별로 배열에 저장됨
       

        MonsterJson[] monsters = new MonsterJson[text.Length];

        for (int i = 0; i < text.Length; ++i) {
            monsters[i] = JsonUtility.FromJson<MonsterJson>(text[i]);

            print(monsters[i].SpawnTime + ", " + monsters[i].SpawnPosX + ", " + monsters[i].SpawnSpeed);
        }

        /* 아래 방법은 왜 그런지 텍스트로 읽히지 않음
        StringReader sr = new StringReader(strFilePath + strFileName);
        string input = "";

        while (input != null)
        {
            input = sr.ReadLine();
            Debug.Log("1 " + input + "\n"); //Log [ 1 "파일경로" ] 라고 출력됨
            //Debug.Log("1 " + System.Text.Encoding.UTF8.GetBytes(input));
        }
        sr.Close();
        */
    }
}
