using CityDriveManager.Services;
using CityDriveManager.UI;

var service = new CityServices();
var menu = new Menu(service);
menu.Run();
