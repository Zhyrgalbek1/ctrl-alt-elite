namespace Task_Meneger.Controllers.Additional_settings.MenuOption
{
    public class Menu
    {
        private List<Option> _options;

        public Menu(List<Option> options)
        {
            _options = options;
        }

        public void Render()
        {

            Console.SetCursorPosition(2, 2);

            foreach (var option in _options)
            {
                var optionName = option.Title;

                if (option.IsSelected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write($"  {optionName}  ");

                Console.ResetColor();

                Console.WriteLine();

            }
        }

        public void MoveOption(int step)
        {
            var oldOption = _options.First(o => o.IsSelected);
            var oldOptionIndex = _options.IndexOf(oldOption);

            if (oldOptionIndex + step < 0) return;
            if (oldOptionIndex + step > _options.Count - 1) return;

            oldOption.IsSelected = false;
            var newOption = _options[oldOptionIndex + step];
            newOption.IsSelected = true;
        }

        public void ActivateOption()
        {
            var option = _options.First(o => o.IsSelected);
            option.OnSelect.Invoke();
        }
    }
}
