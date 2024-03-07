using System;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private Renderer rend;
    private Color flashColor;
    private float amount;
    private float timeUp;
    private float stayTime;
    private float timeDown;
    private int flashingState;
    private float flashTimer;
    private float amountCurrent;
    private float t;
    private bool repeatFlash;
    private bool cancelFlash;
    private float geoTimer;
    private bool geoFlash;
    private MaterialPropertyBlock block;
    private bool sendToChildren = true;

    private void Start()
    {
        if(rend == null)
        {
            rend = GetComponent<Renderer>();
        }
        if(block == null)
        {
            block = new MaterialPropertyBlock();
        }
    }

    private void OnDisable()
    {
        if (rend == null)
        {
            rend = GetComponent<Renderer>();
        }
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        block.SetFloat("_FlashAmount", 0f);
        rend.SetPropertyBlock(block);
        flashTimer = 0f;
        flashingState = 0;
        repeatFlash = false;
        cancelFlash = false;
        geoFlash = false;
    }

    private void Update()
    {
        if (cancelFlash)
        {
            block.SetFloat("_FlashAmount", 0f);
            rend.SetPropertyBlock(block);
            flashingState = 0;
            cancelFlash = false;
        }
        if(flashingState == 1)
        {
            if(flashTimer < timeUp)
            {
                flashTimer += Time.deltaTime;
                t = flashTimer / timeUp;
                amountCurrent = Mathf.Lerp(0f, amount, t);
                block.SetFloat("_FlashAmount", amountCurrent);
                rend.SetPropertyBlock(block);
            }
            else
            {
                block.SetFloat("_FlashAmount", amount);
                rend.SetPropertyBlock(block);
                flashTimer = 0f;
                flashingState = 2;
            }
        }
        if(flashingState == 2)
        {
            if(flashTimer < stayTime)
            {
                flashTimer += Time.deltaTime;
            }
            else
            {
                flashTimer = 0f;
                flashingState = 3;
            }
        }
        if(flashingState == 3)
        {
            if (flashTimer < timeDown)
            {
                flashTimer += Time.deltaTime;
                t = flashTimer / timeDown;
                amountCurrent = Mathf.Lerp(amount, 0f, t);
                block.SetFloat("_FlashAmount", amountCurrent);
                rend.SetPropertyBlock(block);
            }
            else
            {
                block.SetFloat("_FlashAmount", 0f);
                rend.SetPropertyBlock(block);
                flashTimer = 0f;
                if (repeatFlash)
                {
                    flashingState = 1;
                }
                else
                {
                    flashingState = 0;
                }
            }
        }
        if (geoFlash)
        {
            if(geoTimer > 0f)
            {
                geoTimer -= Time.deltaTime;
                return;
            }
            FlashingSuperDash();
            geoFlash = false;
        }
    }

    public void GeoFlash()
    {
        geoFlash = true;
        geoTimer = 0.25f;
    }

    public void flash(Color flashColour_var,float amount_var,float timeUp_var,float stayTime_var,float timeDown_var)
    {
        flashColor = flashColour_var;
        amount = amount_var;
        timeUp = timeUp_var;
        stayTime = stayTime_var;
        timeDown = timeDown_var;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
    }

    public void CancelFlash()
    {
        cancelFlash = true;
    }

    public void flashInfected()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        flashColor = new Color(1f, 0.31f, 0f);
        amount = 0.9f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.25f;
        block.Clear();
        block.SetColor("_FlashAmount", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashInfected));
    }

    public void flashSporeQuick()
    {
        if(block == null)
        {
            block = new MaterialPropertyBlock();
        }
        flashColor = new Color(0.95f, 0.9f, 0.15f);
        amount = 0.75f;
        timeUp = 0.001f;
        stayTime = 0.05f;
        timeDown = 0.1f;
        block.Clear();
        block.SetColor("_FlashAmount", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashSporeQuick));
    }

    public void flashWhiteQuick()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        flashColor = new Color(1f, 1f, 1f);
        amount = 1f;
        timeUp = 0.001f;
        stayTime = 0.05f;
        timeDown = 0.001f;
        block.Clear();
        block.SetColor("_FlashAmount", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashWhiteQuick));
    }

    public void flashDung()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        flashColor = new Color(0.45f, 0.27f, 0f);
        amount = 0.9f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.25f;
        block.Clear();
        block.SetColor("_FlashAmount", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashDung));
    }

    public void flashDungQuick()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        flashColor = new Color(0.45f, 0.27f, 0f);
        amount = 0.75f;
        timeUp = 0.001f;
        stayTime = 0.05f;
        timeDown = 0.1f;
        block.Clear();
        block.SetColor("_FlashAmount", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashDungQuick));
    }

    public void flashInfectedLong()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        flashColor = new Color(1f, 0.31f, 0f);
        amount = 0.9f;
        timeUp = 0.01f;
        stayTime = 0.25f;
        timeDown = 0.35f;
        block.Clear();
        block.SetColor("_FlashAmount", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashInfectedLong));
    }

    public void flashArmoured()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.9f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.25f;
        if (block != null)
        {
            block.Clear();
            block.SetColor("_FlashColor", flashColor);
        }
        flashingState = 1;
        flashTimer = 0f; 
        repeatFlash = false;
        SendToChildren(new Action(flashArmoured));
    }

    public void flashBenceRest()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.7f;
        timeUp = 0.01f;
        stayTime = 0.1f;
        timeDown = 0.75f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashBenceRest));
    }

    public void flashDreamImpact()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.9f;
        timeUp = 0.01f;
        stayTime = 0.25f;
        timeDown = 0.75f;
        if (block != null)
        {
            block.Clear();
            block.SetColor("_FlashColor", flashColor);
        }
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashDreamImpact));
    }

    public void flashMothDepart()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.7f;
        timeUp = 1.9f;
        stayTime = 1f;
        timeDown = 0.25f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashMothDepart));
    }

    public void flashSoulGet()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.5f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.25f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashSoulGet));
    }

    public void flashWhiteLong()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 1f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 2f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashWhiteLong));
    }
    
    public void flashOvercharmed()
    {
        flashColor = new Color(0.72f, 0.376f, 0.72f);
        amount = 0.75f;
        timeUp = 0.2f;
        stayTime = 0.01f;
        timeDown = 0.5f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashOvercharmed));
    }

    public void flashFocusHeal()
    {
        Start();
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.85f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.35f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashFocusHeal));
    }

    public void flashFocusGet()
    {
        Start();
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.5f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.35f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashFocusGet));
    }

    public void flashWhitePulse()
    {
        Start();
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.35f;
        timeUp = 0.5f;
        stayTime = 0.01f;
        timeDown = 0.75f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashWhitePulse));
    }

    public void flashHealthBlue()
    {
        flashColor = new Color(0f, 0.584f, 1f);
        amount = 0.75f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.5f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(flashHealthBlue));
    }

    public void flashInfectedLoop()
    {
        flashColor = new Color(1f, 0.31f, 0f);
        amount = 0.9f;
        timeUp = 0.2f;
        stayTime = 0.01f;
        timeDown = 0.2f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = true;
        SendToChildren(new Action(flashInfectedLoop));
    }

    public void FlashingSuperDash()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.7f;
        timeUp = 0.1f;
        stayTime = 0.01f;
        timeDown = 0.1f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = true;
        SendToChildren(new Action(FlashingSuperDash));
    }

    public void FlashingGhostWounded()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.7f;
        timeUp = 0.5f;
        stayTime = 0.01f;
        timeDown = 0.5f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = true;
        SendToChildren(new Action(FlashingGhostWounded));
    }

    public void FlashingWhiteStay()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.6f;
        timeUp = 0.01f;
        stayTime = 999f;
        timeDown = 0.01f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = true;
        SendToChildren(new Action(FlashingWhiteStay));
    }

    public void FlashingWhiteStayMoth()
    {
        flashColor = new Color(1f, 1f, 1f);
        amount = 0.6f;
        timeUp = 2f;
        stayTime = 9999f;
        timeDown = 2f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = true;
        SendToChildren(new Action(FlashingWhiteStayMoth));
    }

    public void FlashingFury()
    {
        Start();
        flashColor = new Color(0.71f, 0.18f, 0.18f);
        amount = 0.75f;
        timeUp = 0.25f;
        stayTime = 0.01f;
        timeDown = 0.25f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = true;
        SendToChildren(new Action(FlashingFury));
    }

    public void FlashingOrange()
    {
        flashColor = new Color(1f, 0.31f, 0f);
        amount = 0.7f;
        timeUp = 0.1f;
        stayTime = 0.01f;
        timeDown = 0.1f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = true;
        SendToChildren(new Action(FlashingOrange));
    }

    public void FlashShadowRecharge()
    {
        Start();
        flashColor = new Color(0f, 0f, 0f);
        amount = 0.75f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.35f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(FlashShadowRecharge));
    }

    public void FlashGrimmflame()
    {
        Start();
        flashColor = new Color(1f, 0.25f, 0.25f);
        amount = 0.75f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 1f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(FlashGrimmflame));
    }
    public void FlashGrimmHit()
    {
        Start();
        flashColor = new Color(1f, 0.25f, 0.25f);
        amount = 0.75f;
        timeUp = 0.01f;
        stayTime = 0.01f;
        timeDown = 0.25f;
        block.Clear();
        block.SetColor("_FlashColor", flashColor);
        flashingState = 1;
        flashTimer = 0f;
        repeatFlash = false;
        SendToChildren(new Action(FlashGrimmHit));
    }


    private void SendToChildren(Action function)
    {
        if (!sendToChildren)
        {
            return;
        }
        foreach (SpriteFlash spriteFlash in base.GetComponents<SpriteFlash>())
        {
            if(!(spriteFlash == this))
            {
                spriteFlash.sendToChildren = false;
                spriteFlash.GetType().GetMethod(function.Method.Name).Invoke(spriteFlash, null);
            }
        }
    }

}
