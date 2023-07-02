using System.Text;
using Task_Meneger.Apps;
using Task_Meneger.Controllers.Additional_settings;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;
ReadLine.AutoCompletionHandler = new AutoCompletionHandler();

var startApp = new ReleaseApp();
startApp.Start();



