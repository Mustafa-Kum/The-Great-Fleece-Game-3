using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    
    public bool coinToss;
    public List<Transform> wayPoints; // ---> Transformları alan bir liste oluşturduk.
    public Vector3 coinPos;
    private NavMeshAgent _agent; // ---> NavMeshAgent'ın componentlerine ulaşmak için atadığımız değişken.
    private int _currentTarget;
    private bool _reverse;
    private bool _targetReached;
    private Animator _anim;

    
    // Start is called before the first frame update
    void Start()
    {
        
        _agent = GetComponent<NavMeshAgent>(); // ---> NavMeshAgent'ın componentlerine ulaşmak için atadığımız değişken.
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Movement();

    }

    public void Movement()
    {

        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null && coinToss == false)
        {

            _agent.SetDestination(wayPoints[_currentTarget].position); // ---> Gideceği noktalara atayacağımız sayıları buradaki değişken ile değiştiriyoruz.
            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position); // ---> Guard ile seçtiğimiz noktanın uzaklığını hesaplıyoruz.

            if (distance < 1.0f && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {

                if (_anim != null)
                {

                    _anim.SetBool("Walk", false);

                }

            }
            else
            {

                if (_anim != null)
                {

                    _anim.SetBool("Walk", true);

                }

            }
            
            if (distance < 1.0f && _targetReached == false) // ---> Seçtiğimiz nokta ve guard arasındaki mesafe 1'den küçük olduğunda currentTarget'ı 1 arttır.
            {

                if (wayPoints.Count < 2)
                {

                    return;

                }
                
                if ((_currentTarget == 0 || _currentTarget == wayPoints.Count -1) && wayPoints.Count > 1)
                {

                    _targetReached = true;
                    StartCoroutine(WaitBeforeMoving());

                }   
                else
                {

                    if (_reverse == true)
                    {

                        _currentTarget--;
                        if (_currentTarget <= 0)
                        {

                             _reverse = false;
                             _currentTarget = 0;

                        }

                    }
                    else
                    {

                        _currentTarget++;

                    }
                        
                }
                
            }

        }
        else
        {

            float distance = Vector3.Distance(transform.position, coinPos);

            if (distance < 5f)
            {

                _anim.SetBool("Walk", false);

            }

        }
    
    }

    IEnumerator WaitBeforeMoving() // ---> Point'lere ulaştığı zaman 2 saniye bekleyecek. Movement'taki point kodlarını buraya taşıdık.
    {

        if (_currentTarget == 0)
        {

            yield return new WaitForSeconds(2.0f);

        }

        else if (_currentTarget == wayPoints.Count - 1)
        {

            yield return new WaitForSeconds(2.0f);

        }
        
        if (_reverse == true)
        {

            _currentTarget--;
            
            if (_currentTarget == 0) // ---> CurrentTarget 0'a tekrar geldiğinde reverse'ü false'a çevir CurrentTarget'ı da 0'a eşitle ve arttırmaya devam et.
            {

                _reverse = false;
                _currentTarget = 0;

            }

        }
        else if (_reverse == false)
        {

            _currentTarget++;
            
            if (_currentTarget == wayPoints.Count) // ---> CurrentTarget Listemizin uzunluğuna eriştiği zaman -1 azalt.
            {

                _reverse = true;
                _currentTarget--;

            }

        }

        _targetReached = false;
        

    }

}
