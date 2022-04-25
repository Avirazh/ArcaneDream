using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;

        [Header("Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        [Header("Hp system param")]
        [SerializeField] private int hp;

        [Header("Projectile prefab")]
        [SerializeField] private GameObject projectile;

        //private HpSystem hpSystem;

        void Start()
        {
            ProjectileInstantiate();
            playerRb = GetComponent<Rigidbody>();
            //hpSystem.hp = hp;
            //hpSystem.maxHp = hp;
        }

        void Update()
        {
            //need to be moved to Projectile class
            if (Input.GetKeyDown(KeyCode.Space))
            {
                projectile.SetActive(true);
                Debug.Log("projectile");

            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                projectile.SetActive(false);
            }
            MovePlayer();

            //need to be moved to Projectile class
            MoveProjectile();
        }
        //need to be moved to Projectile class
        private void ProjectileInstantiate()
        {
            projectile = Instantiate(projectile, transform.position, projectile.transform.rotation);
            projectile.SetActive(false);
        }
        private void MovePlayer()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDir = new Vector3(horizontal, 0, vertical).normalized;

            transform.Translate(moveDir * (moveSpeed * Time.deltaTime), Space.World);

            if(moveDir != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            
        }

        //need to be moved to Projectile class
        private void MoveProjectile()
        {
            projectile.transform.position = transform.position;
        }
    }
}
