using UnityEngine;
using System.Collections;

        //available special powers for power-ups
enum ESpecialPower
{
    SP_ExtraPoints,
	SP_ExtraGravityChanger,
	SP_SpecialPowersAmount		//Only to know how many special powers do we have. Do not delete!
};

        //takes care of PowerUps behaviour and special powers
public class PowerUp : MonoBehaviour {

    public Texture m_extraGravityTexture;
    public Texture m_extraPointsTexture;

    public AudioClip m_extraGravitySound;
    public AudioClip m_extraPointsSound;

    private AudioClip m_sound;
    private ESpecialPower eSpecialPower;
            
            //initializes power-up special power
    void Start()
    {
        eSpecialPower = RandomSpecialPower();
    }
            //rotates power-ups
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 45f) * Time.deltaTime);
    }
            //launches power-up ability, plays it's sound and destroys it
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LaunchSpecialPower(other.gameObject.GetComponent<BallMovement>());

            SoundManager.instance.PlaySound(m_sound);

            Destroy(gameObject);
        }
    }
            //implepents power-ups' special ability
    private void LaunchSpecialPower(BallMovement ball)
    {
        switch (eSpecialPower)
        {
            case ESpecialPower.SP_ExtraPoints:
                ball.AddPoints(100);
                break;

            case ESpecialPower.SP_ExtraGravityChanger:
                ball.AddGravityChangers(1);
                break;

            default:
                break;
        }
    }
            //randomize power-ups' special ability
    private ESpecialPower RandomSpecialPower()
    {
        ESpecialPower power = (ESpecialPower)(Random.Range(0, (int)(ESpecialPower.SP_SpecialPowersAmount)));
        Renderer rend = GetComponent<MeshRenderer>();

        switch (power)
        {
            case ESpecialPower.SP_ExtraPoints:
                rend.material.mainTexture = m_extraPointsTexture;
                m_sound = m_extraPointsSound;
                break;

            case ESpecialPower.SP_ExtraGravityChanger:
                rend.material.mainTexture = m_extraGravityTexture;
                m_sound = m_extraGravitySound;
                break;

            default:
                rend.material.mainTexture = m_extraPointsTexture;
                m_sound = m_extraPointsSound;
                Debug.Log("Wrong special powers amount for power ups!");
                break;
        }

        return power;
    }            
}
