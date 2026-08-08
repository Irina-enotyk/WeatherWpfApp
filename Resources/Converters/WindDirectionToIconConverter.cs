using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WeatherWpfApp.Models;

namespace WeatherWpfApp.Resources.Converters
{
    class WindDirectionToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string resourceName = null;

            var windDirection = DetectSectorByDegrees((int)value);

            switch ((WindDirection)windDirection)
            {
                case WindDirection.North:
                    resourceName = "wind_array_top";
                    break;
                case WindDirection.South:
                    resourceName = "wind_array_buttom";
                    break;
                case WindDirection.West:
                    resourceName = "wind_array_left";
                    break;
                case WindDirection.East:
                    resourceName = "wind_array_right";
                    break;
            }

            if(resourceName ==  null)
            {
                return null;
            }

            return Application.Current.Resources[resourceName] as ControlTemplate;
        }

        //Хотела бы сделать так, чтобы в ресурсах было просто "wind_array" - базовая стрелка.
        //А угол наклона менять динамически
        //А внутри ресурса подписаться на свойство типа int x от 0 до 359,
        //значение которого приходит из апи и хранится в свойстве, и бросать событие изменения этого свойства
        //public List<int>? Wind_direction_10m_dominant { get; set; }

        //    <Grid.RenderTransform>
        //        <RotateTransform
        //            CenterX = "20"
        //            CenterY="20"
        //            Angle="{Binding x}"/> - и уже на этот угол внутри ресурса поворачивать стрелку.
        //    </Grid.RenderTransform>

        //    или идея не очень?


        //Пусть пока так будет DetectSectorByDegrees(int degrees)
        //Определяем направление - 1 из 4х вариантов для углов, которые приходят 0 до 359
        private static double DetectSectorByDegrees(int degrees)
        {
            //Выглядит, наверное, непонятно.
            //Это преобразование из градусов в радианы со смещением на -45 градусов (0.5)

            var radian = (degrees / 90) - 0.5;
            var windDirection = 0;
            switch (radian)
            {
                //От -45 до 45 градусов на секторе окружности направление ветра - восточное
                case double x when x >= -0.5 && x < 0.5:
                    windDirection = 0;
                    break;

                //От 45 до 135 градусов на секторе окружности направление ветра - северное
                case double x when x >= 0.5 && x < 1.5:
                    windDirection = 1;
                    break;

                //От 135 до 225 градусов на секторе окружности направление ветра - западное
                case double x when x >= 1.5 && x < 2.5:
                    windDirection = 2;
                    break;

                //От 225 до 315 градусов на секторе окружности направление ветра - южное
                case double x when x >= 2.5 && x < 3.5:
                    windDirection = 3;
                    break;
            }
            return windDirection;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
