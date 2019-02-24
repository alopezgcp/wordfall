using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticsMgr {
    private static int score;
    private static int wordcount;

    public static int GetScore() { return score; }
    public static void SetScore(int s) { score = s; }
    public static void UpdateScore(int k) { score += k; }

    public static int GetWordCount(){ return wordcount; }
    public static void SetWordCount(int w) { wordcount = w; }  
    public static void UpdateWordCount(int k) { wordcount += k; }
}
