using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6WpfApp
{
    class WeatherControl : DependencyObject
    {
        private string windDirection;
        private int windSpeed;
        private string rainfall;
        public enum rainfallList
        {
            солнечно,
            облачно,
            дождь,
            снег
        }
        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }
        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }
        public string Rainfall
        {
            get => rainfall;
            set => rainfall = value;
        }
        public WeatherControl(int temperature, string windDirection, int windSpeed, int rainfall)
        {
            this.Temperature = temperature;
            this.windDirection = windDirection;
            this.windSpeed = windSpeed;
            this.rainfall = ((rainfallList)rainfall).ToString();
        }
        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature)
                );
        }
        private static bool ValidateTemperature(object value)
        {
            int val = (int)value;
            if (val >= -273 && val <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int val = (int)baseValue;
            if (val >= -50 && val <= 50)
            {
                return val;
            }
            else
            {
                return 0;
            }
        }
    }
}
