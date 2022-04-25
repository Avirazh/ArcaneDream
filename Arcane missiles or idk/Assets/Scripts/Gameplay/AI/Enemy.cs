using UnityEngine;

namespace AI
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy movespeed")]
        [SerializeField] private int moveSpeed;

        [Header("Crystal prefab")]
        [SerializeField] private GameObject crystalPref;

        [Header("Hp system params")]
        [SerializeField] private int hp;

        //private HpSystem hpSystem;

        private Transform playerTransform;
        void Start()
        {
            playerTransform = GameObject.Find("Player").transform;
            //hpSystem.hp = hp;
            //hpSystem.maxHp = hp;
        }

        void Update()
        {
            //transform.position += playerTransform.position * moveSpeed * Time.deltaTime;
            transform.LookAt(playerTransform);

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        /*private void OnDestroy()
        {
            Instantiate(crystalPref, transform.position, crystalPref.transform.rotation);
        }*/
    }
}