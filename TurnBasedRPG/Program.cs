using TurnBasedRPG.Entities;
using static System.Console;

Menu.Welcome();

int mainOption = Menu.MainMenu();

if (mainOption == 1)
{
    int characterSelection = Menu.CharacterSelection();
    Menu.ConfirmClass(characterSelection);
}