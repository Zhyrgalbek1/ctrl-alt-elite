namespace Task_Meneger.Apps
{
    public class ReleaseApp
    {
        public void Start()
        {
            var consoleView = new MainMenu(1);
            consoleView.StartMenu();
        }
    }
}
