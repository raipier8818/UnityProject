using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public string skillDescription;

    public float skillTime;
    public float useSkillTime;
    public bool onSkill;
    public int skillType; // 1 : Attack, 2 : Defend, 3 : Interaction, 4 : Buff, 5 : Debuff

    public KeyCode skillKeyCode;

    private void Start() {
        
    }

    private void Update() {
        
    }
    public void useSkill(){
        useSkillTime = Time.time;
        onSkill = true;
    }

    public bool checkSkillOnTime(){
        if(Time.time - useSkillTime < skillTime) return false;
        return true;
    }
}
