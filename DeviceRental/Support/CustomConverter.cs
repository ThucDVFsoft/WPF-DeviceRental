using System;
using System.Windows.Data;

namespace DeviceRentalManagement.Support
{
    class StatusInt2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (int.Parse(value.ToString()))
            {
                case 0:
                case 1:
                    return "Not Return";
                case 2:
                default:
                    return "Returned";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                if ((string)value == "Not Return" )
                    return 1;
                else
                    return 2;
            }
            return 2;
        }
    }

    class DataGridIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                return (int)value + 1;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                return (int)value - 1;
            }
            return 1;
        }
    }
}
