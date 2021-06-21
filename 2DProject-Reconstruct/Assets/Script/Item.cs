using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName;
    public string ItemDescription;
    public int itemType; // 1 : Attack, 2 : Defend, 3 : Util
    public int itemGrade; // 0 : Noraml, 1 : Rare, 2 : Epic, 3 : Legendary

    public Skill itemSkill;

    private void Start() {
        itemSkill.onSkill = false;
        itemSkill.useSkillTime = Time.time - itemSkill.skillTime;    
    }

    private void Update() {
        if(Input.GetKeyDown(itemSkill.skillKeyCode) && itemSkill.checkSkillOnTime()){
            itemSkill.useSkill();
        }
    }
}
