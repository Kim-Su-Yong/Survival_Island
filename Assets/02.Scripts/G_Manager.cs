using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//적 태어나는 로직을 구현  적생성 로직
// 1. 태어날 위치 2. 좀비프리팹 3. 몇 초 간격으로 태어날 것인가
// 4. 몇마리 태어날 것인가 5. 제한

public class G_Manager : MonoBehaviour
{
    public Transform[] Points;
    public GameObject zombiePrefab;
    public GameObject monsterPrefab;
    public GameObject skeletonPrefab;
    [SerializeField]
    private GameObject bulletPrefab;
    public List<GameObject> bulletPool = new List<GameObject>();
    public List<GameObject> enemyPool = new List<GameObject>();
    private float timePreve1;
    private float timePreve2;
    private float timePreve3;
    public int maxCount = 10;
    public Text killTxt;
    public static int total = 0;
    public static G_Manager g_manager; //싱글턴 기법
    public int maxcount = 10;
    public bool isGameOver = false;
    private float CreateTime = 5.0f;
    private void Awake()
    {
        g_manager = this;
        bulletPrefab = (GameObject)Resources.Load("Bullet");
        zombiePrefab = Resources.Load<GameObject>("ZomBie");
        Points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        CreateEnemyPool();
        CreateBulletPool();

        InvokeRepeating("RepeatingEnemy", 2.0f, 3.0f);
        //하이라키에 SpawnPoint라는 오브젝트를 찾아서 자기자신과
        //하위 오브젝트에 있는 트랜스폼 컴퍼넌트들을 Points 배열에 대입
        //timePreve1 = Time.time; //현재시간
    }
    void Update()
    {       //현재시 - 과거시 = 흘러간 시간
        //if(Time.time - timePreve1 > 3.0f)
        //{
        //    timePreve1 = Time.time;
        //    int zombieCount = (int)GameObject.FindGameObjectsWithTag("ZOMBIE").Length;
        //       //하이라키에서 태어난 좀비라는 태그를 가진 갯수를 zombieCount에 넘긴다.
        //       if(zombieCount < maxCount)
        //            CreateZombie();
        //}
        //if(Time.time - timePreve2 > 5.0f)
        //{
        //    timePreve2 = Time.time;
        //    int monsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;
        //    if (monsterCount < maxCount - 2)
        //        CreateMonster();
        //}
        //if (Time.time - timePreve3 > 7.0f)
        //{
        //    timePreve3 = Time.time;
        //    int skeletonCount = (int)GameObject.FindGameObjectsWithTag("SKELETON").Length;
        //    if (skeletonCount < maxCount - 1)
        //        CreateSkeleton();
        //}
    }
    //void CreateZombie()
    //{
    //    int idx = Random.Range(1, Points.Length); //배열의 길이값까지
    //    Instantiate(zombiePrefab, Points[idx].position,Points[idx].rotation);
    //}
    //void CreateMonster()
    //{
    //    int idx = Random.Range(1, Points.Length); //배열의 길이값까지
    //    Instantiate(monsterPrefab, Points[idx].position, Points[idx].rotation);
    //}
    //void CreateSkeleton()
    //{
    //    int idx = Random.Range(1, Points.Length); //배열의 길이값까지
    //    Instantiate(skeletonPrefab, Points[idx].position, Points[idx].rotation);
    //}
    public void KillCount(int count)
    {
        total += count;
        killTxt.text = "Kill :" + "<color=#ff0000>" + total.ToString() + "</color>";
                                   //숫자를 문자로 변환
    }
    void BulletDeActive()
    {
        bulletPrefab.SetActive(false);
    }
    private void CreateBulletPool()
    {
        GameObject bulletPools = new GameObject("BulletPool");
        for (int i = 0; i < maxcount; i++)
        {
            var obj = Instantiate<GameObject>(bulletPrefab, bulletPools.transform);
            obj.name = "Bullet_" + i.ToString("00");
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }
    public GameObject GetBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
    private void CreateEnemyPool()
    {
        GameObject enemyObj = new GameObject("EnemyPool");
        for (int i = 0; i < maxcount; i++)
        {
            GameObject _enemy = Instantiate(zombiePrefab, enemyObj.transform);
            //GameObject _enemy2 = Instantiate(enemy2, enemyObj.transform);
            _enemy.name = "ZomBie" + i.ToString();
           // _enemy2.name = "Enemy" + i.ToString();
            _enemy.SetActive(false); //액티브를 비활성화
           // _enemy2.SetActive(false);
            enemyPool.Add(_enemy);
            //enemyPool.Add(_enemy2);
            //리스트에 담는다
        }
    }

    void RepeatingEnemy()
    {
        if (isGameOver == true) return;
        //게임오버인 경우 반복문 while문을 빠져나가서 코루틴을 종료
        foreach (GameObject _enemy in enemyPool)
        {   //비활성화 된 오브젝트라면
            if (_enemy.activeSelf == false)
            {
                int idx = Random.Range(1, Points.Length);
                _enemy.transform.position = Points[idx].position;
                _enemy.transform.rotation = Points[idx].rotation;
                _enemy.SetActive(true);
                //오브젝트 활성화
                break;
                //enemy하나를 생성 후 for 루프를 빠져나감
            }
        }
    }
}
