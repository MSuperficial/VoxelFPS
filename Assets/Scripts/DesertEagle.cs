using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEagle : MonoBehaviour {
    public Transform muzzle;
    public Camera _camera;
    private Animator animator;
    public GameObject player;
    private AudioSource audioSource;
    private GameObject fireEffect;
    public float damage;
    public int bullet;

    private GameObject bulletHole;
	// Use this for initialization
	void Start ()
    {
        bulletHole = Resources.Load<GameObject>("BulletHole");
        animator = player.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        animator.SetBool("isFiring", false);
        if(!player.GetComponent<Player>().died && Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0) && bullet > 0)
            {
                animator.SetBool("isFiring", true);
                audioSource.Play();
                bullet--;
                fireEffect = Instantiate(Resources.Load("FireEffect"), muzzle.position, muzzle.rotation) as GameObject;
                fireEffect.transform.parent = muzzle;
                Ray ray_1 = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                RaycastHit hit_1;
                if (Physics.Raycast(ray_1, out hit_1))
                {
                    Ray ray_2 = new Ray(muzzle.position, hit_1.point - muzzle.position);
                    RaycastHit hit_2;
                    if (Physics.Raycast(ray_2, out hit_2))
                    {
                        if (hit_2.collider.gameObject.GetComponent<Enemy>())
                        {
                            hit_2.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                        }
                        if (hit_2.collider.tag == "Vital")
                        {
                            hit_2.collider.transform.parent.parent.gameObject.GetComponent<Enemy>().TakeDamage(damage * 2);
                        }
                        if (hit_2.collider.tag == "Ground")
                        {
                            var hole = GameObject.Instantiate(bulletHole, hit_2.point+hit_2.normal*0.05f, Quaternion.FromToRotation(Vector3.forward, hit_2.normal));
                            //var pos = hit_2.point;
                            //pos.z += 0.1f;
                            //hole.transform.position = pos;
                            //hole.transform.LookAt(hit_2.point+hit_2.normal);
                        }
                    }
                    
                }
            }
        }
	}
}
