using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using DevExpress.Xpf.Scheduler;

namespace SilverlightApplication1 {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();

            Style style = (Style)this.Resources["DateHeaderStyle"];
            schedulerControl1.DayView.DateHeaderStyle = style;
            schedulerControl1.WorkWeekView.DateHeaderStyle = style;
        }
    }

    public class DateTimeToShortDateStringConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture) {
            if (value == null)
                return null;
            DateTime dateTimeValue = (DateTime)value;

            string param = parameter != null ? parameter.ToString() : string.Empty;
            if (param == string.Empty)
                param = "MM/dd";

            return dateTimeValue.ToString(param);
        }
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            return null;
        }
    }

}
