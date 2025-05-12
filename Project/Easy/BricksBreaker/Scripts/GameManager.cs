using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public ball b{get; private set;}
     public paddle p{get; private set;}
     public brickes[] bricks{get; private set;}
    public int Level=1;
    public  int Score=0;
    public int Lives=3;
    
   private void Awake() 
   {
        DontDestroyOnLoad(this.gameObject); 
        SceneManager.sceneLoaded += OnSceneLoaded;
   }
     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
     {
            this.b = FindObjectOfType<ball>();
            this.p = FindObjectOfType<paddle>();
            this.bricks = FindObjectsOfType<brickes>();
     }
   private void Start() 
   {
        NewGame(); 
   }
   private void Update() 
   {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
           LoadLevel(this.Level+1);
        }
        if(b.transform.position.y<-11f)
        {
            LoseLife();
        }
    
   }
   private void NewGame()
   {
        this.Lives=3;
        this.Score=0;

        LoadLevel(1);
   }
   private void LoadLevel(int Level)
   {
        this.Level=Level;
        if(Level>3)
        {
            SceneManager.LoadScene("Win");
            return;
        }
        SceneManager.LoadScene("Level_"+Level);
   }

   public void Hit(brickes b)
   {
     this.Score+=b.Points;
     if(clered())
     {
           LoadLevel(this.Level+1);
     }
   }
   private bool clered()
   {
     for (int i = 0; i < this.bricks.Length; i++)
     {
         if(this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
         {
             return false;
         }
     }
     return true;
   }

   public void LoseLife()
   {
     this.Lives--;
     if(this.Lives>0)
     {
       restart();
     }
     else
     {
       GameOver();
     }
   }
   private void restart()
   {
     this.b.Resetball();
     this.p.Resetpaddle();
   }
   private void GameOver()
   {
     this.b.Resetball();
     this.p.Resetpaddle();
     for (int i = 0; i < this.bricks.Length; i++)
     {
          this.bricks[i].Resetbrick();
     }
     NewGame();
   }
}
