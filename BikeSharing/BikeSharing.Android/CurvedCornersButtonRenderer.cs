using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using BikeSharing.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BikeSharing;
using Android.Util;

#pragma warning disable CS0612 // Il tipo o il membro è obsoleto
[assembly: ExportRenderer(typeof(CustomButtons), target: typeof(CurvedCornersButtonRenderer))]
#pragma warning restore CS0612 // Il tipo o il membro è obsoleto
namespace BikeSharing.Droid
{
    [Obsolete]

    public class CurvedCornersButtonRenderer : ButtonRenderer
    {
        private GradientDrawable _gradientBackground;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            var view = (CustomButtons)Element;
            if (view == null) return;
            Paint(view);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomButtons.CustomBorderColorProperty.PropertyName ||
                 e.PropertyName == CustomButtons.CustomBorderRadiusProperty.PropertyName ||
                 e.PropertyName == CustomButtons.CustomBorderWidthProperty.PropertyName)
            {
                if (Element != null)
                {
                    Paint((CustomButtons)Element);
                }
            }
        }
        private void Paint(CustomButtons view)
        {
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CustomBackgroundColor.ToAndroid());
            _gradientBackground.SetStroke((int)view.CustomBorderWidth, view.CustomBorderColor.ToAndroid());
            _gradientBackground.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(view.CustomBorderRadius)));
            Control.SetBackground(_gradientBackground);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}