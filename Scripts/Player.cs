using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public GameObject _pauseMenuPanel;
    public GameObject coinPrefab;
    public AudioClip coinSoundEffect;
    private NavMeshAgent _agent; // ---> NavMashAgent'a ulaşmak için atadığımız değişken.
    private Animator _anim; // ---> Animator'a ulaşmak için atadığımız değişken.
    private Vector3 _target; // ---> Vector3 ile _target'ın Vector'üne ulaşıyoruz.
    private bool _coinCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
        _agent = GetComponent<NavMeshAgent>(); // ---> NavMashAgent'ın Componentlerine ulaşıyoruz.
        _anim = GetComponentInChildren<Animator>(); // ---> Animator'un Children Componentlerine ulaşıyoruz.

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // ---> Mouse'a sol tıkladığımızda olacak şey.
        {

            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition); // ---> MainCamera'nın içerisinden mouse'un pozisyonuna ulaşıyoruz.
            RaycastHit hitInfo; // ---> Kordinatları kaydettiğimiz yer.

            if (Physics.Raycast(rayOrigin, out hitInfo)) // ---> Mouse ile nereye tıkladığımızın kordinatları.
            {
                
                _agent.SetDestination(hitInfo.point); // ---> Mouse'un sol tıkına tıkladığımızda NavMeshAgent'a ulaşıyoruz ve etkileşime geçiyoruz.
                _anim.SetBool("Walk", true);
                _target = hitInfo.point; // ---> Target değişkenimizi Mouse ile tıkladığımız yere atıyoruz.

            }

        }

        float distance = Vector3.Distance(transform.position, _target); // ---> Mouse ile bastığımız yerin uzaklığını hesaplıyoruz.
        
        if (distance < 1.0f) // ---> Hesapladığımız distance 1'den az ise animasyonu durdur Idle'a geç.
        {

            _anim.SetBool("Walk", false);

        }

        if (Input.GetMouseButtonDown(1) && _coinCooldown == false) // ---> Mouse'a sağ tıkladığımızda olacak şey.
        {

            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {

                _anim.SetTrigger("Throw");
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, transform.position);
                _coinCooldown = true;
                SendAIToCoinSpot(hitInfo.point);

            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Time.timeScale = 0;
            _pauseMenuPanel.SetActive(true);

        }
        
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {

        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach (GameObject guard in guards)
        {
            
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();
            currentAnim.SetBool("Walk", true);
            currentGuard.coinToss = true;
            currentAgent.SetDestination(coinPos);
            currentGuard.coinPos = coinPos;
        
        }

    }

}
