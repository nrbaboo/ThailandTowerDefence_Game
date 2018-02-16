using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SaveFile : MonoBehaviour
{
    public static SaveFile current;
    public PlayerInfo playerInfo;
    public bool AutoSave = true;
    private string file = "/savedata.json";
    public Text DebugText;
    private float timer = 0f;
    private float interval = 30f; //in seconds

    void Start()
    {
        current = this;
        file = Application.persistentDataPath + file;
        //make dummy player name
        playerInfo = new PlayerInfo("Ashe");
        ReadFromJson();
        Log(WaveSpawner.EnemiesAlive.ToString());
    }
    
    void Update()
    {

        //auto save in time interval
        if (AutoSave)
        {
            if (timer < Time.time)
            {
                timer = Time.time + interval;
                SaveToJson();
            }
        }
    }

    //save player's new turret
    public void addNewTurret() {

        //find GameObj that have TurretSpawner script
        Log("gointo addNewTurret");
        GameObject g = GameObject.Find("ZoomObj");
        Log("Find TurretSp"+g);
        TurretSpawner tScript = g.GetComponent<TurretSpawner>();
        Log("turret:"+ tScript.getTurret().GetComponent<Turret>().turretType);

        //add new turret in to List
        playerInfo.AddTurret(tScript.getTurret().GetComponent<Turret>().turretType, 1);
        Log("before save in json");

        //save to json file
        SaveToJson();
        Log("eiei");
    }

    public void SaveToJson()
    {
        //Log("in save to json fn 1");
        playerInfo.Prepare();
        string json = JsonUtility.ToJson(playerInfo);
        //Log("in save to json fn 2");
        try
        {
            File.WriteAllText(file, json);
            Log(file + " has been saved!");
        }
        catch (System.Exception e)
        {
            Log(e.ToString());
        }
    }

    public void ReadFromJson()
    {
        string f = File.ReadAllText(file);
        f.Trim();

        playerInfo = JsonUtility.FromJson<PlayerInfo>(f);
        playerInfo.Unzip();

        //display json 
        //Log(file + " has been loaded!");
        //Log("Contents: \n" + JsonUtility.ToJson(playerInfo));

        //display turret log on screen 
        //Log("TurretList:");
        List<TurretInfo> turrets = playerInfo.getList();
        for (int i = 0; i < turrets.Count; i++)
        {
            if((turrets[i].type).ToString()!= null)
            {
                // Log((turrets[i].type).ToString());
                //Log(i.ToString());
                if (i == 0) Shop.haveExtraTurret1 = true;
                if (i == 1) Shop.haveExtraTurret2 = true;
                if (i == 2) Shop.haveExtraTurret3 = true;
                if (i == 3) Shop.haveExtraTurret4 = true;
                if (i == 4) Shop.haveExtraTurret5 = true;
                if (i == 5) Shop.haveExtraTurret6 = true;
            }
           
        }

    }

    string GetJsonFileLocation()
    {
        return file;
    }

    void Log(string t)
    {
        DebugText.text += "\n" + t;
    }
}

public class PlayerInfo
{
    private List<TurretInfo> turrets;
    public string name;
    //public int level;
    //public float experience;
    //public float expNeeded;
    public string pstring;

    public PlayerInfo(string name, int level = 1, float experience = 0f)
    {
        this.name = name;
        //this.level = level;
        //this.experience = experience;
        //this.expNeeded = (this.level + 1) * 50f;
        this.turrets = new List<TurretInfo>();
    }

    public void Prepare()
    {
        pstring = "";
        TurretInfo[] p = this.turrets.ToArray();

        for (int i = 0; i < p.Length; i++)
        {
            pstring += "/" + JsonUtility.ToJson(p[i]);
        }
    }

    public void Unzip()
    {
        string[] s = pstring.Split('/');
        this.turrets = new List<TurretInfo>();

        for (int i = 1; i < s.Length; i++)
        {
            TurretInfo p = JsonUtility.FromJson<TurretInfo>(s[i]);
            this.turrets.Add(p);
        }

    }

    public void AddTurret(TurretType type, int level, float experience = 0f, int cookies = 3)
    {
        TurretInfo p = new TurretInfo(type, level, cookies, experience);
        TurretInfo r = this.GetTurretByType(type);
        if (r == null)
        {
            this.turrets.Add(p);
        }
        /*else
        {
             r.AddCookies(cookies + 1);
             if (r.level < level)
             {
                 r.level = level;
             }
            
        }*/

        this.Prepare();
    }

    public TurretInfo GetTurretByType(TurretType type)
    {
        TurretInfo[] p = this.turrets.ToArray();

        for (int i = 0; i < p.Length; i++)
        {
            if (p[i].type == type)
            {
                return p[i];
            }
        }

        return null;
    }

    public List<TurretInfo> getList (){
        return turrets;
    }
}

public class TurretInfo
{
    public TurretType type;
    //public int level;
    //public int cookies;
    //public float experience;
    //public float expNeeded;

    public TurretInfo(TurretType type, int level, int cookies = 3, float experience = 0f)
    {
        this.type = type;
        //this.level = level;
        //this.cookies = cookies;
        //this.experience = experience;
        //this.expNeeded = (this.level + 1) * 50f;
    }

    public void AddExperience(float exp)
    {
        /*experience += exp;
        if (experience > expNeeded)
        {
            float rest = experience - expNeeded;
            experience = rest;
            level++;
        }*/
    }

    public void AddCookies(int cookies)
    {
        //this.cookies += cookies;
    }
}
