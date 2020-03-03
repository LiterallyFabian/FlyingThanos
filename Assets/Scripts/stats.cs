using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public Text items;
    public Text other;
    public Text cosmetics;
    public float accuracy;
    public float saccuracy;
    public double uptime;
    public double idletime;

    // Start is called before the first frame update
    void Start()
    {
        accuracy = PlayerPrefs.GetInt("collects", 0) * 100 / PlayerPrefs.GetInt("spawns", 1);
        saccuracy = (100 - (PlayerPrefs.GetInt("shurikens", 0) * 100 / PlayerPrefs.GetInt("shurikenspawns", 1)));
        uptime = (PlayerPrefs.GetInt("ups", 1)*100 / (PlayerPrefs.GetInt("ups", 1) + PlayerPrefs.GetInt("downs",0)));
        items.text =
			$"Burgers collected: {ez("burgers")}" +
			$"\nSlurps collected: {ez("slurps")}" +
			$"\nV-bucks collected: {ez("vbucks")}" +
			$"\nShurikens hit: {ez("shurikens")}" +
            $"\nShuriken avoid-rate: {saccuracy}%" +
            $"\nPowers collected: {ez("powercollects")}" +
            $"\nSlows activated: {ez("slows")}" +
            $"\nTimers activated: {ez("timers")}" +
            $"\nShields activated: {ez("shields")}" +
            $"\nTimes repaired: {ez("repairs")}" +
            $"\nDoubles activated: {ez("doubles")}" +
            $"\nTimes infected: {ez("viruses")}" +
            $"\nTotal items spawned: {ez("spawns")}" +
            $"\nTotal items collected: {ez("collects")} ({accuracy}%)" +
			$"\nTotal score: {ez("totalscore")}p" +
			$"\nTime collected: {d("refueltime")}s";

        other.text =
            $"Games played: {ez("games")}" +
            $"\nClassics played: {ez("classic")}" +
            $"\nDuels played: {ez("pvp")}" +
            $"\nSharp shurikens played: {ez("sharp")}" +
            $"\nFlying fasts played: {ez("flyingfast")}" +
            $"\nRefuels played: {ez("refuel")}" +
            $"\nSwarms played: {ez("swarm")}" +
            $"\nTimes paused: {ez("pauses")}" +
            $"\nTime spent flying up: {uptime}%" +
            $"\nTime spent flying down: {100-uptime}%" +
            $"\nHighest score: {ez("highscore")}p" +
            $"\nClassic hiscore: {ez("classicscore")}p ({d("ccplaytime")}s)" +
            $"\nSharp shurikens hiscore: {ez("sharpscore")}p ({d("ssplaytime")}s)" +
            $"\nFlying fast hiscore: {ez("fastscore")}p ({d("ffplaytime")}s)" +
            $"\nRefuel hiscore: {ez("refuelscore")}p ({d("rfplaytime")}s)" +
            $"\nSwarm hiscore: {ez("swarmscore")}p ({d("swplaytime")}s)";

        cosmetics.text =
            $"Games with Thanos: {ez("thanos0")}" +
            $"\nGames with Camo: {ez("thanos1")}" +
            $"\nGames with Fox News: {ez("thanos3")}" +
            $"\nGames with LMAO: {ez("thanos2")}" +
            $"\nGames with Santa: {ez("snowmap")}" +
            $"\nMountain games: {ez("grassmap")}" +
            $"\nBeach games: {ez("beachmap")}" +
            $"\nSnow games: {ez("snowmap")}" +
            $"\nSpooky games: {ez("spookymap")}";            

    }

    // Update is called once per frame
    void Update()
    {

    }

    static string ez(string type)
    {
        return Convert.ToString(PlayerPrefs.GetInt(type, 0));
    }
    static string d(string type)
    {
        return Convert.ToString(Mathf.Round(PlayerPrefs.GetFloat(type, 0)));
    }
}
