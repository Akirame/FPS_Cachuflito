using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text healthText;
    public Text scoreText;
    public Text weaponText;
    public Text bulletText;
    public Canvas mainScreenCanvas;
    public Canvas finalScreenCanvas;
    public Text scoreTextFinal;
    public Text enemyTrapTextFinal;
    public Text enemyGhostTextFinal;
    public Text bulletCountTextFinal;
    public Player _player;
    public Instance _instantiator;
    public Camera mainCamera;
    public Camera cameraFinal;
    public GameObject ghostDetect;
    public Slider sliderBattery;

    private bool detectOn;
    private float detectBattery;
    private bool detectShutdown;
    private static Game instance;
    private int _Score;
    private int _Health;
    private string weaponName;    
    private int bulletCount;
    private int trapCount;
    private int ghostCount;
    private int bulletCounterFinal;

    public static Game Get()
    {
        return instance;
    }
    private void Start()
    {        
        _Score = 0;
        _Health = 100;
        weaponName = "TRAPPERZAPPER";        
        bulletCount = 1;
        trapCount = 0;
        ghostCount = 0;
        bulletCounterFinal = 0;
        detectOn = false;
        detectShutdown = false;
        ghostDetect.gameObject.SetActive(false);
        mainScreenCanvas.gameObject.SetActive(true);
        finalScreenCanvas.gameObject.SetActive(false);
        mainCamera.cullingMask = ((1 << 0) | (1 << 8) | (1 << 9) | (1 << 11) | (1 << 12));
        cameraFinal.gameObject.SetActive(false);
        detectBattery = 10f;
}

private void Update()
    {
            if (_Health <= 0)
            {            
            _instantiator.gameObject.SetActive(false);          
            mainScreenCanvas.gameObject.SetActive(false);
            finalScreenCanvas.gameObject.SetActive(true);
            _player.gameObject.SetActive(false);
            cameraFinal.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            DrawTextsFinal();
            }
        setCullingMask();
        DrawTexts();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    public void AddScore(int score)
    {
        _Score += score;
    }
    public void SetHealth(int health)
    {
        _Health -= health;
    }
    public void DrawTexts()
    {
        if(healthText!=null)
        healthText.text = "HEALTH:" + (_Health).ToString();
        if(scoreText!=null)
        scoreText.text = "POINTS:" + (_Score).ToString();
        if(weaponText!=null)
        weaponText.text = weaponName;
        if (bulletText != null)
        {
            if(Weapons.Get().GetBulletMagazine())
            {
            bulletText.text = "CLIP:" + (Weapons.Get().GetBulletTrap()).ToString() + "/1";
            }
            else
                bulletText.text = "CLIP:" + (Weapons.Get().GetFlowerWeapon()).ToString() + "/6";
        }
    }
    public void DrawTextsFinal()
    {     
        scoreTextFinal.text = "SCORE:" + _Score.ToString();
        enemyTrapTextFinal.text = "TRAPS DESTROYED:" + trapCount.ToString();
        enemyGhostTextFinal.text = "GHOSTS DESTROYED:" + ghostCount.ToString();
        bulletCountTextFinal.text = "BULLETS FIRED:" + bulletCounterFinal.ToString();
    }
    public void SetWeaponText(string text)
    {
        weaponName = text;
    }

    public void TrapDestroyed()
    {
        trapCount++;
    }
    public void GhostDestroyed()
    {
        ghostCount++;
    }
    public void BulletShooted()
    {
        bulletCounterFinal++;
    }
    public void DestroyGame()
    {
        Destroy(this.gameObject);
    }
    private void setCullingMask()
    {
        if (Input.GetKeyDown(KeyCode.F) && (!detectOn) && !detectShutdown)
        {
            ghostDetect.gameObject.SetActive(true);
            mainCamera.cullingMask = ((1 << 0) | (1 << 8) | (1 << 9) | (1 << 10) | (1 << 11) | (1 << 12));
            detectOn = true;
        }
        else if ((Input.GetKeyDown(KeyCode.F) && (detectOn)) || detectShutdown)
        {
            ghostDetect.gameObject.SetActive(false);
            mainCamera.cullingMask = ((1 << 0) | (1 << 8) | (1 << 9) | (1 << 11) | (1 << 12));
            detectOn = false;
        }
        detectorBatteryOn();
    }
    private void detectorBatteryOn()
    {
        if (detectOn)
        {
            detectBattery -= Time.deltaTime;
        }
        else if(!detectOn || detectShutdown)
        {
            detectBattery += Time.deltaTime;
        }
        if ((detectBattery <= 0 && detectOn) || detectShutdown)
        {                
                detectShutdown = true;
            if (detectBattery >= 10f)
                detectShutdown = false;
        }
        else if (detectBattery > 10f && !detectOn)
        {
            detectBattery = 10f;
        }
        SliderBatteryValue();
    }
    private void SliderBatteryValue()
    {
        sliderBattery.value = detectBattery;
    }
}

