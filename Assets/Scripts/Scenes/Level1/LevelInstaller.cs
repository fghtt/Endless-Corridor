using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private PassedCorridorsCount _passedCorridorsCount;
    [SerializeField] private AmountOfBatteriesUI _amountOfBatteriesUI;
    [SerializeField] private TextWindow _textWindow;
    [SerializeField] private FlashlightPower _flashlightPower;
    [SerializeField] private RedScreenEffect _redScreenEffect;
    [SerializeField] private CreatingLevelWindow _creatingLevelWindow;

    [SerializeField] private PlayerStates _playerStates;
    [SerializeField] private Journal _journal;
    [SerializeField] private StartRoom _startRoom;
    [SerializeField] private Advertisement _advertisement;

    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private LevelDestroyer _levelDestroyer;

    public override void InstallBindings()
    {
        Container.Bind<PassedCorridorsCount>().FromInstance(_passedCorridorsCount);
        Container.Bind<AmountOfBatteriesUI>().FromInstance(_amountOfBatteriesUI);
        Container.Bind<TextWindow>().FromInstance(_textWindow);
        Container.Bind<FlashlightPower>().FromInstance(_flashlightPower);
        Container.Bind<RedScreenEffect>().FromInstance(_redScreenEffect);
        Container.Bind<CreatingLevelWindow>().FromInstance(_creatingLevelWindow);

        Container.Bind<PlayerStates>().FromInstance(_playerStates);
        Container.Bind<Journal>().FromInstance(_journal);
        Container.Bind<StartRoom>().FromInstance(_startRoom);    
        Container.Bind<Advertisement>().FromInstance(_advertisement);

        Container.Bind<LevelGenerator>().FromInstance(_levelGenerator);
        Container.Bind<LevelDestroyer>().FromInstance(_levelDestroyer);
        Container.Bind<CorridorsGenerator>()
            .FromInstance(_levelGenerator.GetComponent<CorridorsGenerator>());
        Container.Bind<RoomsGenerator>()
            .FromInstance(_levelGenerator.GetComponent<RoomsGenerator>());
        Container.Bind<MonstersGenerator>()
      .FromInstance(_levelGenerator.GetComponent<MonstersGenerator>());
        Container.Bind<BatteriesGenerator>()
      .FromInstance(_levelGenerator.GetComponent<BatteriesGenerator>());
        Container.Bind<NotesGenerator>()
       .FromInstance(_levelGenerator.GetComponent<NotesGenerator>());
    }
}