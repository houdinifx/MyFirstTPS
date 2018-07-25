using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCure : MonoBehaviour {

    public int Hp = 100;
    public int Energy;
    float _energyTimer = 0;
    float _energyHpTimer=0;
	// Use this for initialization
	void Start () {
        if (Hp>100) {
            Hp = 100;
        }

	}
	
	// Update is called once per frame
	void Update () {
		if (Hp > 100)
		{
			Hp = 100;
		}
		if (Energy > 100)
		{
			Energy = 100;
		}
		KeyUpdate ();
        EnergyUpdate();
    }
    void EnergyUpdate()
    {
        if (Energy > 0)
        {
            _energyTimer += Time.deltaTime;
            if (_energyTimer >= 3)
            {
                Energy -= 1;
                _energyTimer = 0;

            }
            if (Hp < 100)
            {
                _energyHpTimer += Time.deltaTime;
                if (_energyHpTimer >= 8)
                {
                    if (Energy <= 20)
                    {
                        Hp += 1;
                    }
                    else if (Energy <= 60)
                    {
                        Hp += 2;
                    }
                    else if (Energy <= 90)
                    {
                        Hp += 3;
                    }
                    else if (Energy < 100)
                    {
                        Hp += 4;
                    }

                    

                    Debug.Log("血量" + Hp);
                    _energyHpTimer = 0;
                }
            }

        }
    }

	void KeyUpdate(){
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
		useBandage();
        }

		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			useFirstAidKit();
		}

		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			useMedicalBox();
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)) {
			useRedBull();
		}
		if(Input.GetKeyDown(KeyCode.Alpha0)) {
			damage();
		}


    }
	void useBandage()
{
	if(Hp>=75){
		Debug.Log("血大于75,绷带不好使");
		return;

	}
	Hp+=10;

		Debug.Log("使用绷带"+Hp);
}
	void useFirstAidKit()
{
	if(Hp>=75){
		Debug.Log("血大于75,急救箱不好使");
		return;

	}
	Hp+=75;

		Debug.Log("使用急救箱"+Hp);
}
	void useMedicalBox()
{
	if(Hp>=100){
		Debug.Log("血大于100,医疗箱不好使");
		return;

	}
	Hp+=100;

		Debug.Log("使用医疗箱"+Hp);
}
	void useRedBull()
{
	if (Energy < 100){
		Debug.Log("困了累了喝**");
		Energy+=40;
		

	}



	}

	void damage()
	{
		if (Hp <= 1) {
			Debug.Log ("神之闪躲");
		
		
		} else {
			Hp -= Random.Range(1,Hp);	
			Debug.Log ("受伤"+Hp);
		}



	}



}