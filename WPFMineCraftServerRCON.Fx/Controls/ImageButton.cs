using System.Windows;
using System.Windows.Controls;

namespace Controls
{
    public class ImageButton : Button
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        #region properties
        public string ImageNormal
        {
            get { return (string)GetValue(ImageNormalProperty); }
            set { SetValue(ImageNormalProperty, value); }
        }
        public string ImagePressed
        {
            get { return (string)GetValue(ImagePressedProperty); }
            set { SetValue(ImagePressedProperty, value); }
        }
        public string ImageOver
        {
            get { return (string)GetValue(ImageOverProperty); }
            set { SetValue(ImageOverProperty, value); }
        }

        public bool IsHideNormal
        {
            get { return (bool)GetValue(IsHideNormalProperty); }
            set { SetValue(IsHideNormalProperty, value); }
        }
        #endregion

        #region dependency properties
        public static readonly DependencyProperty ImageNormalProperty =
            DependencyProperty.Register("ImageNormal", typeof(string), typeof(ImageButton), new PropertyMetadata(null));

        public static readonly DependencyProperty ImagePressedProperty =
            DependencyProperty.Register("ImagePressed", typeof(string), typeof(ImageButton), new PropertyMetadata(null));

        public static readonly DependencyProperty ImageOverProperty =
            DependencyProperty.Register("ImageOver", typeof(string), typeof(ImageButton), new PropertyMetadata(null));

        public static readonly DependencyProperty IsHideNormalProperty =
            DependencyProperty.Register("IsHideNormal", typeof(bool), typeof(ImageButton), new PropertyMetadata(false));
        #endregion
    }

}
