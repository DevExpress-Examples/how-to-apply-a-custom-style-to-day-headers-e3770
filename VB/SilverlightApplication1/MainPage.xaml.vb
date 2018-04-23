Imports System
Imports System.Windows
Imports System.Windows.Data
Imports System.Globalization
Imports System.Windows.Controls

Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        Dim style As Style = CType(Me.Resources("DateHeaderStyle"), Style)
        schedulerControl1.DayView.DateHeaderStyle = style
        schedulerControl1.WorkWeekView.DateHeaderStyle = style

    End Sub

End Class

Public Class DateTimeToShortDateStringConverter
    Implements IValueConverter
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, _
                            ByVal parameter As Object, _
                            ByVal culture As CultureInfo) _
                        As Object Implements IValueConverter.Convert
        If value Is Nothing Then
            Return Nothing
        End If
        Dim dateTimeValue As DateTime = CDate(value)

        Dim param As String = If(parameter IsNot Nothing, parameter.ToString(), String.Empty)
        If param = String.Empty Then
            param = "MM/dd"
        End If

        Return dateTimeValue.ToString(param)
    End Function
    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, _
                                ByVal parameter As Object, _
                                ByVal culture As CultureInfo) _
                            As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class