using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace DelegationHelper
{
    public class Behaviors
    {
    }

    public class CloseWindowAfterKeyIsPressed :Behavior<Window>
    {
        public Key PreedKey { get; set; }

        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if (window != null) window.PreviewKeyDown += Window_PrewiewKeyDown;
        }

        private void Window_PrewiewKeyDown(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Key == PreedKey) window.Close();
        }
    }

    public class ButtonCloseWindow :Behavior<Window>
    {
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register(
                "ButtonXML",
                typeof(Button),
                typeof(ButtonCloseWindow),
                new PropertyMetadata(null, ChangedButton)
                );

        public Button ButtonXML
        {
            get { return (Button)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        private static void ChangedButton(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = (d as ButtonCloseWindow).AssociatedObject;
            RoutedEventHandler button_Click =
                (object sender, RoutedEventArgs _e) => { window.Close(); };
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }
}
