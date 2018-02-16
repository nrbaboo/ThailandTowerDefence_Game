using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class TurretManager : MonoBehaviour
{
    private TileManager tileManager;
    [SerializeField]
    private float waitSpawnTime, minIntervalTime, maxIntervalTime;

    private List<Turret> turrets = new List<Turret>();

    [SerializeField]
    public Text DebugText;
    //Firebase
    private DatabaseReference reference;
    private string[] turretTypes = { "TURRET1", "TURRET2", "TURRET3" };

    //Firebase
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    void Start()
    {
        // ใช้สำหรับอ้างอิง Firebase Project
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://thailand-tower-defence.firebaseio.com/");

        // สำหรับใช้ในการอ้างอิง Firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
        RaadAllData();
        //SetupTurret();
    }

    void Update()
    {
        /*if (waitSpawnTime < Time.time && turrets.Count<=3)
        {
            waitSpawnTime = Time.time + UnityEngine.Random.Range(minIntervalTime, maxIntervalTime);
            SpawnTurret();
        }*/

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.tag == "Turret")
                {
                    Turret turret = hit.transform.GetComponent<Turret>();
                    KeepTurret(turret.turretType);
                }
            }
        }
    }

    void KeepTurret(TurretType type)
    {
        string t = type.ToString();
        PlayerPrefs.SetString("TURRET_KEY", t);
        SceneManager.LoadScene("ar");
    }

    void SpawnTurret()
    {
        TurretType type = (TurretType)(int)UnityEngine.Random.Range(0, Enum.GetValues(typeof(TurretType)).Length);
        float newLat = tileManager.getLat + UnityEngine.Random.Range(-0.0001f, 0.0001f);
        float newLon = tileManager.getLon + UnityEngine.Random.Range(-0.0001f, 0.0001f);

        Turret prefab = Resources.Load("MapTurret/" + type.ToString(), typeof(Turret)) as Turret;
        Turret turret = Instantiate(prefab, Vector3.zero, Quaternion.identity) as Turret;
        turret.tileManager = tileManager;
        turret.Init(newLat, newLon);

        turrets.Add(turret);
    }

    /*void SpawnSpecificTurret(TurretType type, float newLat, float newLon)
    {
        Turret prefab = Resources.Load("MapTurret/" + type.ToString(), typeof(Turret)) as Turret;
        Turret turret = Instantiate(prefab, Vector3.zero, Quaternion.identity) as Turret;
        turret.tileManager = tileManager;
        turret.Init(newLat, newLon);
        turrets.Add(turret);
    }*/
    void SpawnSpecificTurret(String type, float newLat, float newLon)
    {
        Turret prefab = Resources.Load("MapTurret/" + type, typeof(Turret)) as Turret;
        Turret turret = Instantiate(prefab, Vector3.zero, Quaternion.identity) as Turret;
        turret.tileManager = tileManager;
        turret.Init(newLat, newLon);
        turrets.Add(turret);
    }

    /*void SetupTurret()
    {
        SpawnSpecificTurret(TurretType.TURRET1, (float)18.78872, (float)98.9992);
        SpawnSpecificTurret(TurretType.TURRET2, (float)18.78873, (float)98.9993);
        SpawnSpecificTurret(TurretType.TURRET1, (float)13.7291, (float)100.7753);
        SpawnSpecificTurret(TurretType.TURRET2, (float)13.73155, (float)100.7709);
    }*/

    public void UpdateTurretPosition()
    {
        if (turrets.Count == 0)
            return;

        Turret[] turret = turrets.ToArray();
        for (int i = 0; i < turret.Length; i++)
        {
            turret[i].UpdatePosition();
        }
    }

    //Firebase
    /*public void WriteTurretData()
    {
        // ทำการเขียนเขียนข้อมูลว่างๆ เพื่อนำ Key มาอ้างอิง และทำการ Update ข้อมูล
        string key = reference.Child("turret").Push().Key;
        Dictionary<string, UnityEngine.Object> childUpdates = new Dictionary<string, UnityEngine.Object>();
        // เขียนข้อมูลลง Model
        TurretData tData = new TurretData();
        tData.lat = UnityEngine.Random.Range(0f, 5f);
        tData.lon = UnityEngine.Random.Range(0f, 5f);
        int randomIndex = (int)(UnityEngine.Random.Range(0f, 1f) * (turretTypes.Length + 1));
        tData.turretType = turretTypes[randomIndex];
        string json = JsonUtility.ToJson(tData);
        // เขียนข้อมูลลง Firebase
        reference.Child("turret").Child(key).SetRawJsonValueAsync(json);
    }*/

    public void RaadAllData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("turret")
        // หากข้อมูลมีการเปลี่ยนแหลงให้ทำการอ่านและแสดง
        .ValueChanged += HandleValueChanged;
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // อ่าน Key เพื่อใช้แสดงผล
        List<string> keys = args.Snapshot.Children.Select(s => s.Key).ToList();
        foreach (var key in keys)
        {
            DisplayData(args.Snapshot, key);
        }
    }
    // ใช้สำหรับ แสดงข้อมูลที่โหลดครับ
    public void DisplayData(DataSnapshot snapshot, string key)
    {
        string j = snapshot.Child(key).GetRawJsonValue();
        TurretData u = JsonUtility.FromJson<TurretData>(j);
        Debug.Log(u.lat + " " + u.lon);
        DebugText.text = TurretType.TURRET1+" "+u.lat + " " + u.lon+" "+u.turretType;

        SpawnSpecificTurret(u.turretType, (float)u.lat, (float)u.lon);

    }
}

