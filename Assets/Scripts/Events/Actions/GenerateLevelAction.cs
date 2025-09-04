using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GenerateLevelAction : CustomAction.Action
{
    private LevelGenerator _levelGenerator;
    private LevelDestroyer _levelDestoyer;

    [Inject]
    private void Construct(LevelGenerator levelGenerator,
        LevelDestroyer levelDestroyer)
    {
        _levelGenerator = levelGenerator;
        _levelDestoyer = levelDestroyer;
    }
        
    public override void DoAction()
    {
        GenerateLevel();
        gameObject.SetActive(false);
    }

    public  void GenerateLevel()
    {
       // await Task.Run(() =>
        //{
            _levelDestoyer.Destroy();
            _levelGenerator.GenerateLevel();
        //});
    }
}